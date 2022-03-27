
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class Scroll_Item_RoleInfoAttribuite : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_RoleInfoAttribuite BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Text E_AttributeNameText
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
     				if( this.m_E_AttributeNameText == null )
     				{
		    			this.m_E_AttributeNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_AttributeName");
     				}
     				return this.m_E_AttributeNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_AttributeName");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_AttributeValueText
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
     				if( this.m_E_AttributeValueText == null )
     				{
		    			this.m_E_AttributeValueText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_AttributeValue");
     				}
     				return this.m_E_AttributeValueText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_AttributeValue");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_AttributeNameText = null;
			this.m_E_AttributeValueText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_E_AttributeNameText = null;
		private UnityEngine.UI.Text m_E_AttributeValueText = null;
		public Transform uiTransform = null;
	}
}
