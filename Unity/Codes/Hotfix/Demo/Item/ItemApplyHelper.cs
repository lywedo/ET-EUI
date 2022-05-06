using System;

namespace ET
{
    public static class ItemApplyHelper
    {
        public static async ETTask<int> EquipItem(Scene ZoneScene, long itemId)
        {
            Item item = ItemHelper.GetItem(ZoneScene, itemId, ItemContainerType.Bag);

            if (item == null)
            {
                return ErrorCode.ERR_ItemNotExist;
            }

            M2C_EquipItem m2CEquipItem = null;

            try
            {
                m2CEquipItem = (M2C_EquipItem) await ZoneScene.GetComponent<SessionComponent>().Session.Call(new C2M_EquipItem() { ItemUid = itemId });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetorkError;
            }

            return m2CEquipItem.Error;
        }
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