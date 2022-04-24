namespace ET
{
    [FriendClass(typeof(BagComponent))]
    public static class BagComponentSystem
    {
        public static void Clear(this BagComponent self)
        {
            ForeachHelper.Foreach(self.ItemDict, (id, item) =>
            {
                item?.Dispose();
            });
            self.ItemDict.Clear();
            self.ItemsMap.Clear();
        }

        public static int GetItemCountByItemType(this BagComponent self, ItemType itemType)
        {
            if (!self.ItemsMap.ContainsKey((int)itemType))
            {
                return 0;
            }

            return self.ItemsMap[(int) itemType].Count;
        }
        
        public static void AddItem(this BagComponent self, Item item)
        {
            self.AddChild(item);
            self.ItemDict.Add(item.Id, item);
            self.ItemsMap.Add(item.Config.Type, item);
        }

        public static void RemoveItem(this BagComponent self, Item item)
        {
            if (item == null)
            {
                Log.Error("bag item is null");
                return;
            }

            self.ItemDict.Remove(item.Id);
            self.ItemsMap.Remove(item.Config.Type, item);
            item?.Dispose();
        }
    }
}