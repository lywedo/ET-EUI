using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgTestSystem
	{

		public static void RegisterUIEvent(this DlgTest self)
		{
			self.View.E_EnterMapButton.AddListener(self.OnEnterMapBtnClickHandler);
			self.View.Ebtn_testButton.AddListener(self.OnTestBtnHandler);
			self.View.ELoopScrollList_testLoopHorizontalScrollRect.AddItemRefreshListener(((transform, i) => self.OnLoopListItemRefreshHandler(transform, i)));
		}

		public static void ShowWindow(this DlgTest self, Entity contextData = null)
		{
			self.View.ETextText.text = "helloword";
			self.View.ESCommonTestUi.SetLable("测试界面");

			int count = 100;
			self.AddUIScrollItems(ref self.ScrollItemTestsDict, count);
			self.View.ELoopScrollList_testLoopHorizontalScrollRect.SetVisible(true, count);
		}

		public static void HideWindow(this DlgTest self)
		{
			self.RemoveUIScrollItems(ref self.ScrollItemTestsDict);
		}

		public static async void OnEnterMapBtnClickHandler(this DlgTest self)
		{
			Log.Debug("enter_test");
			// UIComponent
			await self.ZoneScene().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Login);
			self.ZoneScene().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Test);
			
		}

		public static void OnTestBtnHandler(this DlgTest self)
		{
			Log.Debug("btnbtn");
		}

		public static void OnLoopListItemRefreshHandler(this DlgTest self, Transform transform, int index)
		{
			Scroll_Item_Stest itemTest = self.ScrollItemTestsDict[index].BindTrans(transform);
			
			itemTest.ETextText.text = $"{index}服";
			
		}

	}
}
