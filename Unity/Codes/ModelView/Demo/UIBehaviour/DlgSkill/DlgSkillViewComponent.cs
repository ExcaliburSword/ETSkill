
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgSkillViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_FireButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FireButton == null )
     			{
		    		this.m_E_FireButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Fire");
     			}
     			return this.m_E_FireButton;
     		}
     	}

		public UnityEngine.UI.Image E_FireImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FireImage == null )
     			{
		    		this.m_E_FireImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Fire");
     			}
     			return this.m_E_FireImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_FireButton = null;
			this.m_E_FireImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_FireButton = null;
		private UnityEngine.UI.Image m_E_FireImage = null;
		public Transform uiTransform = null;
	}
}
