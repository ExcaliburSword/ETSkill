namespace ET
{
    public interface IFSMTrigger
    {
        void Init();
        bool HandleTrigger();
    }
}