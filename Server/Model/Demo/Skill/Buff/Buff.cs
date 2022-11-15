namespace ET
{
    public class Buff: Entity,IAwake<int>,IAwake
    {
        public int BuffId;
        public int BuffLevel;
        public int MaxCount;
        public BuffEffectType EffectType;
        public bool Refresh;
        public int BaseContinueTime;
        public int EffectIntervalTime;
        public TriggerCondition Condition;
        public SkillAction NormalAction;
        public int ActionColdTime;
        
        public int Index1;
        public int Index1ChangePercent;
        public int Index1ChangeAbsolute;
        
        public int Index2;
        public int Index2ChangePercent;
        public int Index2ChangeAbsolute;

        public int Index3;
        public int Index3ChangePercent;
        public int Index3ChangeAbsolute;

        public int Index4;
        public int Index4ChangePercent;
        public int Index4ChangeAbsolute;

        public int Index5;
        public int Index5ChangePercent;
        public int Index5ChangeAbsolute;

        public SkillAction BuffEndAction1;
        public SkillAction BuffEndAction2;
        

    }

    public enum BuffEffectType
    {
        Cintinue=0,
        IntervalChange=1,
        IntervalAction=2,
        Trigger=3,
    }
}