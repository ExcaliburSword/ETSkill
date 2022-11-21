
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgSkillViewComponentAwakeSystem : AwakeSystem<DlgSkillViewComponent> 
	{
		public override void Awake(DlgSkillViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgSkillViewComponentDestroySystem : DestroySystem<DlgSkillViewComponent> 
	{
		public override void Destroy(DlgSkillViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
