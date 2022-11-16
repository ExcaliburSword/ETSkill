namespace ET
{
    [FriendClassAttribute(typeof(ET.Skill))]
    public static class SkillFactory
    {
        public static Skill CreateSkill(int skillConfigId)
        {
            var cfg = SkillConfigCategory.Instance.Get(skillConfigId);
            Skill skill = new Skill();
           // skill.callBackSkillInTime = cfg.CallBackSkillId <= 0 ? null : CreateSkill(cfg.CallBackSkillId);
            skill.callBackSkillId = cfg.CallBackSkillId;
            skill.callBackSkillInTimePossibility = cfg.SkillProperty;
            skill.selectType = GetSelectTarget(cfg.ChoosType);
            skill.skillId = cfg.Id;
            skill.Id = skill.skillId;
            skill.skillName = cfg.Name;
            skill.skillLevel = cfg.Level;
            skill.mpCost = cfg.MPCost;
            skill.hpCost = cfg.HPCost;
            skill.XpCost = cfg.XPCost;
            skill.coldTime = cfg.ColdTime;
            skill.realizeTime = cfg.RealizeTime;
            skill.maxDistance = cfg.DamageDis;
            skill.damageFormula = GetFormula(cfg.DamageFormId);
            
            skill.skillActionInTimePossibility = cfg.ActionProper ;
            skill.skillActionInTime = GetSkillAction(cfg.ActionId);
            
            skill.buffPossibility = cfg.BuffProper;
            skill.buffId = cfg.BuffId;
            skill.targetBuffPossibility = cfg.TargetBuffProper;
            skill.targetBuffId = cfg.TargetBuffId;
            return skill;

        }

        private static Formula GetFormula(int formulaId)
        {
            if (formulaId<=0)
            {
                return null;
            }
            return FormulaComponent.Instance.GetChild<Formula>(formulaId);
        }

        private static SkillAction GetSkillAction(int skillActionId)
        {
            if (skillActionId<=0)
            {
                return null;
            }
            return SkillActionComponent.Instance.GetChild<SkillAction>(skillActionId);
        }

        private static Buff GetBuff(int buffId)
        {
            if (buffId<=0)
            {
                return null;
            }

            return BuffComponent.Instance.GetChild<Buff>(buffId);
        }

        private static SelectTarget GetSelectTarget(int selectTypeId)
        {
            if (selectTypeId<=0)
            {
                return null;
            }

            return SelectTargetComponent.Instance.GetChild<SelectTarget>(selectTypeId);
        }
        
    }
}