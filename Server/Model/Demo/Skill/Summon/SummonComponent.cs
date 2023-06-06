namespace ET
{
    [ComponentOf(typeof(Unit))]
    [ChildType(typeof(Unit))]
    public class SummonComponent: Entity  ,IAwake,IAwake<Unit>,IDestroy
    {
        
    }
}