namespace ET
{
    public class SummonMonsterAwakeSystem: AwakeSystem<SummonComponent>
    {
        public override void Awake(SummonComponent self)
        {
            
        }
    }
   
    [FriendClassAttribute(typeof(ET.SummonComponent))]
    public static class SummonComponentSystem
    {
        //召唤一个怪物为召唤兽，如果已经有召唤兽则不能召唤
        public static bool SummonMonster(this SummonComponent self, Unit monster)
        {
            if (monster.Type != UnitType.Monster)
            {
                Log.Debug("目标不是怪物，不能召唤");
                return false;
            }

            if (self.GetComponent<Unit>() != null)
            {
                Log.Debug("你已经拥有了召唤兽，不能继续召唤");
                return false;
            }

            return self.AddSummon(monster);
        }

        //召唤一个新召唤兽，会清除之前的召唤兽
        public static bool SummonANew(this SummonComponent self, Unit summon)
        {
            if (self.GetComponent<Unit>() != null)
            {
               self.RemoveComponent<Unit>();
            }

            return self.AddSummon(summon);
        }
        
        //添加一个召唤兽，没有任何前置条件
        private static bool AddSummon(this SummonComponent self, Unit summon)
        {
            self.AddComponent(summon);
            summon.AddComponent<SummonTag,Unit>(self.GetParent<Unit>());
            return true;
        }
    }
}