using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public interface ISelectTrget
    {
        Unit[] Select(Unit ori, Skill skillEntity, Unit target, Vector3 targetPoint);
        
    }
}