namespace ET
{
    //挂在角色身上，管理所有触发类buff
    [ChildType(typeof(Buff))]
    public class TriggerBufferComponent : Entity , IAwake
    {
       
    }
}