using System.Buffers;
using UnityEngine;

namespace ET
{
    /*
     * 选择自己
     */
    [SelectTarget]
    public class SelectTarget001: ISelectTrget
    {
        public Unit[] Select(Unit ori, Skill skillEntity, Unit target, Vector3 targetPoint)
        {
            Unit[] targets= ArrayPool<Unit>.Shared.Rent(1);
            targets[0] = ori;
            return targets;
        }
    }
}