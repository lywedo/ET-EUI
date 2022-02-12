
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgServerViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button EBtn_EnterServerButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBtn_EnterServerButton == null )
     			{
		    		this.m_EBtn_EnterServerButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/EBtn_EnterServer");
     			}
     			return this.m_EBtn_EnterServerButton;
     		}
     	}

		public UnityEngine.UI.Image EBtn_EnterServerImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBtn_EnterServerImage == null )
     			{
		    		this.m_EBtn_EnterServerImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/EBtn_EnterServer");
     			}
     			return this.m_EBtn_EnterServerImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect ELoopScrollList_ServerListLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_ServerListLoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_ServerListLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Sprite_BackGround/ELoopScrollList_ServerList");
     			}
     			return this.m_ELoopScrollList_ServerListLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EBtn_EnterServerButton = null;
			this.m_EBtn_EnterServerImage = null;
			this.m_ELoopScrollList_ServerListLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_EBtn_EnterServerButton = null;
		private UnityEngine.UI.Image m_EBtn_EnterServerImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_ServerListLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
