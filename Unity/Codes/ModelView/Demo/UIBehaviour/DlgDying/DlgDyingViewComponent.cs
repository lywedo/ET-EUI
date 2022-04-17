
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgDyingViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EG_BgRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_BgRectTransform == null )
     			{
		    		this.m_EG_BgRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Bg");
     			}
     			return this.m_EG_BgRectTransform;
     		}
     	}

		public UnityEngine.UI.Text ELabel_CenterText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_CenterText == null )
     			{
		    		this.m_ELabel_CenterText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Bg/ELabel_Center");
     			}
     			return this.m_ELabel_CenterText;
     		}
     	}

		public UnityEngine.UI.Button EButton_BackButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_BackButton == null )
     			{
		    		this.m_EButton_BackButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_Back");
     			}
     			return this.m_EButton_BackButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_BackImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_BackImage == null )
     			{
		    		this.m_EButton_BackImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_Back");
     			}
     			return this.m_EButton_BackImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Text == null )
     			{
		    		this.m_ELabel_Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EButton_Back/ELabel_");
     			}
     			return this.m_ELabel_Text;
     		}
     	}

		public UnityEngine.UI.Button EButton_ReviveButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ReviveButton == null )
     			{
		    		this.m_EButton_ReviveButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_Revive");
     			}
     			return this.m_EButton_ReviveButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_ReviveImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ReviveImage == null )
     			{
		    		this.m_EButton_ReviveImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_Revive");
     			}
     			return this.m_EButton_ReviveImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_BgRectTransform = null;
			this.m_ELabel_CenterText = null;
			this.m_EButton_BackButton = null;
			this.m_EButton_BackImage = null;
			this.m_ELabel_Text = null;
			this.m_EButton_ReviveButton = null;
			this.m_EButton_ReviveImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_BgRectTransform = null;
		private UnityEngine.UI.Text m_ELabel_CenterText = null;
		private UnityEngine.UI.Button m_EButton_BackButton = null;
		private UnityEngine.UI.Image m_EButton_BackImage = null;
		private UnityEngine.UI.Text m_ELabel_Text = null;
		private UnityEngine.UI.Button m_EButton_ReviveButton = null;
		private UnityEngine.UI.Image m_EButton_ReviveImage = null;
		public Transform uiTransform = null;
	}
}
