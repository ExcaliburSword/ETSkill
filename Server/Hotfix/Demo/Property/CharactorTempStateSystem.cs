using ET.LG;

namespace ET
{
    [FriendClassAttribute(typeof(ET.CharactorTempState))]
    public static class CharactorTempStateSystem
    {
        public static void Init(this CharactorTempState self)
        {
            self.beAttacked.OnGetValue += self.beAttacked.OnGet_Over0;
            self.beAttacked.OnSetValue += self.beAttacked.OnSet_LeftBigger_int;
            self.attacked.OnGetValue += self.attacked.OnGet_Over0;
            self.attacked.OnSetValue += self.attacked.OnSet_LeftBigger_int;
            self.moved.OnGetValue += self.moved.OnGet_Over0;
            self.moved.OnSetValue += self.moved.OnSet_LeftBigger_int;
            self.canMove.OnGetValue += self.canMove.OnGet_Over0;
            self.canMove.OnSetValue += self.canMove.OnSet_LeftBigger_int;
            self.canAttack.OnGetValue += self.canAttack.OnGet_Over0;
            self.canAttack.OnSetValue += self.canAttack.OnSet_LeftBigger_int;
            self.canUseSkill.OnGetValue += self.canUseSkill.OnGet_Over0;
            self.canUseSkill.OnSetValue += self.canUseSkill.OnSet_LeftBigger_int;
            
            
        }
    }
}