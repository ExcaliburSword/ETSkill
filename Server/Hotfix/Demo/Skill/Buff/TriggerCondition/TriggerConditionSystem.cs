using System;

namespace ET
{
    public class TriggerConditionAwakeSystem : AwakeSystem<TriggerCondition,Func<bool>>
    {
        public override void Awake(TriggerCondition self, Func<bool> a)
        {
            self.Trigger=a;
        }
    }

    public static class TriggerConditionSystem
    {
        
    }
}