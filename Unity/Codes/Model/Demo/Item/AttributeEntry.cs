namespace ET
{
    public enum EntryType
    {
        Common = 1, //普通词条
        Special = 2 //特殊词条
    }
#if SERVER
    public class AttributeEntry: Entity, IAwake, IDestroy, ISerializeToEntity
#else
    public class AttributeEntry: Entity, IAwake, IDestroy
#endif
    {
        //词条数值属性
        public int Key;
        //词条数量属性
        public long Value;
        //词条类型
        public EntryType Type;
    }
}