
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	public  class DlgRolesViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.InputField EInputNameInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInputNameInputField == null )
     			{
		    		this.m_EInputNameInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Sprite_BackGround/EInputName");
     			}
     			return this.m_EInputNameInputField;
     		}
     	}

		public UnityEngine.UI.Image EInputNameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInputNameImage == null )
     			{
		    		this.m_EInputNameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/EInputName");
     			}
     			return this.m_EInputNameImage;
     		}
     	}

		public UnityEngine.UI.Button ECreateRoleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ECreateRoleButton == null )
     			{
		    		this.m_ECreateRoleButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/ECreateRole");
     			}
     			return this.m_ECreateRoleButton;
     		}
     	}

		public UnityEngine.UI.Image ECreateRoleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ECreateRoleImage == null )
     			{
		    		this.m_ECreateRoleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/ECreateRole");
     			}
     			return this.m_ECreateRoleImage;
     		}
     	}

		public UnityEngine.UI.Button EBeginGameButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBeginGameButton == null )
     			{
		    		this.m_EBeginGameButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/EBeginGame");
     			}
     			return this.m_EBeginGameButton;
     		}
     	}

		public UnityEngine.UI.Image EBeginGameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBeginGameImage == null )
     			{
		    		this.m_EBeginGameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/EBeginGame");
     			}
     			return this.m_EBeginGameImage;
     		}
     	}

		public UnityEngine.UI.Button EDeleteRoleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EDeleteRoleButton == null )
     			{
		    		this.m_EDeleteRoleButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/EDeleteRole");
     			}
     			return this.m_EDeleteRoleButton;
     		}
     	}

		public UnityEngine.UI.Image EDeleteRoleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EDeleteRoleImage == null )
     			{
		    		this.m_EDeleteRoleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/EDeleteRole");
     			}
     			return this.m_EDeleteRoleImage;
     		}
     	}

		public UnityEngine.UI.LoopHorizontalScrollRect ELoopScrollList_RolesLoopHorizontalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_RolesLoopHorizontalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_RolesLoopHorizontalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopHorizontalScrollRect>(this.uiTransform.gameObject,"Sprite_BackGround/ELoopScrollList_Roles");
     			}
     			return this.m_ELoopScrollList_RolesLoopHorizontalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EInputNameInputField = null;
			this.m_EInputNameImage = null;
			this.m_ECreateRoleButton = null;
			this.m_ECreateRoleImage = null;
			this.m_EBeginGameButton = null;
			this.m_EBeginGameImage = null;
			this.m_EDeleteRoleButton = null;
			this.m_EDeleteRoleImage = null;
			this.m_ELoopScrollList_RolesLoopHorizontalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.InputField m_EInputNameInputField = null;
		private UnityEngine.UI.Image m_EInputNameImage = null;
		private UnityEngine.UI.Button m_ECreateRoleButton = null;
		private UnityEngine.UI.Image m_ECreateRoleImage = null;
		private UnityEngine.UI.Button m_EBeginGameButton = null;
		private UnityEngine.UI.Image m_EBeginGameImage = null;
		private UnityEngine.UI.Button m_EDeleteRoleButton = null;
		private UnityEngine.UI.Image m_EDeleteRoleImage = null;
		private UnityEngine.UI.LoopHorizontalScrollRect m_ELoopScrollList_RolesLoopHorizontalScrollRect = null;
		public Transform uiTransform = null;
	}
}
