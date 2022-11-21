using System;
using UnityEngine;

namespace ET
{
	[ActorMessageHandler]
	public class M2M_UnitTransferRequestHandler : AMActorRpcHandler<Scene, M2M_UnitTransferRequest, M2M_UnitTransferResponse>
	{
		protected override async ETTask Run(Scene scene, M2M_UnitTransferRequest request, M2M_UnitTransferResponse response, System.Action reply)
		{
			await ETTask.CompletedTask;
			UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
			Unit unit = request.Unit;
			
			unitComponent.AddChild(unit);
			unitComponent.Add(unit);

			foreach (Entity entity in request.Entitys)
			{
				unit.AddComponent(entity);
			}
			
			unit.AddComponent<MoveComponent>();
			unit.AddComponent<PathfindingComponent, string>(scene.Name);
			unit.Position = new Vector3(-10, 0, -10);
			
			unit.AddComponent<MailBoxComponent>();
			
			// 通知客户端创建My Unit
			M2C_CreateMyUnit m2CCreateUnits = new M2C_CreateMyUnit();
			m2CCreateUnits.Unit = UnitHelper.CreateUnitInfo(unit);
			MessageHelper.SendToClient(unit, m2CCreateUnits);
			
			// 加入aoi
			unit.AddComponent<AOIEntity, int, Vector3>(9 * 1000, unit.Position);

			response.NewInstanceId = unit.InstanceId;
			unit.AddComponent<Property>();//属性
			unit.AddComponent<CharactorTempState>();//临时状态
			unit.AddComponent<SkillStateComponent>();//拥有的技能列表
			unit.AddComponent<SkillRealizeManager>();//技能释放器
			unit.AddComponent<ContinueBuffComponent>();//持续buff管理
			unit.AddComponent<IntervalActionBuffComponent>();//间隔效果buff管理
			unit.AddComponent<IntervalChangeBuffComponent>();//间隔属性变化buff管理
			unit.AddComponent<TriggerBuffComponent>();//触发效果buff管理
			
			reply();
		}
	}
}