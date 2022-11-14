namespace ET
{
    [ComponentOf(typeof(Scene))]
    [ChildType(typeof(SkillAction))]
    public class SkillActionComponent: Entity,IAwake
    {
        public static SkillActionComponent Instance;
    }
}