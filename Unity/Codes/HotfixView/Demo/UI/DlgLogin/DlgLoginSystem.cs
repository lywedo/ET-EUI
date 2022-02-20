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
            self.View.E_TestBtnButton.AddListenerAsync(() => { return self.OnTestClickHandler();});
        }

        public static async ETTask OnTestClickHandler(this DlgLogin self)
        {
            await SceneChangeHelper.SceneChangeToTest(self.ZoneScene(), "ControllerScene", 1);
            Game.EventSystem.Publish(new EventType.CreateJoystick(){ZoneScene = self.DomainScene()});
            self.DomainScene().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Login);
            
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
                    return;
                }

                errorcode = await LoginHelper.GetServerInfo(self.DomainScene());
                if (errorcode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorcode.ToString());
                    return;
                }
                
                self.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Login);
                self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Server);
                // self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Lobby);
                // await SceneChangeHelper.SceneChangeToTest(self.ZoneScene(), "ControllerScene", 1);
                // Game.EventSystem.Publish(new EventType.CreateJoystick(){ZoneScene = self.ZoneScene()});
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