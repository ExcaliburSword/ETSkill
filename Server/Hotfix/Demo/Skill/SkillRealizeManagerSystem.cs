using System;
using System.Buffers;
using System.Threading.Tasks;
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
        public static async  ETTask<int> TryToRealizeSkill(this SkillRealizeManager self, int skillId,Unit selectedTarget,Vector3 MousePosition)
        {
            //TODO 判断玩家自身状态是否可以使用技能（被控制等）

            //检查玩家是否有该技能
            var skillState = self.skillStateComponent.GetSkill(skillId);
            if (self.skillStateComponent==null)
            {
                Log.Error($"该角色没有skillStateComponent");
                return ErrorCode.ERR_HasNoSkill;
            }
            Log.Debug($"找到技能管理器");
            
            if (skillState == null)
            {
                Log.Debug($"该角色没有技能{skillId}");
                return ErrorCode.ERR_HasNoSkill;
            }
            Log.Debug($"检查玩家拥有技能{skillId}");
            var skillEntity = skillState.skillEntity;
            var ownerProperty = skillState.SkillOwner.GetComponent<Property>();
            //判断玩家是否可以支撑该技能的消耗，MP等
            if (ownerProperty.Mp < skillEntity.mpCost
                || ownerProperty.Hp < skillEntity.hpCost
                || ownerProperty.Xp < skillEntity.XpCost)
            {
                Log.Debug($"MP/hp/xp值不足，不能释放技能 {skillEntity.skillName} ");
                return ErrorCode.ERR_SkillCostNotEnough;
            }
            Log.Debug("玩家的Mp充足");

            //检查技能冷却时间
            if (skillState.coldTimeLeft > 0)
            {
                Log.Debug($"技能尚未冷却完毕,现在不能释放 {skillEntity.skillName} ");
                return ErrorCode.ERR_SkillColding;
            }
            Log.Debug($"技能 {skillEntity.skillName}已冷却完毕");
            //判断该技能是否可以对当前目标释放
            //有选中目标时，以选中目标判断距离。没有选中目标时，以鼠标指向的点的坐标判断距离
            if (selectedTarget!=null)
            {
                var distanceSquared = Vector3.DistanceSquared(selectedTarget.Position, skillState.SkillOwner.Position);
                if (distanceSquared>skillEntity.maxDistance*skillEntity.maxDistance)
                {
                    Log.Debug($"释放距离超出限制，不能释放 {skillEntity.skillName} ");
                    return ErrorCode.ERR_OutOfSkillRange;
                }
                Log.Debug($"目标在技能范围内，可以释放 {skillEntity.skillName} ");
            }
            else
            {
                var distanceSquared = Vector3.DistanceSquared(MousePosition, skillState.SkillOwner.Position);
                if (distanceSquared>skillEntity.maxDistance*skillEntity.maxDistance)
                {
                    Log.Debug($"释放距离超出限制，不能释放 {skillEntity.skillName} ");
                    return ErrorCode.ERR_OutOfSkillRange;
                }
                Log.Debug($"目标在技能范围内，可以释放 {skillEntity.skillName} ");
            }

            if (skillEntity.selectType==null)
            {
                Log.Debug("selectType为空");
                return -1;
            }

            // 选择技能作用目标列表
            skillState.skillTargets = skillEntity.selectType.Select(skillState.SkillOwner,skillEntity,selectedTarget,MousePosition);

            Log.Debug($"技能{skillEntity.skillName}即将攻击范围内的{skillState.skillTargets.Length}个目标");
            // 开始准备，每50ms检测一次是否打断，如果没被打断，则释放，打断则直接返回
            var tempState = skillState.SkillOwner.GetComponent<CharactorTempState>();
            if (tempState==null)
            {
                Log.Debug($"无法获取到临时状态，不能继续释放技能 {skillEntity.skillName} ");
                return ErrorCode.ERR_LosePlayerInfo;
            }
            
          
            skillState.preparing = true;//开始准备
            while (skillState.prepareTimeAlready<skillEntity.realizeTime)
            {
                if (BreakSkill(skillId, tempState))
                {
                    Log.Debug($"技能 {skillEntity.skillName} 被打断");
                    skillState.InitState();
                    return ErrorCode.ERR_SkillBroken;
                }
                Log.Debug($"技能 {skillEntity.skillName} 正在读条");
                await Task.Delay(50);
            }
//释放成功
            self.RealizeSkill(skillState,selectedTarget,MousePosition);
            return ErrorCode.ERR_SkillSuccess;
        }

        private static bool BreakSkill(int skillId,CharactorTempState ts)
        {
            //这里没用skillId的原因是，没有使用skill的配置来决定判断打断的条件。如果需要根据具体的skill来判断打断的方式，则需要skillId了
            if (ts.ifMoved||ts.ifCantUseSkill)
            {
                return true;
            }
            return false;
        }
        private static async void RealizeSkill(this SkillRealizeManager self, SkillState skillState,Unit selectedTarget,Vector3 MousePosition)
        {
            var ownerProperty = skillState.SkillOwner.GetComponent<Property>();
            //扣除消耗
            ownerProperty.Mp -= skillState.skillEntity.mpCost;
            ownerProperty.Hp -= skillState.skillEntity.hpCost;
            ownerProperty.Xp -= skillState.skillEntity.XpCost;
  
            //造成生命值变化
            if (skillState.skillEntity.damageFormula != null)
            {
                foreach (var target in skillState.skillTargets)
                {
                    if (target==null)
                    {
                        break;
                    }
                    var damage = skillState.skillEntity.damageFormula.FormulaAct(skillState.SkillOwner, target, skillState.skillEntity);
                    //TODO 经过护盾技能的减免，造成最终效果
                }
            }

            //回调技能
            if (skillState.skillEntity.callBackSkillId > 0 && skillState.skillEntity.callBackSkillInTimePossibility > 0)
            {
                if (Random.Shared.Next(1, 100) <= skillState.skillEntity.callBackSkillInTimePossibility)
                {
                   await self.TryToRealizeSkill(skillState.skillEntity.callBackSkillId,selectedTarget,MousePosition);
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
                    if (target==null)
                    {
                        break;
                    }
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
                    if (target==null)
                    {
                        break;
                    }
                    if (Random.Shared.Next(1, 100) <= skillState.skillEntity.skillActionInTimePossibility)
                    {
                        skillState.skillEntity.skillActionInTime.act(skillState.SkillOwner, target);
                    }
                }
            }
            Log.Debug($"成功释放了技能 {skillState.skillEntity.skillName} ");
            //技能状态重置
            skillState.InitState();
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