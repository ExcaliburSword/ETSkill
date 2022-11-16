namespace ET
{
    [ComponentOf(typeof(Scene))]
    [ChildType(typeof(SelectTarget))]
    public class SelectTargetComponent : Entity, IAwake
    {
        public static SelectTargetComponent Instance;
    }
}