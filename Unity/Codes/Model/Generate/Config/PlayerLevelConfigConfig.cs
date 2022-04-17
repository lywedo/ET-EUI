using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class PlayerLevelConfigConfigCategory : ProtoObject, IMerge
    {
        public static PlayerLevelConfigConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, PlayerLevelConfigConfig> dict = new Dictionary<int, PlayerLevelConfigConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<PlayerLevelConfigConfig> list = new List<PlayerLevelConfigConfig>();
		
        public PlayerLevelConfigConfigCategory()
        {
            Instance = this;
        }
        
        public void Merge(object o)
        {
            PlayerLevelConfigConfigCategory s = o as PlayerLevelConfigConfigCategory;
            this.list.AddRange(s.list);
        }
		
        public override void EndInit()
        {
            foreach (PlayerLevelConfigConfig config in list)
            {
                config.EndInit();
                this.dict.Add(config.Id, config);
            }            
            this.AfterEndInit();
        }
		
        public PlayerLevelConfigConfig Get(int id)
        {
            this.dict.TryGetValue(id, out PlayerLevelConfigConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (PlayerLevelConfigConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, PlayerLevelConfigConfig> GetAll()
        {
            return this.dict;
        }

        public PlayerLevelConfigConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class PlayerLevelConfigConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		[ProtoMember(1)]
		public int Id { get; set; }
		/// <summary>所需经验值</summary>
		[ProtoMember(2)]
		public long NeedExp { get; set; }

	}
}
