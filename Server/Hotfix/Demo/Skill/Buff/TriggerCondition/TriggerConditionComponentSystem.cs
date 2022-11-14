namespace ET
{
    public class TriggerConditionComponentAwakeSystem: AwakeSystem<TriggerConditionComponent>
    {
        public override void Awake(TriggerConditionComponent self)
        {
            TriggerConditionComponent.Instance = self;
            self.LoadTriggerConditions();
        }
    }

    public static class TriggerConditionComponentSystem
    {
        public static void LoadTriggerConditions(this TriggerConditionComponent self)
        {
            TriggerConditionFactory.CreateTriggerCondition(1);
            Log.Debug("加载triggercondition完成");
        }
    }
}