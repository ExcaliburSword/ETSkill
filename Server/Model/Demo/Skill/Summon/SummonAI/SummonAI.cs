using System;
using UnityEngine;

namespace ET
{
    public class SummonAI: Entity
    {
        public Action<SkillState, Unit, Vector3> AIExcute;
    }
}