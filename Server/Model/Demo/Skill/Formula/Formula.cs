using System;

namespace ET
{
    public class Formula : Entity,IAwake,IAwake<Func<Unit,Unit,Skill,int>>
    {
        public Func<Unit, Unit, Skill, int> FormulaAct;
    }
}