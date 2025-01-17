﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgServerSystem
	{

		public static void RegisterUIEvent(this DlgServer self)
		{
			self.View.EBtn_EnterServerButton.AddListenerAsync((() => { return self.OnConfirmClickHandler();}));
			self.View.ELoopScrollList_ServerListLoopVerticalScrollRect.AddItemRefreshListener((transform, i) => self.OnScrollItemRefreshHandler(transform, i));
		}

		public static void ShowWindow(this DlgServer self, Entity contextData = null)
		{
			int count = self.ZoneScene().GetComponent<ServerInfosComponent>().ServerInfoList.Count;
			self.AddUIScrollItems(ref self.ScrollItemServers, count);
			self.View.ELoopScrollList_ServerListLoopVerticalScrollRect.SetVisible(true, count);
		}

		public static void HideWindow(this DlgServer self)
		{
			self.RemoveUIScrollItems(ref self.ScrollItemServers);
		}

		public static void OnScrollItemRefreshHandler(this DlgServer self, Transform transform, int index)
		{
			Scroll_Item_server scrollItemServer = self.ScrollItemServers[index].BindTrans(transform);
			ServerInfo serverInfo = self.ZoneScene().GetComponent<ServerInfosComponent>().ServerInfoList[index];
			scrollItemServer.EImageImage.color =
					serverInfo.Id == self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId? Color.red : Color.cyan;
			scrollItemServer.ETextText.SetText(serverInfo.ServerName);
			scrollItemServer.EButtonButton.AddListener((() => self.OnSelectServerItemHandler(serverInfo.Id)));
		}

		public static void OnSelectServerItemHandler(this DlgServer self, long serverId)
		{
			self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId = (int)serverId;
			Log.Debug($"当前选择的区服id是:{serverId}");
			self.View.ELoopScrollList_ServerListLoopVerticalScrollRect.RefillCells();
		}

		public static async ETTask OnConfirmClickHandler(this DlgServer self)
		{
			bool isSelect = self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId != 0;
			if (!isSelect)
			{
				Log.Error("请先选择区服");
				return;
			}

			try
			{
				int errorCode = await LoginHelper.GetRoles(self.ZoneScene());
				if (errorCode != ErrorCode.ERR_Success)
				{
					Log.Error(errorCode.ToString());
					return;
				}
				self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Roles);
				self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Server);
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
			}
			
		}
		
		
	}
}
