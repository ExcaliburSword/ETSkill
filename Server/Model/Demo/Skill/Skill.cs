namespace ET
{
    
    public class Skill : Entity, IAwake,IDestroy
    {
        public  int skillId;
        public string skillName;
        public int skillLevel;
        public float coldTime;
        public float realizeTime;
        public int maxDistance;
        public SelectTarget selectType;
        public int mpCost;
        public int hpCost;
        public int XpCost;
        public Formula damageFormula;
        public int skillActionInTimePossibility;
        public SkillAction skillActionInTime;
        public int callBackSkillInTimePossibility;
       // public Skill callBackSkillInTime;//技能加载依赖其他技能，先读字段确定依赖技能id，先递归加载依赖技能
       public int callBackSkillId;
        public int buffPossibility;
        public int buffId;
        public int targetBuffPossibility;
        public int targetBuffId;

    }
}