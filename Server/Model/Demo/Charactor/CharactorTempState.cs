using ET.LG;

namespace ET
{
    /*
     * 记录角色常用状态，这些状态有倒计时，到时会自动清除（其实值不为正就是状态不存在了）
     */
    [ComponentOf(typeof(Unit))]
    public class CharactorTempState : Entity, IAwake
    {
        public const int MinLastTime = 50;
        public const int MaxLastTime = int.MaxValue;
        public BindableProperty<int> beAttacked=new BindableProperty<int>();
        public BindableProperty<int> moved = new BindableProperty<int>();
        public BindableProperty<int> attacked = new BindableProperty<int>();
        public BindableProperty<int> cantAttack = new BindableProperty<int>();
        public BindableProperty<int> cantMove = new BindableProperty<int>();
        public BindableProperty<int> cantUseSkill = new BindableProperty<int>();

        public bool ifBeAttacked => this.beAttacked.Value > 0;
        public bool ifMoved => this.moved.Value > 0;
        public bool ifAttacked => this.attacked.Value > 0;
        public bool ifCantAttacked => this.cantAttack.Value > 0;
        public bool ifCantMove => this.cantMove.Value > 0;
        public bool ifCantUseSkill => this.cantUseSkill.Value > 0;

    }
}