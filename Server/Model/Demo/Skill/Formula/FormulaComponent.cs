namespace ET
{
    [ComponentOf(typeof(Scene))]
    [ChildType(typeof(Formula))]
    public class FormulaComponent: Entity,IAwake
    {
        public static FormulaComponent Instance;
        
    }
}