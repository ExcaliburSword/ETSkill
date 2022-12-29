namespace ET
{
    public abstract class FSMTrigger
    {
        public EFSMTriggerID TriggaerID { set; get; }

        public FSMTrigger()
        {
            Init();
        }
        public abstract void Init();
        public abstract bool HandleTrigger();
    }
}