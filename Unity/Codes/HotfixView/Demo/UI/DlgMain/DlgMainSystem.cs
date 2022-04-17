using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgMainSystem
	{

		public static void RegisterUIEvent(this DlgMain self)
		{
			self.View.E_RoleButton.AddListenerAsync(() => { return self.OnRoleButtonClickHandler();});
			self.View.E_AdventureButton.AddListenerAsync(() => { return self.OnAdventureClickHandler();});
			RedDotHelper.AddRedDotNodeView(self.ZoneScene(), "Role", self.View.E_RoleButton.gameObject, Vector3.one, new Vector3(75, 55, 0));
		}

		public static void OnUnloadWindow(this DlgMain self)
		{
			RedDotMonoView redDotMonoView = self.View.E_RoleButton.GetComponent<RedDotMonoView>();
			RedDotHelper.RemoveRedDotView(self.ZoneScene(), "Role", out redDotMonoView);
		}

		public static void ShowWindow(this DlgMain self, Entity contextData = null)
		{
			self.Refresh().Coroutine();
		}

		public static async ETTask Refresh(this DlgMain self)
		{
			Unit unit = UnitHelper.GetMyUnitFromCurrentScene(self.ZoneScene().CurrentScene());
			NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
			
			self.View.E_RoleLevelText.SetText($"Lv.{numericComponent.GetAsInt((int)NumericType.Level)}");
			self.View.E_GoldText.SetText(numericComponent.GetAsInt((int)NumericType.Gold).ToString());
			self.View.E_ExpText.SetText(numericComponent.GetAsInt((int)NumericType.Exp).ToString());
			await ETTask.CompletedTask;
		}

		public static async ETTask OnAdventureClickHandler(this DlgMain self)
		{
			self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Adventure);
			await ETTask.CompletedTask;
		}

		public static async ETTask OnRoleButtonClickHandler(this DlgMain self)
		{
			// try
			// {
			// 	int error = await NumericHelper.TestUpdateNumeric(self.ZoneScene());
			// 	if (error != ErrorCode.ERR_Success)
			// 	{
			// 		return;
			// 	}
			// 	Log.Debug("发送更新属性测试消息成功");
			// }
			// catch (Exception e)
			// {
			// 	Log.Error(e.ToString());
			// }
			
			self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_RoleInfo);
			await ETTask.CompletedTask;
		}
	}
}
