namespace ET
{
    /*
     * 服务器所有buff挂在这里
     */
    [ComponentOf(typeof(Scene))]
    [ChildType(typeof(Buff))]
    public class BuffComponent : Entity,IAwake
    {
        public static BuffComponent Instance;
    }
}