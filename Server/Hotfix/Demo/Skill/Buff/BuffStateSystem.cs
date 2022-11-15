namespace ET
{
    [FriendClassAttribute(typeof(ET.Buff))]
    [FriendClassAttribute(typeof(ET.BuffState))]
    [FriendClassAttribute(typeof(ET.Property))]
    public static class BuffStateSystem
    {
        public static void RefreshTime(this BuffState self)
        {
            self.buffTimeLeft = self.buffEntity.BaseContinueTime + self.buffEntity.BuffLevel * self.buffRealizer.GetComponent<Property>().Level;
        }
    }
}