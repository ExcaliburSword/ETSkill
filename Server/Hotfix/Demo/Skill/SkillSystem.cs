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
            self.damageFormula = null;
            self.skillActionInTime = null;
        }
    }
}