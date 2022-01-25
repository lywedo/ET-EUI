namespace ET
{
    public class AccountSessionsComponentDestorySystem: DestroySystem<AccountSessionsComponent>
    {
        public override void Destroy(AccountSessionsComponent self)
        {
            self.AccountSessionDirectory.Clear();
        }
    }

    public static class AccountSessionsComponentSystem
    {
        public static long Get(this AccountSessionsComponent self, long accountId)
        {
            if (!self.AccountSessionDirectory.TryGetValue(accountId, out long instanceId))
            {
                return 0;
            }

            return instanceId;
        }

        public static void Add(this AccountSessionsComponent self, long accountId, long sessionInstanceId)
        {
            if (self.AccountSessionDirectory.ContainsKey(accountId))
            {
                self.AccountSessionDirectory[accountId] = sessionInstanceId;
                return;
            }
            self.AccountSessionDirectory.Add(accountId, sessionInstanceId);
        }

        public static void Remove(this AccountSessionsComponent self, long accountId)
        {
            if (self.AccountSessionDirectory.ContainsKey(accountId))
            {
                self.AccountSessionDirectory.Remove(accountId);
            }
        }
    }
}