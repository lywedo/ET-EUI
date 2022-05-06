namespace ET
{
    public static class EquipmentsComponentSystem
    {
        //装配Item
        public static bool EquipItem(this EquipmentsComponent self, Item item)
        {
            if (!self.EquipItems.ContainsKey(item.Config.EquipPosition))
            {
                self.AddChild(item);
                self.EquipItems.Add(item.Config.EquipPosition, item);
                Game.EventSystem.Publish(new EventType.ChangeEquipItem(){Unit = self.GetParent<Unit>(), Item = item, EquipOp = EquipOp.Load});
                ItemUpdateNoticeHelper.SyncAddItem(self.GetParent<Unit>(), item, self.message);
                return true;
            }

            return false;
        }
        
        //卸下对应位置的Item
        public static Item UnloadEquipItemByPosition(this EquipmentsComponent self, EquipPosition equipPosition)
        {
            if (self.EquipItems.TryGetValue((int)equipPosition, out Item item))
            {
                self.EquipItems.Remove((int) equipPosition);
                Game.EventSystem.Publish(new EventType.ChangeEquipItem(){Unit = self.GetParent<Unit>(), Item = item, EquipOp = EquipOp.Unload});
                ItemUpdateNoticeHelper.SyncRemoveItem(self.GetParent<Unit>(), item, self.message);
            }

            return item;
        }

        public static Item GetEquipItemByPosition(this EquipmentsComponent self, EquipPosition equipPosition)
        {
            if (!self.EquipItems.TryGetValue((int)equipPosition, out Item item))
            {
                return null;
            }

            return item;
        } 
    }
}