using System.Collections.Generic;

namespace ET
{
    public class SkillState: Entity,IAwake<int>,IDestroy
    {
        public Skill skillEntity;//技能引用
        private Unit _skillOwner; //技能拥有者

        public Unit SkillOwner
        {
            get
            {
                if (this._skillOwner==null)
                {
                    this._skillOwner = this.GetParent<SkillStateComponent>().GetParent<Unit>();
                }
                return this._skillOwner;
            }
        }
        public float coldTimeLeft;//剩余冷却时间
        public float prepareTimeAlready;//已经准备时间
        public Unit[] skillTargets; //技能目标列表

    }
}