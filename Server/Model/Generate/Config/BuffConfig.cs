using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class BuffConfigCategory : ProtoObject, IMerge
    {
        public static BuffConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, BuffConfig> dict = new Dictionary<int, BuffConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<BuffConfig> list = new List<BuffConfig>();
		
        public BuffConfigCategory()
        {
            Instance = this;
        }
        
        public void Merge(object o)
        {
            BuffConfigCategory s = o as BuffConfigCategory;
            this.list.AddRange(s.list);
        }
		
        public override void EndInit()
        {
            foreach (BuffConfig config in list)
            {
                config.EndInit();
                this.dict.Add(config.Id, config);
            }            
            this.AfterEndInit();
        }
		
        public BuffConfig Get(int id)
        {
            this.dict.TryGetValue(id, out BuffConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (BuffConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, BuffConfig> GetAll()
        {
            return this.dict;
        }

        public BuffConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class BuffConfig: ProtoObject, IConfig
	{
		/// <summary>BuffId</summary>
		[ProtoMember(1)]
		public int Id { get; set; }
		/// <summary>名字</summary>
		[ProtoMember(2)]
		public string Name { get; set; }
		/// <summary>buff等级</summary>
		[ProtoMember(3)]
		public int Level { get; set; }
		/// <summary>可叠加层数</summary>
		[ProtoMember(4)]
		public int MaxCount { get; set; }
		/// <summary>效果类型[0：增益减益，1：定时属性变化，2：定时触发action，3条件触发action]</summary>
		[ProtoMember(5)]
		public int EffectType { get; set; }
		/// <summary>触发效果冷却时间(仅条件触发类型需要)</summary>
		[ProtoMember(6)]
		public int TriggerColdTime { get; set; }
		/// <summary>可否覆盖刷新</summary>
		[ProtoMember(7)]
		public int Refresh { get; set; }
		/// <summary>可被清除方式</summary>
		[ProtoMember(8)]
		public int ClearType { get; set; }
		/// <summary>最长持续时间(ms)</summary>
		[ProtoMember(9)]
		public int BaseContinueTime { get; set; }
		/// <summary>两次生效间隔时间(间隔足够短就类似每帧触发了，mmo每帧也没啥意义)</summary>
		[ProtoMember(10)]
		public int IntervalTime { get; set; }
		/// <summary>触发条件</summary>
		[ProtoMember(11)]
		public int TriggerConditionId { get; set; }
		/// <summary>执行action</summary>
		[ProtoMember(12)]
		public int NormalActionId { get; set; }
		/// <summary>属性编号1</summary>
		[ProtoMember(13)]
		public int Index1 { get; set; }
		/// <summary>变化比例(分母100)</summary>
		[ProtoMember(14)]
		public int Percent1 { get; set; }
		/// <summary>变化固定值</summary>
		[ProtoMember(15)]
		public int Absolute1 { get; set; }
		/// <summary>属性编号2</summary>
		[ProtoMember(16)]
		public int Index2 { get; set; }
		/// <summary>变化比例(分母100)</summary>
		[ProtoMember(17)]
		public int Percent2 { get; set; }
		/// <summary>变化固定值</summary>
		[ProtoMember(18)]
		public int Absolute2 { get; set; }
		/// <summary>属性编号3</summary>
		[ProtoMember(19)]
		public int Index3 { get; set; }
		/// <summary>变化比例(分母100)</summary>
		[ProtoMember(20)]
		public int Percent3 { get; set; }
		/// <summary>变化固定值</summary>
		[ProtoMember(21)]
		public int Absolute3 { get; set; }
		/// <summary>属性编号4</summary>
		[ProtoMember(22)]
		public int Index4 { get; set; }
		/// <summary>变化比例(分母100)</summary>
		[ProtoMember(23)]
		public int Percent4 { get; set; }
		/// <summary>变化固定值</summary>
		[ProtoMember(24)]
		public int Absolute4 { get; set; }
		/// <summary>属性编号5</summary>
		[ProtoMember(25)]
		public int Index5 { get; set; }
		/// <summary>变化比例(分母100)</summary>
		[ProtoMember(26)]
		public int Percent5 { get; set; }
		/// <summary>变化固定值</summary>
		[ProtoMember(27)]
		public int Absolute5 { get; set; }
		/// <summary>特殊action1</summary>
		[ProtoMember(28)]
		public int BuffEndAction1 { get; set; }
		/// <summary>特殊action2</summary>
		[ProtoMember(29)]
		public int BuffEndAction2 { get; set; }

	}
}
