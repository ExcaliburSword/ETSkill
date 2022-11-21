using System;
using UnityEngine;

namespace ET
{
    public static class UnitFactory
    {
        public static Unit Create(Scene scene, long id, UnitType unitType)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            switch (unitType)
            {
                case UnitType.Player:
                {
                    Unit unit = unitComponent.AddChildWithId<Unit, int>(id, 1001);
                    Log.Debug($"添加玩家，id{id},sceneId:{scene.Id}");
                    //ChildType测试代码 取消注释 编译Server.hotfix 可发现报错
                    //unitComponent.AddChild<Player, string>("Player");
                    unit.AddComponent<MoveComponent>();
                    unit.Position = new Vector3(-10, 0, -10);
			
                    NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
                    numericComponent.Set(NumericType.Speed, 6f); // 速度是6米每秒
                    numericComponent.Set(NumericType.AOI, 15000); // 视野15米
                    
                    unitComponent.Add(unit);
                    // 加入aoi
                    unit.AddComponent<AOIEntity, int, Vector3>(9 * 1000, unit.Position);

                    unit.AddComponent<Property>();//属性
                    unit.AddComponent<CharactorTempState>();//临时状态
                    unit.AddComponent<SkillStateComponent>();//拥有的技能列表
                    unit.AddComponent<SkillRealizeManager>();//技能释放器
                    unit.AddComponent<ContinueBuffComponent>();//持续buff管理
                    unit.AddComponent<IntervalActionBuffComponent>();//间隔效果buff管理
                    unit.AddComponent<IntervalChangeBuffComponent>();//间隔属性变化buff管理
                    unit.AddComponent<TriggerBuffComponent>();//触发效果buff管理
                    return unit;
                }
                default:
                    throw new Exception($"not such unit type: {unitType}");
            }
        }
    }
}