using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	[FriendClass(typeof(DlgSkill))]
	public static  class DlgSkillSystem
	{

		public static void RegisterUIEvent(this DlgSkill self)
		{
		 self.View.E_FireButton.AddListener(self.UseSkill);
		}

		public static void ShowWindow(this DlgSkill self, Entity contextData = null)
		{
		}

		public static void UseSkill(this DlgSkill self)
		{
			 SkillHelper.RequireUseSkill(
				 self.ZoneScene(),
				 100010,
				 0,
				new Vector3(1,1,1)
				).Coroutine();
		}

	}
}
