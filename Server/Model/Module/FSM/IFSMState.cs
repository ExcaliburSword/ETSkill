namespace ET
{
    public interface IFSMState
    {
         void Init();
         void EnterState();
         void ActionState();
         void ExitState();
    }
}