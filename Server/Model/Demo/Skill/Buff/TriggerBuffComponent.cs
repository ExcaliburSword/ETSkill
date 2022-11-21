namespace ET
{
    //挂在角色身上，管理所有触发类buff
    [ChildType(typeof(BuffState))]
    [ComponentOf(typeof(Unit))]
    public class TriggerBuffComponent : Entity , IAwake
    {
       
    }
}