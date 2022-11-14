namespace ET
{
    [FriendClassAttribute(typeof(ET.SkillState))]
    public static class SkillRealizeManagerSystem
    {
        public static void TryToRealizeSkill(this SkillRealizeManager self, int skillId)
        {
            //TODO 判断玩家自身状态是否可以使用技能（被控制等）
            var skillState = self.skillStateComponent.GetSkill(skillId);
            if (skillState == null)
            {
                Log.Debug($"该角色没有技能{skillId}");
                return;
            }
            //TODO 判断玩家是否可以支撑该技能的消耗，MP等
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
            //扣除消耗
            
            //进入冷却计算
            
            //回调技能
            
            //施加自身buff
            
            //施加目标buff
            
            //执行SkillAction
            
        }
    }
}