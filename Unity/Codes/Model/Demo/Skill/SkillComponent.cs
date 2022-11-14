namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class SkillComponent : Entity,IAwake
    {
        public static SkillComponent Instance;
    }
}