namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class Property: Entity, IAwake
    {
        public int Level;
        public int EXP;
        public int HpMax=1000;
        public int MpMax=1000;
        public int XpMax=1000;
        public int Hp=1000;
        public int Mp=1000;
        public int Xp=1000;
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