namespace ET
{
    /*
     * 召唤一个怪物成为自己的临时召唤兽
      */
     
    [SkillAction]
    public class SkillAction001: ISkillAction
    {
        public void Act(Unit ori, Unit target)
        {
            bool success = ori.GetComponent<SummonComponent>().SummonMonster(target);
            if (success)
            {
                
            }
            else
            {
                Log.Debug("召唤怪物失败");
            }
        }
    }
}