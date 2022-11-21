using ET.EventType;

namespace ET
{
    public class EnterMapFinishHandler_ShowSkillWindow : AEventAsync<EnterMapFinish>
    {
        protected override async ETTask Run(EnterMapFinish a)
        {
            var  zoneScene=a.ZoneScene;
            await zoneScene.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Skill);
        }
    }
}