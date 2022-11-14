using System;

namespace ET
{
    public class TriggerCondition : Entity, IAwake<Func<bool>>
    {
        public Func<bool> Trigger;
    }
}