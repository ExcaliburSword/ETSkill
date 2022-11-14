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
            
        }
    }
}