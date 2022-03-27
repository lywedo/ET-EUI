
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class ES_AttributeItem : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Text E_AttribuiteNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AttribuiteNameText == null )
     			{
		    		this.m_E_AttribuiteNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_AttribuiteName");
     			}
     			return this.m_E_AttribuiteNameText;
     		}
     	}

		public UnityEngine.UI.Text E_AttribuiteValueText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AttribuiteValueText == null )
     			{
		    		this.m_E_AttribuiteValueText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_AttribuiteValue");
     			}
     			return this.m_E_AttribuiteValueText;
     		}
     	}

		public UnityEngine.UI.Button E_AddButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AddButton == null )
     			{
		    		this.m_E_AddButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Add");
     			}
     			return this.m_E_AddButton;
     		}
     	}

		public UnityEngine.UI.Image E_AddImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AddImage == null )
     			{
		    		this.m_E_AddImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Add");
     			}
     			return this.m_E_AddImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_AttribuiteNameText = null;
			this.m_E_AttribuiteValueText = null;
			this.m_E_AddButton = null;
			this.m_E_AddImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_E_AttribuiteNameText = null;
		private UnityEngine.UI.Text m_E_AttribuiteValueText = null;
		private UnityEngine.UI.Button m_E_AddButton = null;
		private UnityEngine.UI.Image m_E_AddImage = null;
		public Transform uiTransform = null;
	}
}
