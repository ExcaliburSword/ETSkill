using UnityEngine;

namespace ET
{
    public interface ISummonAI
    {
        void Excute(SkillState skillState, Unit target, Vector3 pos);
    }
}