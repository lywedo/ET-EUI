namespace ET
{
    [FriendClass(typeof(Item))]
    public static class ItemFactory
    {
        public static Item Create(Entity parent, int configId)
        {
            if (!ItemConfigCategory.Instance.Contain(configId))
            {
                Log.Error($"当前所创建的物品id不存在:{configId}");
                return null;
            }

            Item item = parent.AddChild<Item, int>(configId);
            item.RandomQuality();
            AddcomponentByItemType(item);
            return item;
        }

        public static void AddcomponentByItemType(Item item)
        {
            switch ((ItemType)item.Config.Type)
            {
                case ItemType.Weapon:
                case ItemType.Armor:
                case ItemType.Ring:
                {
                    item.AddComponent<EquipInfoComponent>();
                }
                    break;
                case ItemType.Prop:
                {
                    
                }
                    break;
            }
        }
    }
}