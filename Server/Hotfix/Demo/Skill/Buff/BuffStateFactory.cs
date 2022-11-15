namespace ET
{
    [FriendClassAttribute(typeof(ET.BuffState))]
    [FriendClassAttribute(typeof(ET.Buff))]
    [FriendClassAttribute(typeof(ET.Property))]
    public static class BuffStateFactory
    {
        public static BuffState CreateBuffState(Unit ori, int buffId)
        {
            BuffState buffState = new BuffState();
            buffState.buffEntity = BuffComponent.Instance.GetChild<Buff>(buffId);
            buffState.buffRealizer = ori;
            //这里的持续时间乱写的，只是为了表明可以受到buff释放者的影响
            buffState.RefreshTime();
            buffState.Count = 1;
            return buffState;
        }
    }
}