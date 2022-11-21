using System.Buffers;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    /*
     * 自身周围
     */
    [SelectTarget]
    [FriendClassAttribute(typeof(ET.Skill))]
    public class SelectTarget003 : ISelectTrget
    {
        public Unit[] Select(Unit ori, Skill skillEntity, Unit target, Vector3 targetPoint)
        {
            var num = skillEntity.maxEffectNum;
            Unit[] targets = ArrayPool<Unit>.Shared.Rent(num);
            List<Unit> targetsAround = new List<Unit>();
            int targetsNum = 0;
            for (int i = 0; i < targetsAround.Count&&targetsNum<num; i++)
            {
                if (Vector3.Distance(targetsAround[i].Position, ori.Position) < skillEntity.maxDistance)
                {
                    targets[targetsNum] = targetsAround[i];
                    targetsNum++;
                }
            }
            return targets;
        }
    }
}