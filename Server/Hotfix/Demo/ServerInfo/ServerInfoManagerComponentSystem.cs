namespace ET
{
    public class ServerInfoManagerComponentAwakeSystem : AwakeSystem<ServerInfoManagerComponent>
    {
        public override void Awake(ServerInfoManagerComponent self)
        {
            self.Awake().Coroutine();
        }
    }
    
    public class ServerInfoManagerComponentDestroy : DestroySystem<ServerInfoManagerComponent>
    {
        public override void Destroy(ServerInfoManagerComponent self)
        {
            foreach (ServerInfo selfServerInfo in self.ServerInfos)
            {
                selfServerInfo?.Dispose();
            }
            self.ServerInfos.Clear();
        }
    }
    
    public class ServerInfoManagerComponentLoadSystem : LoadSystem<ServerInfoManagerComponent>
    {
        public override void Load(ServerInfoManagerComponent self)
        {
            self.Awake().Coroutine();
        }
    }

    public static class ServerInfoManagerComponentSystem
    {
        public static async ETTask Awake(this ServerInfoManagerComponent self)
        {
            var serverInfos = await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Query<ServerInfo>(d => true);
            if (serverInfos == null && serverInfos.Count <= 0)
            {
                Log.Error("serverInfo count is zero");
                return;
            }

            foreach (var serverInfo in serverInfos)
            {
                self.AddChild(serverInfo);
                self.ServerInfos.Add(serverInfo);
            }
            await ETTask.CompletedTask;
        }
    }
}