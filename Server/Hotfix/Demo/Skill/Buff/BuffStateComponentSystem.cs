namespace ET
{
    [FriendClassAttribute(typeof (ET.Buff))]
    [FriendClassAttribute(typeof (ET.BuffState))]
    public static class BuffStateComponentSystem
    {
        public static void ReduceBuffLeftTime(this BuffStateComponent self, int time)
        {

        }

        private static void RefreshBuffLeftTime(this BuffStateComponent self, int buffId)
        {

        }
//添加buff的方法写在这里不一定合适，ori参数也不一定有必要，以后再思考吧
        public static void AddBuff(this BuffStateComponent self, Unit ori, int buffId)
        {
            var buffState = self.GetBuffState(ori, buffId);
            var buffEntity = buffState.buffEntity;
            //buff叠加
            if (buffState.Count < buffEntity.MaxCount)
            {
                buffState.Count++;
            }
            //buff刷新时长
            if (buffEntity.Refresh)
            {
                buffState.RefreshTime();
            }



        }

        //获取buffstate，如果没有就创建一个
        private static BuffState GetBuffState(this BuffStateComponent self, Unit ori, int buffId)
        {
            Buff buffEntity = BuffComponent.Instance.GetChild<Buff>(buffId);
            BuffState buffState = null;
            switch (buffEntity.EffectType)
            {
                case BuffEffectType.Cintinue:
                    buffState = self.ContinueBuffs.GetChild<BuffState>(buffId);
                    break;
                case BuffEffectType.IntervalChange:
                    buffState = self.IntervalChangeBuffs.GetChild<BuffState>(buffId);
                    break;
                case BuffEffectType.IntervalAction:
                    buffState = self.IntervalActionBuffs.GetChild<BuffState>(buffId);
                    break;
                case BuffEffectType.Trigger:
                    buffState = self.TriggerBuffs.GetChild<BuffState>(buffId);
                    break;
                default:
                    Log.Debug("没有找到对应的buff类型");
                    break;
            }

            if (buffState == null)
            {
                buffState = BuffStateFactory.CreateBuffState(ori, buffId);
            }
            else
            {
                buffState.buffRealizer = ori;
            }

            return buffState;
        }
    }
}