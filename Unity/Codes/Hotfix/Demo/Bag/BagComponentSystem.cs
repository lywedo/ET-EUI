namespace ET
{
    public class BagComponentDestroySystem: DestroySystem<BagComponent>
    {
        public override void Destroy(BagComponent self)
        {
            self.Clear();
        }
    }

    [FriendClass(typeof (BagComponent))]
    public static class BagComponentSystem
    {
        public static void Clear(this BagComponent self)
        {
            ForeachHelper.Foreach(self.ItemsDict, (id, item) => { item?.Dispose(); });
            self.ItemsDict.Clear();
            self.ItemsMap.Clear();
        }

        public static int GetItemCountByItemType(this BagComponent self, ItemType itemType)
        {
            if (!self.ItemsMap.ContainsKey((int) itemType))
            {
                return 0;
            }

            return self.ItemsMap[(int) itemType].Count;
        }

        public static void AddItem(this BagComponent self, Item item)
        {
            self.AddChild(item);
            self.ItemsDict.Add(item.Id, item);
            self.ItemsMap.Add(item.Config.Type, item);
        }

        public static Item GetItemById(this BagComponent self, long itemId)
        {
            if (self.ItemsDict.TryGetValue(itemId, out Item item))
            {
                return item;
            }

            return null;
        }

        public static void RemoveItem(this BagComponent self, Item item)
        {
            if (item == null)
            {
                Log.Error("bag item is null");
                return;
            }

            self.ItemsDict.Remove(item.Id);
            self.ItemsMap.Remove(item.Config.Type, item);
            item?.Dispose();
        }
    }
}