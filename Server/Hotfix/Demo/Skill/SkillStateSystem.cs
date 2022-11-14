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
    public static class SkillStateSystem
    {
        public static void InitStateWithId(this SkillState self, int skillId)
        {
            self.skillEntity = SkillComponent.Instance.GetChild<Skill>(skillId);
            self.InitState();
        }

        public static void InitState(this SkillState self)
        {
            self.coldTimeLeft = 0;
            self.prepareTimeAlready = 0;
            if ( self.skillTargets ==null)
            {
                self.skillTargets = new List<Unit>();
            }
            self.skillTargets.Clear();
        }
    }
}