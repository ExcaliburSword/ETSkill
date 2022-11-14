using System;

namespace ET
{
    public static class TriggerConditionFactory
    {
        public static TriggerCondition CreateTriggerCondition(int conditionId)
        {
            string className =  GetClassName(conditionId);
            Type type = Type.GetType(className);
            ITriggerCondition isa = type.Assembly.CreateInstance(className) as ITriggerCondition;
            return TriggerConditionComponent.Instance.AddChildWithId<TriggerCondition, Func<bool>>(conditionId, isa.Trigger);
        }
        private static string GetClassName(int skillActionId)
        {
            string s = skillActionId.ToString();
            if (s.Length == 1)
            {
                s = "00" + s;
            }

            if (s.Length == 2)
            {
                s = "0" + s;
            }
            return "ET.TriggerCondition" + s;
        }
    }
    
}