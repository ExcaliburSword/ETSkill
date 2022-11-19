using ET.LG;

namespace ET
{
    public class CharactorTempStateAwakeSystem: AwakeSystem<CharactorTempState>
    {
        public override void Awake(CharactorTempState self)
        {
            self.Init();
        }
    }

    [FriendClassAttribute(typeof(ET.CharactorTempState))]
    public static class CharactorTempStateSystem
    {
        public static void Init(this CharactorTempState self)
        {
            RegistSetGet(self.beAttacked);
            RegistSetGet(self.attacked);
            RegistSetGet(self.moved);
            RegistSetGet(self.cantMove);
            RegistSetGet(self.cantAttack);
            RegistSetGet(self.cantUseSkill);
            
            void RegistSetGet(BindableProperty<int> bpi)
            {
                bpi.RegistGet(bpi.OnGet_Over0).RegistSet(bpi.OnSet_LeftBigger);
            }
        }
    }
}