using System.Collections.Generic;

namespace ET
{
    public partial class EntryConfigCategory
    {
        private Dictionary<int, MultiMap<int, EntryConfig>> EntryConfigDict = new Dictionary<int, MultiMap<int, EntryConfig>>();

        public override void AfterEndInit()
        {
            base.AfterEndInit();

            foreach (EntryConfig config in this.dict.Values)
            {
                if (!this.EntryConfigDict.ContainsKey(config.EntryType))
                {
                    this.EntryConfigDict.Add(config.EntryType, new MultiMap<int, EntryConfig>());
                }

                this.EntryConfigDict[config.EntryType].Add(config.EntryLevel, config);
            }
        }

        public EntryConfig GetRandomEntryConfigByLevel(int entryType, int level)
        {
            if (!this.EntryConfigDict.ContainsKey(entryType))
            {
                return null;
            }

            MultiMap<int,EntryConfig> entryConfigsMap = this.EntryConfigDict[entryType];
            if (!entryConfigsMap.ContainsKey(level))
            {
                return null;
            }

            var entryConfigList = entryConfigsMap[level];
            int index = RandomHelper.RandomNumber(0, entryConfigList.Count);
            return entryConfigList[index];
        }
    }
}