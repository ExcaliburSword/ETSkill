namespace ET
{
    //挂在角色身上，管理所有间隔时间触发Action的buff
    [ChildType(typeof(Buff))]
    public class IntervalActionBuffComponent: Entity ,IAwake
    {
        
    }
}