using System.Collections.Generic;

namespace ET
{
    public class AccountSessionsComponent: Entity, IAwake, IDestroy
    {
        public Dictionary<long, long> AccountSessionDirectory = new Dictionary<long, long>();
    }
}