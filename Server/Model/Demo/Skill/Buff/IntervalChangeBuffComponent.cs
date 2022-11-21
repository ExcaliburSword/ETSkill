namespace ET
{
    /*
     * 挂在角色身上，管理所有间隔时间触发属性变化的buff
     */
    [ChildType(typeof(BuffState))]
    [ComponentOf(typeof(Unit))]
    public class IntervalChangeBuffComponent: Entity ,IAwake
    {
        
    }
}