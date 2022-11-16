namespace ET
{
    public class SelectTargetComponentAwakeSystem: AwakeSystem<SelectTargetComponent>
    {
        public override void Awake(SelectTargetComponent self)
        {
            SelectTargetComponent.Instance = self;
            self.LoadSelectTargets();
        }
    }

    public static class SelectTargetComponentSystem
    {
        public static void LoadSelectTargets(this SelectTargetComponent self)
        {
            int selectTypeId = 1;
            SelectTargetFactory.CreateSelectTarget(selectTypeId);
            Log.Debug("SelectTarget加载完成");
        }
    }
}