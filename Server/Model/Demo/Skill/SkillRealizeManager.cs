namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class SkillRealizeManager: Entity
    {
        private SkillStateComponent _skillStateComponent;
        public SkillStateComponent skillStateComponent
        {
            get
            {
                if (_skillStateComponent==null)
                {
                    _skillStateComponent=this.GetParent<Unit>().GetComponent<SkillStateComponent>();
                }

                return this._skillStateComponent;
            }
        }
    }
}