namespace ET
{
    //挂在角色身上，管理所有间隔时间触发Action的buff
    [ChildType(typeof(BuffState))]
    [ComponentOf(typeof(Unit))]
    public class IntervalActionBuffComponent: Entity ,IAwake
    {
        
    }
}