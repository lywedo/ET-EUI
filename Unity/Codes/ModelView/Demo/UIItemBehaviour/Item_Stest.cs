
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class Scroll_Item_Stest : Entity,IAwake,IDestroy 
	{
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_Stest BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Image EImage_ServerTestImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_EImage_ServerTestImage == null )
     				{
		    			this.m_EImage_ServerTestImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EImage_ServerTest");
     				}
     				return this.m_EImage_ServerTestImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EImage_ServerTest");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( this.m_ETextText == null )
     				{
		    			this.m_ETextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EText");
     				}
     				return this.m_ETextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EText");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EImage_ServerTestImage = null;
			this.m_ETextText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_EImage_ServerTestImage = null;
		private UnityEngine.UI.Text m_ETextText = null;
		public Transform uiTransform = null;
	}
}
