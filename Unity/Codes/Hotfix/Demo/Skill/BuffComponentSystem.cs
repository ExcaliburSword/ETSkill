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
            
        }
    }
}