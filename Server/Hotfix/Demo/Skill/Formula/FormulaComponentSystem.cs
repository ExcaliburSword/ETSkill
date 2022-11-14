using System;

namespace ET
{
    public class FormulaComponentAwakeSystem : AwakeSystem<FormulaComponent>
    {
        public override void Awake(FormulaComponent self)
        {
            FormulaComponent.Instance=self;
            self.LoadFormulas();
        }
    }

    public static class FormulaComponentSystem
    {
        public static void LoadFormulas(this FormulaComponent self)
        {
            string s = "";
            string className = "";
            int tempId = 1; 
            GetClassName(tempId);
            Type type = Type.GetType(className);
            IFormula ifm = type.Assembly.CreateInstance(className) as IFormula;
            FormulaComponent.Instance.AddChildWithId<Formula, Func<Unit,Unit,Skill,int>>(tempId, ifm.FormulaAct);

            void GetClassName(int formulaId)
            {
                s = formulaId.ToString();
                if (s.Length == 1)
                {
                    s = "00" + s;
                }

                if (s.Length == 2)
                {
                    s = "0" + s;
                }

                className = "ET.Formula" + s;
            }
            Log.Debug("formulas加载完成");
        }
    }
}