using System.Collections.Generic;

namespace ET
{
    public class AdventureComponent: Entity, IAwake, IDestroy
    {
        public long BattleTimer = 0;
        public int Round = 0;
        public List<long> EnemyIdList = new List<long>();
        public List<long> AliveEnermyIdList = new List<long>();
    }
}