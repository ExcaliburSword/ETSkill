namespace ET
{
    public class BuffComponentAwakeSystem: AwakeSystem<BuffComponent>
    {
        public override void Awake(BuffComponent self)
        {
            BuffComponent.Instance = self;
            self.LoadBuffs();
        }
    }
    public static class BuffComponentSystem
    {
        public static void LoadBuffs(this BuffComponent self)
        {
            var buffIds= BuffConfigCategory.Instance.GetAll().Keys;
            foreach (var buffId in buffIds)
            {
                BuffFactory.CreateBuff(buffId);
            }
            Log.Debug("Buff加载完成");
        }
    }
}