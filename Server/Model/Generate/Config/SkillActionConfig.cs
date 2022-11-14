using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class SkillActionConfigCategory : ProtoObject, IMerge
    {
        public static SkillActionConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, SkillActionConfig> dict = new Dictionary<int, SkillActionConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<SkillActionConfig> list = new List<SkillActionConfig>();
		
        public SkillActionConfigCategory()
        {
            Instance = this;
        }
        
        public void Merge(object o)
        {
            SkillActionConfigCategory s = o as SkillActionConfigCategory;
            this.list.AddRange(s.list);
        }
		
        public override void EndInit()
        {
            foreach (SkillActionConfig config in list)
            {
                config.EndInit();
                this.dict.Add(config.Id, config);
            }            
            this.AfterEndInit();
        }
		
        public SkillActionConfig Get(int id)
        {
            this.dict.TryGetValue(id, out SkillActionConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (SkillActionConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, SkillActionConfig> GetAll()
        {
            return this.dict;
        }

        public SkillActionConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class SkillActionConfig: ProtoObject, IConfig
	{
		/// <summary>ActionId</summary>
		[ProtoMember(1)]
		public int Id { get; set; }
		/// <summary>名字</summary>
		[ProtoMember(2)]
		public string Name { get; set; }

	}
}
