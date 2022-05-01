using System;

namespace ET
{
    public static class ItemApplyHelper
    {
        public static async ETTask<int> SellBagItem(Scene ZoneScene, long itemId)
        {
            Item item = ItemHelper.GetItem(ZoneScene, itemId, ItemContainerType.Bag);

            if (item == null)
            {
                return ErrorCode.ERR_ItemNotExist;
            }

            M2C_SellItem m2CSellItem = null;
            try
            {
                m2CSellItem = (M2C_SellItem) await ZoneScene.GetComponent<SessionComponent>().Session.Call(new C2M_SellItem() { ItemUid = itemId });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetorkError;
            }

            return m2CSellItem.Error;
        }
    }
}