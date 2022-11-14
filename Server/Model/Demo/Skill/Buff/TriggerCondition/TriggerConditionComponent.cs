namespace ET
{
    [ChildType(typeof(TriggerCondition))]
    [ComponentOf(typeof(Scene))]
    public class TriggerConditionComponent : Entity,IAwake
    {
        public static TriggerConditionComponent Instance;
    }
}