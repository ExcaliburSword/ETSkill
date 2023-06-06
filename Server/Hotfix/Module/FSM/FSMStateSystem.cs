using System;
using System.Collections.Generic;

namespace ET
{
    
    public class FSMStateAwakeSystem: AwakeSystem<FSMState,EFSMStateID,IFSMState>
    {
        public override void Awake(FSMState self, EFSMStateID stateID, IFSMState iState)
        {
            self.map = new Dictionary<EFSMTriggerID, EFSMStateID>();
            self.Triggers = new List<FSMTrigger>();
            self.iState = iState;
            self.iState.Init();
        }
    }
    [FriendClassAttribute(typeof(ET.FSMState))]
    public static class FSMStateSystem
    {
        public static void AddMap(this FSMState self, EFSMTriggerID triggerID, EFSMStateID stateID)
        {
            self.map.Add(triggerID, stateID);
            self.CreateTrigger(triggerID);
        }

        private static void CreateTrigger(this FSMState self, EFSMTriggerID triggerID)
        {
            Type type = Type.GetType("ET" + triggerID + "Trigger");
            FSMTrigger trigger = Activator.CreateInstance(type) as FSMTrigger;
            self.Triggers.Add(trigger);
        }

        public static void Reason(this FSMState self, FSMBase fsmBase)
        {
            for (int i = 0; i < self.Triggers.Count; i++)
            {
                if (self.Triggers[i].HandleTrigger())
                {
                    EFSMStateID stateID = self.map[self.Triggers[i].TriggaerID];
                    fsmBase.ChangeActiveState(stateID);
                    return;
                }
            }
        }
    }
}