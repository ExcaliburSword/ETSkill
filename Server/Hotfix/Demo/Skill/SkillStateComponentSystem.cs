using System;

namespace ET
{
    public class SkillStateComponentAwakeSystem: AwakeSystem<SkillStateComponent>
    {
        public override void Awake(SkillStateComponent self)
        {
            self.AddChildWithId<SkillState,int>(100010,100010);
            self.AddChildWithId<SkillState,int>(100020,100020);
            self.AddChildWithId<SkillState,int>(100030,100030);
            self.AddChildWithId<SkillState,int>(100040,100040);
        }
    }
public class SkillStateComponentUpdateSystem: UpdateSystem<SkillStateComponent>
{
    public override void Update(SkillStateComponent self)
    {
        int deltaTime =(int)TimeHelper.DeltaTimeMilliSecond;
        foreach (var skillState in self.Children.Values)
        {
            (skillState as SkillState).ChangeTime(deltaTime);
        }
    }
}

public static class SkillStateComponentSystem
    {
        public static bool HasSkill(this SkillStateComponent self,int skillId)
        {
            return self.GetChild<SkillState>(skillId) != null;
        }

        public static SkillState GetSkill(this SkillStateComponent self, int skillId)
        {
            return self.GetChild<SkillState>(skillId);
        }
    }
}