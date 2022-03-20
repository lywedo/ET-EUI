using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public static class DlgRolesSystem
    {
        public static void RegisterUIEvent(this DlgRoles self)
        {
            self.View.EBeginGameButton.AddListenerAsync((() => { return self.OnConfirmClickHandler(); }));
            self.View.ECreateRoleButton.AddListenerAsync((() => { return self.OnCreateRoleClickHandler(); }));
            self.View.EDeleteRoleButton.AddListenerAsync((() => { return self.OnDeleteRoleClickHandler(); }));
            self.View.ELoopScrollList_RolesLoopHorizontalScrollRect.AddItemRefreshListener(((transform, i) =>
                    self.OnRoleListRefreshHandler(transform, i)));
        }

        public static void ShowWindow(this DlgRoles self, Entity contextData = null)
        {
            self.RefreshRoleItem();
        }

        public static async ETTask OnConfirmClickHandler(this DlgRoles self)
        {
            if (self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId == 0)
            {
                Log.Error("请先选择角色");
                return;
            }

            try
            {
                int errorCode = await LoginHelper.GetRealmKey(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                errorCode = await LoginHelper.EnterGame(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }
                self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Main);
                self.ZoneScene().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Roles);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }

        public static async ETTask OnCreateRoleClickHandler(this DlgRoles self)
        {
            string name = self.View.EInputNameInputField.text;
            if (string.IsNullOrEmpty(name))
            {
                Log.Error("name is null");
                return;
            }

            try
            {
                int errorCode = await LoginHelper.CreateRole(self.ZoneScene(), name);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                self.RefreshRoleItem();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }

        public static async ETTask OnDeleteRoleClickHandler(this DlgRoles self)
        {
            if (self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId == 0)
            {
                Log.Error("请选择需要删除的角色");
                return;
            }

            try
            {
                int errorCode = await LoginHelper.DeleteRole(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                self.RefreshRoleItem();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }

        public static void OnRoleListRefreshHandler(this DlgRoles self, Transform transform, int index)
        {
            Scroll_Item_Roles scrollItemRoles = self.ScrollItemRolesMap[index].BindTrans(transform);
            RoleInfo roleInfo = self.ZoneScene().GetComponent<RoleInfosComponent>().RoleInfos[index];
            scrollItemRoles.ETextText.SetText(roleInfo.Name);
            scrollItemRoles.EImageImage.color =
                    roleInfo.Id == self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId? Color.green : Color.gray;
            scrollItemRoles.EButtonButton.AddListener((() => self.OnSelectRoleItemHandler(roleInfo.Id)));
        }

        public static void OnSelectRoleItemHandler(this DlgRoles self, long roleId)
        {
            self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId = roleId;
            Log.Debug($"当前选择的role id是:{roleId}");
            self.View.ELoopScrollList_RolesLoopHorizontalScrollRect.RefreshCells();
        }

        public static void RefreshRoleItem(this DlgRoles self)
        {
            int count = self.ZoneScene().GetComponent<RoleInfosComponent>().RoleInfos.Count;
            self.AddUIScrollItems(ref self.ScrollItemRolesMap, count);
            self.View.ELoopScrollList_RolesLoopHorizontalScrollRect.SetVisible(true, count);
        }
    }
}