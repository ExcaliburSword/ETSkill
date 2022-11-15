using System;

namespace ET
{
    [FriendClassAttribute(typeof(ET.SkillState))]
    [FriendClassAttribute(typeof(ET.Skill))]
    [FriendClassAttribute(typeof(ET.SkillAction))]
    [FriendClassAttribute(typeof(ET.Formula))]
    [FriendClassAttribute(typeof(ET.Property))]
    public static class SkillRealizeManagerSystem
    {
        public static void TryToRealizeSkill(this SkillRealizeManager self, int skillId)
        {
            //TODO 判断玩家自身状态是否可以使用技能（被控制等）

            //检查玩家是否有该技能
            var skillState = self.skillStateComponent.GetSkill(skillId);
            if (skillState == null)
            {
                Log.Debug($"该角色没有技能{skillId}");
                return;
            }

            var ownerProperty = skillState.SkillOwner.GetComponent<Property>();
            //判断玩家是否可以支撑该技能的消耗，MP等
            if (ownerProperty.Mp < skillState.skillEntity.mpCost
                || ownerProperty.Hp < skillState.skillEntity.hpCost
                || ownerProperty.Xp < skillState.skillEntity.XpCost)
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
            //TODO 选择技能作用目标列表

            //TODO 判断该技能是否可以对当前目标使用


            //TODO 开始准备，到准备时间达到技能需要的准备时间，技能生效

            self.RealizeSkill(skillState);
        }

        private static void RealizeSkill(this SkillRealizeManager self, SkillState skillState)
        {
            var ownerProperty = skillState.SkillOwner.GetComponent<Property>();
            //扣除消耗
            ownerProperty.Mp -= skillState.skillEntity.mpCost;
            ownerProperty.Hp -= skillState.skillEntity.hpCost;
            ownerProperty.Xp -= skillState.skillEntity.XpCost;
            //进入冷却计算
            skillState.coldTimeLeft = skillState.skillEntity.coldTime;
            //造成生命值变换
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
                    self.TryToRealizeSkill(skillState.skillEntity.callBackSkillId);
                }
            }
            //施加自身buff
            if (skillState.skillEntity.buffPossibility>0 && skillState.skillEntity.buffId>0)
            {
                if (Random.Shared.Next(1,100)<=skillState.skillEntity.buffPossibility)
                {
                    AddBuff(skillState.SkillOwner, skillState.SkillOwner,skillState.skillEntity.buffId);
                }
            }
            //施加目标buff
            if (skillState.skillEntity.targetBuffPossibility > 0 && skillState.skillEntity.targetBuffId>0)
            {

                foreach (var target in skillState.skillTargets)
                {
                    if (Random.Shared.Next(1, 100) <= skillState.skillEntity.targetBuffPossibility)
                    {
                        AddBuff(target, skillState.SkillOwner,skillState.skillEntity.buffId);
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
        }

        private static void AddBuff(Unit target, Unit ori, int buffId)
        {
            var buffstateComponent = target.GetComponent<BuffStateComponent>();
            if (buffstateComponent!=null)
            {
                buffstateComponent.AddBuff(ori,buffId);
            }
        }
    }
}