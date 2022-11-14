using System;

namespace ET
{
    [ChildType()]
    public class SkillAction : Entity,IAwake<Action<Unit,Unit>>
    {
        public Action<Unit, Unit> act;
    }
}