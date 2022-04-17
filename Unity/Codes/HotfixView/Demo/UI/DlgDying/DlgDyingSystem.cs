using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgDyingSystem
	{

		public static void RegisterUIEvent(this DlgDying self)
		{
			// self.RegisterCloseEvent<DlgDying>(self.View.EButton_BackButton);
			self.View.EButton_BackButton.AddListener(()=>{self.DomainScene().GetComponent<UIComponent>().CloseWindow(self.GetParent<UIBaseWindow>().WindowID);});
			self.View.EButton_ReviveButton.AddListenerAsync(() => { return self.OnReviveClickHandler();});
		}

		public static void ShowWindow(this DlgDying self, Entity contextData = null)
		{
		}

		public static async ETTask OnReviveClickHandler(this DlgDying self)
		{
			M2C_Revive m2CRevive = null;
			try
			{
				m2CRevive = (M2C_Revive) await self.ZoneScene().GetComponent<SessionComponent>().Session.Call(new C2M_Revive());
				if (m2CRevive.Error != ErrorCode.ERR_Success)
				{
					Log.Error(m2CRevive.Error.ToString());
				}

				self.View.ELabel_CenterText.text = "复活成功";
				self.View.EButton_ReviveButton.SetVisible(false);
				self.View.EG_BgRectTransform.GetComponent<Image>().color = Color.green;
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
			}
		}
		 

	}
}
