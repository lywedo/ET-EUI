using System.Collections;
using System.Collections.Generic;
using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgAdventureSystem
	{

		public static void RegisterUIEvent(this DlgAdventure self)
		{
			self.RegisterCloseEvent<DlgAdventure>(self.View.E_CloseButton);
			self.View.ELoopScrollList_BattleLevelLoopVerticalScrollRect.AddItemRefreshListener(((transform, index) => self.OnBattleLevelItemRefresh(transform, index)));
		}

		public static void ShowWindow(this DlgAdventure self, Entity contextData = null)
		{
			self.View.EG_ContentRectTransform.DOScale(new Vector3(0.2f, 0.2f, 0.2f), 0);
			self.View.EG_ContentRectTransform.DOScale(Vector3.one, 0.3f).onComplete = () => self.Refresh();
		}

		public static void HideWindow(this DlgAdventure self)
		{
			self.View.ELoopScrollList_BattleLevelLoopVerticalScrollRect.SetVisible(false);
			self.RemoveUIScrollItems(ref self.ScrollItemBattleLevels);
		}

		public static void Refresh(this DlgAdventure self)
		{
			int count = BattleLevelConfigCategory.Instance.GetAll().Count;
			self.AddUIScrollItems(ref self.ScrollItemBattleLevels, count);
			self.View.ELoopScrollList_BattleLevelLoopVerticalScrollRect.SetVisible(true, count);
		}

		public static void OnBattleLevelItemRefresh(this DlgAdventure self, Transform transform, int index)
		{
			Scroll_Item_Adventure scrollItemAdventure = self.ScrollItemBattleLevels[index].BindTrans(transform);
			BattleLevelConfig config = BattleLevelConfigCategory.Instance.GetConfigByIndex(index);
			Unit unit = UnitHelper.GetMyUnitFromCurrentScene(self.ZoneScene().CurrentScene());
			int unitLevel = unit.GetComponent<NumericComponent>().GetAsInt(NumericType.Level);
			bool isInAdventure = unit.GetComponent<NumericComponent>().GetAsInt(NumericType.AdventureState) != 0;
			
			scrollItemAdventure.EButton_enterButton.SetVisible(unitLevel >= config.MiniEnterLevel[0] && !isInAdventure);
			scrollItemAdventure.ELabel_inAdventureTipText.SetVisible(unitLevel >= config.MiniEnterLevel[0] && isInAdventure);
			scrollItemAdventure.ELabel_notEnoughText.SetVisible(unitLevel < config.MiniEnterLevel[0]);
			scrollItemAdventure.ELabel_NameText.SetText($"{config.Name}");
			scrollItemAdventure.ELabel_LevelText.SetText($"Lv.{config.MiniEnterLevel[0]}~Lv.{config.MiniEnterLevel[1]}");
			scrollItemAdventure.EButton_enterButton.AddListenerAsync(() => { return self.OnStartGameLevelClickHandler(config.Id);});
		}

		public static async ETTask OnStartGameLevelClickHandler(this DlgAdventure self, int levelId)
		{
			try
			{
				int errorCode = await AdventureHelper.RequestStartGameLevel(self.ZoneScene(), levelId);
				if (errorCode != ErrorCode.ERR_Success)
				{
					if (errorCode == ErrorCode.ERR_AdventureInDying)
					{
						self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Dying);
					}
					return;
				}
				// self.Refresh();
				// Game.EventSystem.Publish(new EventType.StartGameLevel(){ZoneScene = self.ZoneScene()});
				self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Adventure);
				self.ZoneScene().CurrentScene().GetComponent<AdventureComponent>().StartAdventure().Coroutine();
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
			}
		}

	}
}
