using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ET
{
    public static class DlgLoginSystem
    {
        public static void RegisterUIEvent(this DlgLogin self)
        {
            self.View.E_LoginButton.AddListenerAsync(() => { return self.OnLoginClickHandler(); });
        }

        public static void ShowWindow(this DlgLogin self, Entity contextData = null)
        {
        }

        public static async ETTask OnLoginClickHandler(this DlgLogin self)
        {
            try
            {
                int errorcode = await LoginHelper.Login(self.DomainScene(),
                    ConstValue.LoginAddress,
                    self.View.E_AccountInputField.GetComponent<InputField>().text,
                    self.View.E_PasswordInputField.GetComponent<InputField>().text);
                if (errorcode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorcode.ToString());
                }
                //TODO 显示登陆之后页面
                self.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Login);
                // self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Lobby);
                await SceneChangeHelper.SceneChangeToTest(self.ZoneScene(), "TestScene", 1);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }

        public static void HideWindow(this DlgLogin self)
        {
        }
    }
}