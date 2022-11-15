namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class Property: Entity
    {
        public int Level;
        public int EXP;
        public int HpMax;
        public int MpMax;
        public int XpMax;
        public int Hp;
        public int Mp;
        public int Xp;
        public int HpRecover;
        public int MpRecover;
        public int MoveSpeed;
        public int Strength;
        public int Constitution;
        public int Intelligence;
        public int Sprit;
        public int AttributePoint;
        public int CriticalOdds;//分母1000
        public int CriticalDamages;//分母1000
        public int PhysicAttackMin;
        public int PhysicAttackMax;
        public int MagicAttackMin;
        public int MagicAttackMax;
        public int FireAttack;
        public int IceAttack;
        public int LightAttack;
        public int DarkAttack;
        public int PhysicDefence;
        public int MagicDefence;
        public int FireDefence;
        public int IceDefenc;
        public int LightDefence;
        public int DarkDefence;
        
    }
}