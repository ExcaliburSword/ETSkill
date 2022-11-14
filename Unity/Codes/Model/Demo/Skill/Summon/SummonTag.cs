namespace ET
{
    //挂在怪物身上表面它现在是召唤兽
    [ComponentOf()]
    public class SummonTag : Entity, IAwake<Unit>,IDestroy
    {
        public Unit Owner;
    }
}