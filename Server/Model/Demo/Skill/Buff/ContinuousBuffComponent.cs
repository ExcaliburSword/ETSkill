namespace ET
{
    //挂在角色身上，管理角色计算属性时的增益和减益buff
    [ChildType(typeof(Buff))]
    public class ContinuousBuffComponent : Entity ,IAwake
    {
        
    }
}