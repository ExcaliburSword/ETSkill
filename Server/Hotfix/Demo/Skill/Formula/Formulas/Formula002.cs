namespace ET
{
    /*
     * 治愈术恢复生命值，治疗类返回负值，相当于负伤害
     */
    [Formula]
    public class Formula002 : IFormula
    {
        public int FormulaAct(Unit ori, Unit target, Skill skill)
        {
            return -100;
        }
    }
}