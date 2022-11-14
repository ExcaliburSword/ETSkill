namespace ET
{
    public class SkillDestroySystem : DestroySystem<Skill>
    {
        public override void Destroy(Skill self)
        {
            self.OnDestroy();
        }
    }
    [FriendClassAttribute(typeof(ET.Skill))]
    public static class SkillSystem
    {
        public static void OnDestroy(this Skill self)
        {
            if (self.callBackSkillInTime!=null)
            {
                self.callBackSkillInTime.OnDestroy();
            }
            self.callBackSkillInTime = null;
            self.damageFormula = null;
            self.skillActionInTime = null;
            self.buff = null;
            self.targetBuff = null;
        }
    }
}