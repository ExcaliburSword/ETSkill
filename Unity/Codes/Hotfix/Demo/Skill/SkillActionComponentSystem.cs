namespace ET
{
    public class SkillActionComponentAwakeSystem: AwakeSystem<SkillActionComponent>
    {
        public override void Awake(SkillActionComponent self)
        {
            SkillActionComponent.Instance = self;
            self.LoadSkillActions();
        }
    }
    public static class SkillActionComponentSystem
    {
        public static void LoadSkillActions(this SkillActionComponent self)
        {
            
        }
    }
}