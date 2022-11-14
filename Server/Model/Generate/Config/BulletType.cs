using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class BulletTypeCategory : ProtoObject, IMerge
    {
        public static BulletTypeCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, BulletType> dict = new Dictionary<int, BulletType>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<BulletType> list = new List<BulletType>();
		
        public BulletTypeCategory()
        {
            Instance = this;
        }
        
        public void Merge(object o)
        {
            BulletTypeCategory s = o as BulletTypeCategory;
            this.list.AddRange(s.list);
        }
		
        public override void EndInit()
        {
            foreach (BulletType config in list)
            {
                config.EndInit();
                this.dict.Add(config.Id, config);
            }            
            this.AfterEndInit();
        }
		
        public BulletType Get(int id)
        {
            this.dict.TryGetValue(id, out BulletType item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (BulletType)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, BulletType> GetAll()
        {
            return this.dict;
        }

        public BulletType GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class BulletType: ProtoObject, IConfig
	{
		/// <summary>子弹类型id</summary>
		[ProtoMember(1)]
		public int Id { get; set; }

	}
}
