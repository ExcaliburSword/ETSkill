using System.Linq;

namespace ET
{
    public class FSMBaseAwakeSystem: AwakeSystem<FSMBase,EFSMStateID>
    {

        public override void Awake(FSMBase self, EFSMStateID stateID)
        {
            foreach (var state in self.states)
            {
                if ( state.StateID==stateID)
                {
                    self.currentState = state;
                    break;
                }
            }
                  
        }
    }

    public static class FSMBaseSystem
    {
        public static void ChangeActiveState(this FSMBase self, EFSMStateID stateID)
        {

        }

        public static void DoUpdate(this FSMBase self)
        {
            //判断条件
            self.currentState.Reason(self);
            //执行状态
            self.currentState.iState.ActionState();
        }
    }
}