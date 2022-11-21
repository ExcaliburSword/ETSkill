using System;
using UnityEngine;

namespace ET
{
    public static class SkillHelper
    {
        public static async ETTask RequireUseSkill(Scene zoneScene, int skillId, int targetId, Vector3 mousePos)
        {
            Session session = zoneScene.GetComponent<SessionComponent>().Session;
            try
            {
                M2C_UseSkill  m2cUseSkill = (M2C_UseSkill)await session.Call(new C2M_UseSkill()
                {
                    PlayerId = zoneScene.GetComponent<PlayerComponent>().MyId,
                    SkillId = skillId,
                    TargetId = targetId,
                    TargetPosX = mousePos.x,
                    TargetPosY = mousePos.y,
                    TargetPosZ = mousePos.z,
                });
                var err = m2cUseSkill.Error;
                switch (err)
                {
                    case ErrorCode.ERR_SkillSuccess:
                        Log.Debug("技能释放成功");
                        break;
                    case ErrorCode.ERR_HasNoSkill:
                        Log.Debug("你没有这个技能");
                        break;
                    case ErrorCode.ERR_SkillCostNotEnough:
                        Log.Debug("技能消耗不足");
                        break;
                    case ErrorCode.ERR_BanSkillArea:
                        Log.Debug("此区域不能释放技能");
                        break;
                    case ErrorCode.ERR_BeSilenced:
                        Log.Debug("你被沉默了，不能释放技能");
                        break;
                    case ErrorCode.ERR_CantUseTarget:
                        Log.Debug("不能对该目标释放此技能");
                        break;
                    case ErrorCode.ERR_OutOfSkillRange:
                        Log.Debug("超出范围不能释放");
                        break;
                    case ErrorCode.ERR_SkillColding:
                        Log.Debug("技能冷却中");
                        break;
                    case ErrorCode.ERR_LosePlayerInfo:
                        Log.Debug("丢失玩家信息不能释放");
                        break;
                    case ErrorCode.ERR_SkillBroken:
                        Log.Debug("技能释放被打断了");
                        break;
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            } 
        }
    }
}