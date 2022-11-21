namespace ET
{
    public class SkillComponentAwakeSystem: AwakeSystem<SkillComponent>
    {
        public override void Awake(SkillComponent self)
        {
            SkillComponent.Instance = self;
           self.LoadSkills();
        }
    }
    public static class SkillComponentSystem
    {
        public static void LoadSkills(this SkillComponent self)
        {
           var skillDic= SkillConfigCategory.Instance.GetAll();
           foreach (var skillid in skillDic.Keys)
           {
               self.AddChild(SkillFactory.CreateSkill(skillid));
               Log.Debug($"Skill{skillid}加载完成");
           }
           Log.Debug("Skill加载完成");
        }
    }
}