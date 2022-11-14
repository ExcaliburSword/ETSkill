namespace ET
{
    /*
     * 挂在角色身上，管理所有间隔时间触发属性变化的buff
     */
    [ChildType(typeof(Buff))]
    public class IntervalChangeBuffComponent: Entity ,IAwake
    {
        
    }
}