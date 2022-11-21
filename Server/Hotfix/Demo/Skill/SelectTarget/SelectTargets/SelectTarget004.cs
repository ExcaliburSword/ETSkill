using System.Buffers;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    /*
     *  选中目标的周围范围，或者鼠标指向的范围
     */
    [SelectTarget]
    [FriendClassAttribute(typeof(ET.Skill))]
    public class SelectTarget004 : ISelectTrget
    {
        public Unit[] Select(Unit ori, Skill skillEntity, Unit target, Vector3 targetPoint)
        {
            var num = skillEntity.maxEffectNum;
            Unit[] targets = ArrayPool<Unit>.Shared.Rent(num);
            List<Unit> targetsAround = new List<Unit>();
            int targetsNum = 0;
            Vector3 center = targetPoint;
            if (target!=null)
            {
                center = target.Position;
            }
            for (int i = 0; i < targetsAround.Count && targetsNum < num; i++)
            {
                if (Vector3.Distance(targetsAround[i].Position, center) < skillEntity.maxDistance)
                {
                    targets[targetsNum] = targetsAround[i];
                    targetsNum++;
                }
            }
            return targets;
        }
    }
}