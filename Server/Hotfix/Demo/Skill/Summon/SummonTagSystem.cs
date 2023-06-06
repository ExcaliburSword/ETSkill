namespace ET
{
    public class SummonTagAwakeSystem: AwakeSystem<SummonTag,Unit>
    {
        public override void Awake(SummonTag self, Unit a)
        {
            self.Owner=a;
        }
    }

    public class SummonTagDestroySystem: DestroySystem<SummonTag>
    {
        public override void Destroy(SummonTag self)
        {
            self.Owner = null;
        }
    }
    [FriendClassAttribute(typeof(ET.SummonTag))]
    public static class SummonTagSystem
    {
      
    }
}