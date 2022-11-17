using System.Buffers;
using System.Collections.Generic;

namespace ET
{
    public class SkillStateAwakeSystem: AwakeSystem<SkillState,int>
    {
        public override void Awake(SkillState self, int skillId)
        {
           self.InitStateWithId(skillId);
        }
    }

    public class SkillStateDestroySystem: DestroySystem<SkillState>
    {
        public override void Destroy(SkillState self)
        {
            self.skillEntity = null;
        }
    }
    [FriendClassAttribute(typeof(ET.SkillState))]
    [FriendClassAttribute(typeof(ET.Skill))]
    public static class SkillStateSystem
    {
        public static void InitStateWithId(this SkillState self, int skillId)
        {
            self.skillEntity = SkillComponent.Instance.GetChild<Skill>(skillId);
            self.InitState();
        }

        public static void InitState(this SkillState self)
        {
            self.coldTimeLeft = self.skillEntity.coldTime;
            self.prepareTimeAlready = 0;
            if (self.skillTargets != null)
            {
                ArrayPool<Unit>.Shared.Return(self.skillTargets);
            }
        }
    }
}