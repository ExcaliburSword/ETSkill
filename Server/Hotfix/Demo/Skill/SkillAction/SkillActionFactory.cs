using System;

namespace ET
{
    public static class SkillActionFactory
    {
        public static SkillAction CreateSkillAction(int skillActionId)
        {
            string className =  GetClassName(skillActionId);
            Type type = Type.GetType(className);
            ISkillAction isa = type.Assembly.CreateInstance(className) as ISkillAction;
            return SkillActionComponent.Instance.AddChildWithId<SkillAction, Action<Unit, Unit>>(skillActionId, isa.Act);
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
            return "ET.SkillAction" + s;
        }
    }
}