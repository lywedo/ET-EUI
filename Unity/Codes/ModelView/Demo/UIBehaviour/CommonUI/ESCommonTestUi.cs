
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class ESCommonTestUi : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Image EImageImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImageImage == null )
     			{
		    		this.m_EImageImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EImage");
     			}
     			return this.m_EImageImage;
     		}
     	}

		public UnityEngine.UI.Text ELableText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELableText == null )
     			{
		    		this.m_ELableText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELable");
     			}
     			return this.m_ELableText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EImageImage = null;
			this.m_ELableText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_EImageImage = null;
		private UnityEngine.UI.Text m_ELableText = null;
		public Transform uiTransform = null;
	}
}
