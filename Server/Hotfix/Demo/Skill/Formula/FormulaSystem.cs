using System;

namespace ET
{
    public class FormulaAwakeSystem: AwakeSystem<Formula,Func<Unit,Unit,Skill,int>>
    {
        public override void Awake(Formula self, Func<Unit, Unit, Skill, int> a)
        {
            self.FormulaAct = a;
        }
    }

    public static class FormulaSystem
    {
        
    }
}