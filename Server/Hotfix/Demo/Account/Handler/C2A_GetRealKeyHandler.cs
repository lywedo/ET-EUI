using System;

namespace ET
{
    public class C2A_GetRealKeyHandler : AMRpcHandler<C2A_GetRealKey, A2C_GetRealKey>
    {
        protected override async ETTask Run(Session session, C2A_GetRealKey request, A2C_GetRealKey response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Account)
            {
                Log.Error($"请求的Scene错误，当前Scene为：{session.DomainScene().SceneType}");
                session?.Dispose();
                return;
            }

            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            string token = session.DomainScene().GetComponent<TokenComponent>().Get(request.AccountId);
            if (token == null || token != request.Token)
            {
                response.Error = ErrorCode.ERR_TokenError;
                reply();
                session?.Disconnect().Coroutine();
                return;
            }

            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginAccount, request.AccountId))
                {
                    StartSceneConfig realmStartSceneConfig = RealmGateAddressHelper.GetRealm(request.ServerId);
                    R2A_GetRealmKey r2AGetRealmKey = (R2A_GetRealmKey)await MessageHelper.CallActor(realmStartSceneConfig.InstanceId, new A2R_GetRealmKey() { AccountId = request.AccountId });
                    if (r2AGetRealmKey.Error != ErrorCode.ERR_Success)
                    {
                        response.Error = r2AGetRealmKey.Error;
                        reply();
                        session?.Disconnect();
                        return;
                    }

                    response.RealmKey = r2AGetRealmKey.RealmKey;
                    response.ReamlmAddress = realmStartSceneConfig.OuterIPPort.ToString();
                    reply();
                    session?.Disconnect();
                    
                }
            }
        }
    }
}