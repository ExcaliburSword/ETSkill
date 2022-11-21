using System;
using UnityEngine;

namespace ET
{
    [MessageHandler]
    [FriendClassAttribute(typeof(ET.GateMapComponent))]
    public class C2M_UseSkillHandler : AMRpcHandler<C2M_UseSkill, M2C_UseSkill>
    {
        protected override async ETTask Run(Session session, C2M_UseSkill request, M2C_UseSkill response, Action reply)
        {
            var mapScene = Game.Scene.GetChild<Scene>(5);
            var unitComponent =mapScene.GetComponent<UnitComponent>();
            Log.Debug($"请求玩家，id{request.PlayerId},sceneId:{mapScene.Id}");
            Unit player = unitComponent.GetChild<Unit>(request.PlayerId);
            if (player==null)
            {
                Log.Error("没有找到玩家");
                return;
            }
            Unit targetUnit = null;
            if (request.TargetId > 0)
            {
                targetUnit = unitComponent.GetChild<Unit>(request.TargetId);
            }
            if (player.GetComponent<SkillRealizeManager>()==null)
            {
                Log.Error("玩家没有技能释放器");
                return;
            }
            int err = await player.GetComponent<SkillRealizeManager>().TryToRealizeSkill(request.SkillId,
                targetUnit,
                new Vector3(request.TargetPosX, request.TargetPosY, request.TargetPosZ));
            response.Error = err;
            reply();
        }
    }
}