using System;

namespace ET
{
    public class SkillActionAwakeSystem: AwakeSystem<SkillAction, Action<Unit, Unit>>
    {
        public override void Awake(SkillAction self, Action<Unit, Unit> a)
        {
            self.act = a;
        }
    }
    public static class SkillActionSytem
    {
        
    }
}