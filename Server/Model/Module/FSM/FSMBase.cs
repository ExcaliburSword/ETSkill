using System.Collections.Generic;

namespace ET
{
    public class FSMBase: Entity,IAwake<EFSMStateID>
    {
        public List<FSMState> states;
        public FSMState currentState;
    }
}