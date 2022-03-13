using System.Collections.Generic;

namespace ET
{
    public interface IUnitCache
    {
        
    }
    public class UnitCache: Entity, IAwake, IDestroy
    {
        public string key;
        public Dictionary<long, Unit> CacheUnitDictionary = new Dictionary<long, Unit>();
    }
}