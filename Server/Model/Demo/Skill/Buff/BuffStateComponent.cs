namespace ET
{
    [ComponentOf(typeof(Unit))]
    [ChildType(typeof(BuffState))]
    public class BuffStateComponent : Entity, IAwake
    {
        private ContinueBuffComponent _continueBuffs;
        private IntervalActionBuffComponent _intervalActionBuffs;
        private IntervalChangeBuffComponent _intervalChangeBuffs;
        private TriggerBuffComponent _triggerBuffs;

        public ContinueBuffComponent ContinueBuffs
        {
            get
            {
                if (_continueBuffs==null)
                {
                    this._continueBuffs = this.GetParent<Unit>().GetComponent<ContinueBuffComponent>();
                }

                return this._continueBuffs;
            }
        }
        public IntervalActionBuffComponent IntervalActionBuffs
        {
            get
            {
                if (_intervalActionBuffs==null)
                {
                    this._intervalActionBuffs = this.GetParent<Unit>().GetComponent<IntervalActionBuffComponent>();
                }

                return this._intervalActionBuffs;
            }
        }
        public IntervalChangeBuffComponent IntervalChangeBuffs
        {
            get
            {
                if (_intervalChangeBuffs==null)
                {
                    this._intervalChangeBuffs = this.GetParent<Unit>().GetComponent<IntervalChangeBuffComponent >();
                }

                return this._intervalChangeBuffs;
            }
        }
        public TriggerBuffComponent TriggerBuffs
        {
            get
            {
                if (_triggerBuffs==null)
                {
                    this._triggerBuffs = this.GetParent<Unit>().GetComponent<TriggerBuffComponent>();
                }

                return this._triggerBuffs;
            }
        }
        
        public Unit BuffOwner => this.GetParent<Unit>();
    }
}