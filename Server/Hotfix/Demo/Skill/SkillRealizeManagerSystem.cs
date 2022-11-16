using System;
using System.Buffers;
using UnityEngine;

namespace ET
{
    [FriendClassAttribute(typeof(ET.SkillState))]
    [FriendClassAttribute(typeof(ET.Skill))]
    [FriendClassAttribute(typeof(ET.SkillAction))]
    [FriendClassAttribute(typeof(ET.Formula))]
    [FriendClassAttribute(typeof(ET.Property))]
    [FriendClassAttribute(typeof(ET.SelectTarget))]
    public static class SkillRealizeManagerSystem
    {
        /// <summary>
        /// 接受玩家的释放技能请求后，尝试释放技能
        /// </summary>
        /// <param name="self">玩家身上的技能释放器</param>
        /// <param name="skillId">技能id</param>
        /// <param name="selectedTarget">玩家发出释放命令时选中的目标</param>
        /// <param name="MousePosition">玩家发出释放命令时鼠标指向的地面坐标</param>
        public static void TryToRealizeSkill(this SkillRealizeManager self, int skillId,Unit selectedTarget,Vector3 MousePosition)
        {
            //TODO 判断玩家自身状态是否可以使用技能（被控制等）

            //检查玩家是否有该技能
            var skillState = self.skillStateComponent.GetSkill(skillId);
            if (skillState == null)
            {
                Log.Debug($"该角色没有技能{skillId}");
                return;
            }
            var skillEntity = skillState.skillEntity;
            var ownerProperty = skillState.SkillOwner.GetComponent<Property>();
            //判断玩家是否可以支撑该技能的消耗，MP等
            if (ownerProperty.Mp < skillEntity.mpCost
                || ownerProperty.Hp < skillEntity.hpCost
                || ownerProperty.Xp < skillEntity.XpCost)
            {
                Log.Debug("MP/hp/xp值不足，不能释放技能");
                return;
            }

            //检查技能冷却时间
            if (skillState.coldTimeLeft > 0)
            {
                Log.Debug("技能尚未冷却完毕,现在不能释放");
                return;
            }
            //判断该技能是否可以对当前目标释放
            //有选中目标时，以选中目标判断距离。没有选中目标时，以鼠标指向的点的坐标判断距离
            if (selectedTarget!=null)
            {
                var distanceSquared = Vector3.DistanceSquared(selectedTarget.Position, skillState.SkillOwner.Position);
                if (distanceSquared>skillEntity.maxDistance*skillEntity.maxDistance)
                {
                    Log.Debug("释放距离超出限制，不能释放");
                    return;
                }
            }
            else
            {
                var distanceSquared = Vector3.DistanceSquared(MousePosition, skillState.SkillOwner.Position);
                if (distanceSquared>skillEntity.maxDistance*skillEntity.maxDistance)
                {
                    Log.Debug("释放距离超出限制，不能释放");
                    return;
                }
            }
            
            // 选择技能作用目标列表
            skillState.skillTargets = skillEntity.selectType.Select(skillState.SkillOwner,skillEntity,selectedTarget,MousePosition);

            


            //TODO 开始准备，到准备时间达到技能需要的准备时间，技能生效

            if (true)
            {
                self.RealizeSkill(skillState,selectedTarget,MousePosition);
            }
            /*
            else
            {
                ArrayPool<Unit>.Shared.Return(skillState.skillTargets);
            }
            */

        }

        private static void RealizeSkill(this SkillRealizeManager self, SkillState skillState,Unit selectedTarget,Vector3 MousePosition)
        {
            var ownerProperty = skillState.SkillOwner.GetComponent<Property>();
            //扣除消耗
            ownerProperty.Mp -= skillState.skillEntity.mpCost;
            ownerProperty.Hp -= skillState.skillEntity.hpCost;
            ownerProperty.Xp -= skillState.skillEntity.XpCost;
            //进入冷却计算
            skillState.coldTimeLeft = skillState.skillEntity.coldTime;
            //造成生命值变化
            if (skillState.skillEntity.damageFormula != null)
            {
                foreach (var target in skillState.skillTargets)
                {
                    var damage = skillState.skillEntity.damageFormula.FormulaAct(skillState.SkillOwner, target, skillState.skillEntity);
                    //TODO 经过护盾技能的减免，造成最终效果
                }
            }

            //回调技能
            if (skillState.skillEntity.callBackSkillId > 0 && skillState.skillEntity.callBackSkillInTimePossibility > 0)
            {
                if (Random.Shared.Next(1, 100) <= skillState.skillEntity.callBackSkillInTimePossibility)
                {
                    self.TryToRealizeSkill(skillState.skillEntity.callBackSkillId,selectedTarget,MousePosition);
                }
            }
            //施加自身buff
            if (skillState.skillEntity.buffPossibility > 0 && skillState.skillEntity.buffId > 0)
            {
                if (Random.Shared.Next(1, 100) <= skillState.skillEntity.buffPossibility)
                {
                    AddBuff(skillState.SkillOwner, skillState.SkillOwner, skillState.skillEntity.buffId);
                }
            }
            //施加目标buff
            if (skillState.skillEntity.targetBuffPossibility > 0 && skillState.skillEntity.targetBuffId > 0)
            {

                foreach (var target in skillState.skillTargets)
                {
                    if (Random.Shared.Next(1, 100) <= skillState.skillEntity.targetBuffPossibility)
                    {
                        AddBuff(target, skillState.SkillOwner, skillState.skillEntity.buffId);
                    }
                }
            }
            //执行SkillAction
            if (skillState.skillEntity.skillActionInTimePossibility > 0 && skillState.skillEntity.skillActionInTime != null)
            {

                foreach (var target in skillState.skillTargets)
                {
                    if (Random.Shared.Next(1, 100) <= skillState.skillEntity.skillActionInTimePossibility)
                    {
                        skillState.skillEntity.skillActionInTime.act(skillState.SkillOwner, target);
                    }
                }
            }
            //回收目标列表
            ArrayPool<Unit>.Shared.Return(skillState.skillTargets);
        }

        private static void AddBuff(Unit target, Unit ori, int buffId)
        {
            var buffstateComponent = target.GetComponent<BuffStateComponent>();
            if (buffstateComponent != null)
            {
                buffstateComponent.AddBuff(ori, buffId);
            }
        }
    }
}