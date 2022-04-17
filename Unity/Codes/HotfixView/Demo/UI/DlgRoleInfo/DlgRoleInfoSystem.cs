using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgRoleInfoSystem
	{

		public static void RegisterUIEvent(this DlgRoleInfo self)
		{
			self.RegisterCloseEvent<DlgRoleInfo>(self.View.E_CloseButton);
			self.View.ES_AttributeItem.RegisterEvent(NumericType.Power);
			self.View.ES_AttributeItem1.RegisterEvent(NumericType.PhysicalStrength);
			self.View.ES_AttributeItem2.RegisterEvent(NumericType.Agile);
			self.View.ES_AttributeItem3.RegisterEvent(NumericType.Spirit);
			self.View.E_AttribuitesLoopVerticalScrollRect.AddItemRefreshListener(((Transform transform, int index) => { self.OnAttributeItemRefreshHandler(transform, index);}));
			self.View.EButton_UpLevelButton.AddListenerAsync(self.OnUpRoleLevelHandler);
			
			RedDotHelper.AddRedDotNodeView(self.ZoneScene(), "UpLevelButton", self.View.EButton_UpLevelButton.gameObject, Vector3.one, new Vector3(115f, 10f, 0));
			RedDotHelper.AddRedDotNodeView(self.ZoneScene(), "AddAttribute", self.View.E_AttributePointText.gameObject, new Vector3(0.5f, 0.5f, 1), new Vector3(-17, 10f, 0.5f));
		}

		public static void OnUnloadWindow(this DlgRoleInfo self)
		{
			RedDotMonoView redDotMonoView = self.View.EButton_UpLevelButton.gameObject.GetComponent<RedDotMonoView>();
			RedDotHelper.RemoveRedDotView(self.ZoneScene(), "UpLevelButton", out redDotMonoView);

			redDotMonoView = self.View.E_AttributePointText.gameObject.GetComponent<RedDotMonoView>();
			RedDotHelper.RemoveRedDotView(self.ZoneScene(), "AddAttribute", out redDotMonoView);
		}

		public static void ShowWindow(this DlgRoleInfo self, Entity contextData = null)
		{
			self.Refresh();
		}

		public static void Refresh(this DlgRoleInfo self)
		{
			self.View.ES_AttributeItem.Refresh(NumericType.Power);
			self.View.ES_AttributeItem1.Refresh(NumericType.PhysicalStrength);
			self.View.ES_AttributeItem2.Refresh(NumericType.Agile);
			self.View.ES_AttributeItem3.Refresh(NumericType.Spirit);

			NumericComponent numericComponent = UnitHelper.GetMyUnitNumericComponent(self.ZoneScene().CurrentScene());
			self.View.E_CombatEffectivenessText.text = "战力值：" + numericComponent.GetAsLong(NumericType.CombatEffectiveness);
			self.View.E_AttributePointText.text = numericComponent.GetAsInt(NumericType.AttributePoint).ToString();
			
			int count = PlayerNumericConfigCategory.Instance.GetShowConfigCount();
			self.AddUIScrollItems(ref self.ScrollItemAttributes, count);
			self.View.E_AttribuitesLoopVerticalScrollRect.SetVisible(true, count);
		}

		public static void OnAttributeItemRefreshHandler(this DlgRoleInfo self, Transform transform, int index)
		{
			Scroll_Item_RoleInfoAttribuite scrollItemRoleInfoAttribuite = self.ScrollItemAttributes[index].BindTrans(transform);
			PlayerNumericConfig config = PlayerNumericConfigCategory.Instance.GetConfigByIndex(index);
			scrollItemRoleInfoAttribuite.E_AttributeNameText.text = config.Name + ":";
			scrollItemRoleInfoAttribuite.E_AttributeValueText.text = config.isPercent == 0?
					UnitHelper.GetMyUnitNumericComponent(self.ZoneScene().CurrentScene()).GetAsLong(config.Id).ToString() :
					$"{UnitHelper.GetMyUnitNumericComponent(self.ZoneScene().CurrentScene()).GetAsFloat(config.Id)}%";
		}

		public static async ETTask OnUpRoleLevelHandler(this DlgRoleInfo self)
		{
			try
			{
				int errorCode = await NumericHelper.RequestUpRoleLevel(self.ZoneScene());
				if (errorCode != ErrorCode.ERR_Success)
				{
					return;
				}
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
			}
		}

	}
}
