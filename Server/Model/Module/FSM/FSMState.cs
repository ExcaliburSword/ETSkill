using System;
using System.Collections.Generic;

namespace ET
{
    public  class FSMState: Entity,IAwake<EFSMStateID,IFSMState>
    {
        public EFSMStateID StateID;
        public IFSMState iState;
        public List<FSMTrigger> Triggers;
        public Dictionary<EFSMTriggerID, EFSMStateID> map;
        
    }
}