using System.Collections.Generic;

namespace ET
{
    public partial class PlayerNumericConfigCategory
    {
        private List<PlayerNumericConfig> showConfigList;

        public override void AfterEndInit()
        {
            base.AfterEndInit();
            this.showConfigList = new List<PlayerNumericConfig>();
            foreach (PlayerNumericConfig config in this.list)
            {
                if (config.isNeedShow == 1)
                {
                    showConfigList.Add(config);
                }
            }
        }

        public int GetShowConfigCount()
        {
            return showConfigList.Count;
        }

        public PlayerNumericConfig GetConfigByIndex(int index)
        {
            if (index < 0 || index >= showConfigList.Count)
            {
                return showConfigList[0];
            }

            return showConfigList[index];
        }
        
    }
}