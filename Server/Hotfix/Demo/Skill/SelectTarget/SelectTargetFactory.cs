using System;
using UnityEngine;

namespace ET
{
    public static class SelectTargetFactory
    {
        public static SelectTarget CreateSelectTarget(int selectTypeId)
        {
            string className =  GetClassName(selectTypeId);
            Type type = Type.GetType(className);
            ISelectTrget ist = type.Assembly.CreateInstance(className) as ISelectTrget;
            return SelectTargetComponent.Instance.AddChildWithId<SelectTarget,Func<Unit,Skill,Unit,Vector3,Unit[]>>(selectTypeId, ist.Select);
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
            return "ET.SelectTarget" + s;
        }
    }
}