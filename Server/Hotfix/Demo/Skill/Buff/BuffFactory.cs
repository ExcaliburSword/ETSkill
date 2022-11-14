namespace ET
{
    [FriendClassAttribute(typeof(ET.Buff))]
    public static class BuffFactory
    {
        public static Buff CreateBuff(int buffId)
        {
            var bfc = BuffConfigCategory.Instance.Get(buffId);
            Buff buf=BuffComponent.Instance.AddChildWithId<Buff>(buffId);
           
            buf.BuffId = bfc.Id;
            buf.BuffLevel = bfc.Level;
            buf.MaxCount = bfc.MaxCount;
            buf.EffectType = bfc.EffectType;
            buf.Refresh = bfc.Refresh>0;
            buf.BaseContinueTime = bfc.BaseContinueTime;
            buf.EffectIntervalTime = bfc.IntervalTime;
            if (bfc.TriggerConditionId>0)
            {
                buf.Condition = TriggerConditionComponent.Instance.GetChild<TriggerCondition>(bfc.TriggerConditionId);
            }
            buf.NormalAction = SkillActionComponent.Instance.GetChild<SkillAction>(bfc.NormalActionId);
            buf.ActionColdTime = bfc.TriggerColdTime;

            buf.Index1 = bfc.Index1;
            buf.Index1ChangePercent = bfc.Percent1;
            buf.Index1ChangeAbsolute = bfc.Absolute1;
            
            buf.Index2 = bfc.Index2;
            buf.Index2ChangePercent = bfc.Percent2;
            buf.Index2ChangeAbsolute = bfc.Absolute2;
            
            buf.Index3 = bfc.Index3;
            buf.Index3ChangePercent = bfc.Percent3;
            buf.Index3ChangeAbsolute = bfc.Absolute3;
            
            buf.Index4 = bfc.Index4;
            buf.Index4ChangePercent = bfc.Percent4;
            buf.Index4ChangeAbsolute = bfc.Absolute4;
            
            buf.Index5 = bfc.Index5;
            buf.Index5ChangePercent = bfc.Percent5;
            buf.Index5ChangeAbsolute = bfc.Absolute5;

            if (bfc.BuffEndAction1>0)
            {
                buf.BuffEndAction1 = SkillActionComponent.Instance.GetChild<SkillAction>(bfc.BuffEndAction1);
            }

            if (bfc.BuffEndAction2>0)
            {
                buf.BuffEndAction2 = SkillActionComponent.Instance.GetChild<SkillAction>(bfc.BuffEndAction2);
            }
            
            return buf;
        }
    }
}