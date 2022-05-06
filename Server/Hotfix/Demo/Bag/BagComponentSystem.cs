﻿using System.Collections.Generic;

namespace ET
{
    
    public class BagComponentDeserializeSystem: DeserializeSystem<BagComponent>
    {
        public override void Deserialize(BagComponent self)
        {
            foreach (Entity entity in self.Children.Values)
            {
                self.AddContainer(entity as Item);
            }
        }
    }

    [FriendClass(typeof(BagComponent))]
    [FriendClass(typeof(Item))]
    public static class BagComponentSystem
    {
        //是否达到最大负载
        public static bool IsMaxLoad(this BagComponent self)
        {
            return self.ItemsDict.Count == self.GetParent<Unit>().GetComponent<NumericComponent>()[NumericType.MaxBagCapacity];
        }

        public static bool AddContainer(this BagComponent self, Item item)
        {
            if (self.ItemsDict.ContainsKey(item.Id))
            {
                return false;
            }
            
            self.ItemsDict.Add(item.Id, item);
            self.ItemsMap.Add(item.Config.Type, item);
            return true;
        }
        public static bool IsCanAddItemByConfigId(this BagComponent self, int configID)
        {
            if (!ItemConfigCategory.Instance.Contain(configID))
            {
                return false;
            }

            if (self.IsMaxLoad())
            {
                return false;
            }

            return true;
        }

        public static void RemoveContainer(this BagComponent self, Item item)
        {
            self.ItemsDict.Remove(item.Id);
            self.ItemsMap.Remove(item.Config.Type, item);
        }

        public static bool AddItemByConfigId(this BagComponent self, int configId, int count = 1)
        {
            if (!ItemConfigCategory.Instance.Contain(configId))
            {
                return false;
            }

            if (count <= 0)
            {
                return false;
            }

            for (int i = 0; i < count; i++)
            {
                Item newItem = ItemFactory.Create(self, configId);
                if (!self.AddItem(newItem))
                {
                    Log.Error("添加物品失败！");
                    newItem?.Dispose();
                    return false;
                }
            }

            return true;
        }

        // public static void GetItemListByConfigId(this BagComponent self, int configID, List<Item> list)
        // {
        //     
        // }

        public static bool IsCanAddItem(this BagComponent self, Item item)
        {
            if (item == null || item.IsDisposed)
            {
                return false;
            }

            if (!ItemConfigCategory.Instance.Contain(item.ConfigId))
            {
                return false;
            }

            if (self.IsMaxLoad())
            {
                return false;
            }

            if (self.ItemsDict.ContainsKey(item.Id))
            {
                return false;
            }

            if (item.Parent == self)
            {
                return false;
            }

            return true;
        }

        public static bool AddItem(this BagComponent self, Item item)
        {
            if (item == null || item.IsDisposed)
            {
                Log.Error("item is null!");
                return false;
            }

            if (self.IsMaxLoad())
            {
                Log.Error("bag is IsMaxLoad");
                return false;
            }

            if (!self.AddContainer(item))
            {
                Log.Error("Add Container is Error");
                return false;
            }

            if (item.Parent != self)
            {
                self.AddChild(item);
            }

            ItemUpdateNoticeHelper.SyncAddItem(self.GetParent<Unit>(), item, self.message);
            return true;
        }

        public static void RemoveItem(this BagComponent self, Item item)
        {
            self.RemoveContainer(item);
            ItemUpdateNoticeHelper.SyncRemoveItem(self.GetParent<Unit>(), item, self.message);
            item.Dispose();
        }

        public static Item RemoveItemNoDispose(this BagComponent self, Item item)
        {
            self.RemoveContainer(item);
            ItemUpdateNoticeHelper.SyncRemoveItem(self.GetParent<Unit>(), item, self.message);
            return item;
        }

        public static bool IsItemExist(this BagComponent self, long itemId)
        {
            self.ItemsDict.TryGetValue(itemId, out Item item);
            return item != null && !item.IsDisposed;
        }

        public static Item GetItemById(this BagComponent self, long itemId)
        {
            self.ItemsDict.TryGetValue(itemId, out Item item);
            return item;
        }
    }
}