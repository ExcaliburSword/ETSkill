namespace ET
{
    public static class SkillStateComponentSystem
    {
        public static bool HasSkill(this SkillStateComponent self,int skillId)
        {
            return self.GetChild<SkillState>(skillId) != null;
        }

        public static SkillState GetSkill(this SkillStateComponent self, int skillId)
        {
            return self.GetChild<SkillState>(skillId);
        }
    }
}