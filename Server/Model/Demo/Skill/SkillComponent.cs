namespace ET
{
    [ComponentOf(typeof(Scene))]
    [ChildType(typeof(Skill))]
    public class SkillComponent : Entity,IAwake
    {
        public static SkillComponent Instance;
    }
}