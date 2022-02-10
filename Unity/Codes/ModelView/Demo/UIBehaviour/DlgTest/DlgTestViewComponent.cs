
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgTestViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EGBackGroundRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGBackGroundRectTransform == null )
     			{
		    		this.m_EGBackGroundRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EGBackGround");
     			}
     			return this.m_EGBackGroundRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_EnterMapButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnterMapButton == null )
     			{
		    		this.m_E_EnterMapButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_EnterMap");
     			}
     			return this.m_E_EnterMapButton;
     		}
     	}

		public UnityEngine.UI.Image E_EnterMapImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnterMapImage == null )
     			{
		    		this.m_E_EnterMapImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_EnterMap");
     			}
     			return this.m_E_EnterMapImage;
     		}
     	}

		public UnityEngine.UI.Button Ebtn_testButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Ebtn_testButton == null )
     			{
		    		this.m_Ebtn_testButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Ebtn_test");
     			}
     			return this.m_Ebtn_testButton;
     		}
     	}

		public UnityEngine.UI.Image Ebtn_testImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Ebtn_testImage == null )
     			{
		    		this.m_Ebtn_testImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Ebtn_test");
     			}
     			return this.m_Ebtn_testImage;
     		}
     	}

		public UnityEngine.UI.Text ETextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ETextText == null )
     			{
		    		this.m_ETextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EText");
     			}
     			return this.m_ETextText;
     		}
     	}

		public ESCommonTestUi ESCommonTestUi
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_escommontestui == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ESCommonTestUi");
		    	   this.m_escommontestui = this.AddChild<ESCommonTestUi,Transform>(subTrans);
     			}
     			return this.m_escommontestui;
     		}
     	}

		public UnityEngine.UI.LoopHorizontalScrollRect ELoopScrollList_testLoopHorizontalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_testLoopHorizontalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_testLoopHorizontalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopHorizontalScrollRect>(this.uiTransform.gameObject,"ELoopScrollList_test");
     			}
     			return this.m_ELoopScrollList_testLoopHorizontalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EGBackGroundRectTransform = null;
			this.m_E_EnterMapButton = null;
			this.m_E_EnterMapImage = null;
			this.m_Ebtn_testButton = null;
			this.m_Ebtn_testImage = null;
			this.m_ETextText = null;
			this.m_escommontestui?.Dispose();
			this.m_escommontestui = null;
			this.m_ELoopScrollList_testLoopHorizontalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EGBackGroundRectTransform = null;
		private UnityEngine.UI.Button m_E_EnterMapButton = null;
		private UnityEngine.UI.Image m_E_EnterMapImage = null;
		private UnityEngine.UI.Button m_Ebtn_testButton = null;
		private UnityEngine.UI.Image m_Ebtn_testImage = null;
		private UnityEngine.UI.Text m_ETextText = null;
		private ESCommonTestUi m_escommontestui = null;
		private UnityEngine.UI.LoopHorizontalScrollRect m_ELoopScrollList_testLoopHorizontalScrollRect = null;
		public Transform uiTransform = null;
	}
}
