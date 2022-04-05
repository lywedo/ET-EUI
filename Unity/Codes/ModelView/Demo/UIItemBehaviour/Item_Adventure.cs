
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class Scroll_Item_Adventure : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_Adventure BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Text ELabel_NameText
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
     				if( this.m_ELabel_NameText == null )
     				{
		    			this.m_ELabel_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_Name");
     				}
     				return this.m_ELabel_NameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_Name");
     			}
     		}
     	}

		public UnityEngine.UI.Text ELabel_LevelText
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
     				if( this.m_ELabel_LevelText == null )
     				{
		    			this.m_ELabel_LevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_Level");
     				}
     				return this.m_ELabel_LevelText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_Level");
     			}
     		}
     	}

		public UnityEngine.UI.Button EButton_enterButton
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
     				if( this.m_EButton_enterButton == null )
     				{
		    			this.m_EButton_enterButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_enter");
     				}
     				return this.m_EButton_enterButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_enter");
     			}
     		}
     	}

		public UnityEngine.UI.Image EButton_enterImage
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
     				if( this.m_EButton_enterImage == null )
     				{
		    			this.m_EButton_enterImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_enter");
     				}
     				return this.m_EButton_enterImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_enter");
     			}
     		}
     	}

		public UnityEngine.UI.Text ELabel_inAdventureTipText
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
     				if( this.m_ELabel_inAdventureTipText == null )
     				{
		    			this.m_ELabel_inAdventureTipText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_inAdventureTip");
     				}
     				return this.m_ELabel_inAdventureTipText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_inAdventureTip");
     			}
     		}
     	}

		public UnityEngine.UI.Text ELabel_notEnoughText
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
     				if( this.m_ELabel_notEnoughText == null )
     				{
		    			this.m_ELabel_notEnoughText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_notEnough");
     				}
     				return this.m_ELabel_notEnoughText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_notEnough");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ELabel_NameText = null;
			this.m_ELabel_LevelText = null;
			this.m_EButton_enterButton = null;
			this.m_EButton_enterImage = null;
			this.m_ELabel_inAdventureTipText = null;
			this.m_ELabel_notEnoughText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_ELabel_NameText = null;
		private UnityEngine.UI.Text m_ELabel_LevelText = null;
		private UnityEngine.UI.Button m_EButton_enterButton = null;
		private UnityEngine.UI.Image m_EButton_enterImage = null;
		private UnityEngine.UI.Text m_ELabel_inAdventureTipText = null;
		private UnityEngine.UI.Text m_ELabel_notEnoughText = null;
		public Transform uiTransform = null;
	}
}
