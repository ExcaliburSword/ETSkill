using ET.LG;

namespace ET
{
    /*
     * 记录角色常用状态，这些状态有倒计时，到时会自动清除（其实值不为正就是状态不存在了）
     */
    public class CharactorTempState : Entity
    {
        public const int MinLastTime = 50;
        public const int MaxLastTime = int.MaxValue;
        public BindableProperty<int> beAttacked=new BindableProperty<int>();
        public BindableProperty<int> moved = new BindableProperty<int>();
        public BindableProperty<int> attacked = new BindableProperty<int>();
        public BindableProperty<int> canAttack = new BindableProperty<int>();
        public BindableProperty<int> canMove = new BindableProperty<int>();
        public BindableProperty<int> canUseSkill = new BindableProperty<int>();
        
    }
}