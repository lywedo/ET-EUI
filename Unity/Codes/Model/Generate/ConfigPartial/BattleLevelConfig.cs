using System.Collections.Generic;

namespace ET
{
    public partial class BattleLevelConfigCategory
    {
        // private List<BattleLevelConfig> showConfigList;
        // public override void AfterEndInit()
        // {
        //     base.AfterEndInit();
        //     this.showConfigList = new List<BattleLevelConfig>();
        //     foreach (BattleLevelConfig config in this.list)
        //     {
        //         // if (config.isNeedShow == 1)
        //         // {
        //             showConfigList.Add(config);
        //         // }
        //     }
        // }
        public BattleLevelConfig GetConfigByIndex(int index)
        {
            if (index < 0 || index >= this.list.Count)
            {
                Log.Error($"Get BattleLevelConfig Index Error: {index}");
                return null;
            }

            return this.list[index];
        }
    }
}