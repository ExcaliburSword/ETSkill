using System;
using UnityEngine;

namespace ET
{
    public class SelectTargetAwakeSystem: AwakeSystem<SelectTarget,Func<Unit,Skill,Unit,Vector3,Unit[]>>
    {
        public override void Awake(SelectTarget self, Func<Unit, Skill, Unit, Vector3, Unit[]> selectFunc)
        {
            self.Select=selectFunc;
        }
    }

    public static  class SelectTargetSystem
    {
        
    }
}