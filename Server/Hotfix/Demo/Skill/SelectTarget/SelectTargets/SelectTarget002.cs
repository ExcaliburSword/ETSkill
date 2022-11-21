using System.Buffers;
using UnityEngine;

namespace ET
{
    /*
     * 选择锁定的单个
     */
    [SelectTarget]
    public class SelectTarget002: ISelectTrget
    {
        public Unit[] Select(Unit ori, Skill skillEntity, Unit target, Vector3 targetPoint)
        {
            Unit[] targets= ArrayPool<Unit>.Shared.Rent(1);
            targets[0] = target;
            return targets;
        }
    }
}