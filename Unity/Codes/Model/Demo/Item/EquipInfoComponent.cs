using System.Collections.Generic;
#if SERVER
using MongoDB.Bson.Serialization.Attributes;

#endif

namespace ET
{
    [ChildType(typeof (AttributeEntry))]
#if SERVER
    public class EquipInfoComponent: Entity, IAwake, IDestroy, ISerializeToEntity, IDeserialize
#else
    public class EquipInfoComponent: Entity, IAwake, IDestroy
#endif
    {
        public bool IsInited = false;
        
        //装备评分
        public int Score = 0;
        
        //装备词条列表
#if SERVER
        [BsonIgnore]
#endif
        public List<AttributeEntry> EntryList = new List<AttributeEntry>();
    }
}