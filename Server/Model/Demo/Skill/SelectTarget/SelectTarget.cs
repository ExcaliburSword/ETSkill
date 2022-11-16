using System;
using UnityEngine;

namespace ET
{
    public class SelectTarget : Entity ,IAwake< Func<Unit, Skill, Unit, Vector3, Unit[]> >
    {
        public Func<Unit, Skill, Unit, Vector3, Unit[]> Select;
    }
}