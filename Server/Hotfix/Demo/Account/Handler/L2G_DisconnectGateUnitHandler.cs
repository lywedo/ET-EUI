﻿using System;

namespace ET
{
    public class L2G_DisconnectGateUnitHandler : AMActorRpcHandler<Scene, L2G_DisconnectGateUnit, G2L_DisconnectGateUnit>
    {
        protected override async ETTask Run(Scene scene, L2G_DisconnectGateUnit request, G2L_DisconnectGateUnit response, Action reply)
        {
            long accountId = request.AccountId;
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate, accountId.GetHashCode()))
            {
                PlayerComponent playerComponent = scene.GetComponent<PlayerComponent>();
                Player player = playerComponent.Get(accountId);
                if (player == null)
                {
                    reply();
                    return;
                }
                // playerComponent.Remove(accountId);
                // gateUnit.Dispose();//临时处理
                scene.GetComponent<GateSessionKeyComponent>().Remove(accountId);
                Session gateSession = Game.EventSystem.Get(player.ClientSession.InstanceId) as Session;
                if (gateSession != null && !gateSession.IsDisposed)
                {
                    if (gateSession.GetComponent<SessionPlayerComponent>() != null)
                    {
                        gateSession.GetComponent<SessionPlayerComponent>().isLoginAgain = true;
                    }
                    gateSession.Send(new A2C_Dissconnect(){Error = ErrorCode.ERR_OtherAccountLogin});
                    gateSession?.Disconnect().Coroutine();
                }

                // player.SessionInstanceId = 0;
                player.AddComponent<PlayerOfflineOutTimeComponent>();
            }

            reply();
            
        }
    }
}