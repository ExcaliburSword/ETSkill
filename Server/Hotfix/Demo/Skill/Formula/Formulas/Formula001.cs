namespace ET
{
    /*
     * 火球术伤害计算,伤害类技能返回正值，治疗类返回正值
     */
    [Formula]
    public class Formula001: IFormula
    {
        public int FormulaAct(Unit ori, Unit target, Skill skill)
        {
            return 100;
        }
    }
}