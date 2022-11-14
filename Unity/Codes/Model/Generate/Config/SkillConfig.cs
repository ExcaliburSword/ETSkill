using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class SkillConfigCategory : ProtoObject, IMerge
    {
        public static SkillConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, SkillConfig> dict = new Dictionary<int, SkillConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<SkillConfig> list = new List<SkillConfig>();
		
        public SkillConfigCategory()
        {
            Instance = this;
        }
        
        public void Merge(object o)
        {
            SkillConfigCategory s = o as SkillConfigCategory;
            this.list.AddRange(s.list);
        }
		
        public override void EndInit()
        {
            foreach (SkillConfig config in list)
            {
                config.EndInit();
                this.dict.Add(config.Id, config);
            }            
            this.AfterEndInit();
        }
		
        public SkillConfig Get(int id)
        {
            this.dict.TryGetValue(id, out SkillConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (SkillConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, SkillConfig> GetAll()
        {
            return this.dict;
        }

        public SkillConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class SkillConfig: ProtoObject, IConfig
	{
		/// <summary>技能id</summary>
		[ProtoMember(1)]
		public int Id { get; set; }
		/// <summary>技能名称</summary>
		[ProtoMember(2)]
		public string Name { get; set; }
		/// <summary>技能描述</summary>
		[ProtoMember(3)]
		public string Describe { get; set; }
		/// <summary>技能等级</summary>
		[ProtoMember(4)]
		public int Level { get; set; }
		/// <summary>技能释放类型（1.非读条2.读条,3持续施法）</summary>
		[ProtoMember(5)]
		public int RealizeType { get; set; }
		/// <summary>冷却时间(ms)</summary>
		[ProtoMember(6)]
		public int ColdTime { get; set; }
		/// <summary>打断级别（0不可打断，1只可自身打断，3被攻击打断，4被控制打断）</summary>
		[ProtoMember(7)]
		public int StopType { get; set; }
		/// <summary>读条时间</summary>
		[ProtoMember(8)]
		public int RealizeTime { get; set; }
		/// <summary>XP消耗</summary>
		[ProtoMember(9)]
		public int XPCost { get; set; }
		/// <summary>HP消耗</summary>
		[ProtoMember(10)]
		public int HPCost { get; set; }
		/// <summary>MP消耗</summary>
		[ProtoMember(11)]
		public int MPCost { get; set; }
		/// <summary>子弹类型</summary>
		[ProtoMember(12)]
		public int BulletType { get; set; }
		/// <summary>立即Action几率(分母100)</summary>
		[ProtoMember(14)]
		public int ActionProper { get; set; }
		/// <summary>立即ActionId</summary>
		[ProtoMember(15)]
		public int ActionId { get; set; }
		/// <summary>回调技能几率(分母100)</summary>
		[ProtoMember(16)]
		public int SkillProperty { get; set; }
		/// <summary>回调技能id</summary>
		[ProtoMember(17)]
		public int CallBackSkillId { get; set; }
		/// <summary>添加buff几率(分母100)</summary>
		[ProtoMember(18)]
		public int BuffProper { get; set; }
		/// <summary>添加buffid</summary>
		[ProtoMember(19)]
		public int BuffId { get; set; }
		/// <summary>为目标添加buff几率(分母100)</summary>
		[ProtoMember(20)]
		public int TargetBuffProper { get; set; }
		/// <summary>为目标添加buffid</summary>
		[ProtoMember(21)]
		public int TargetBuffId { get; set; }
		/// <summary>目标选择类型(1.仅自身，2.仅选中单个目标，3.自身周围目标 4.指定中心周围目标)</summary>
		[ProtoMember(22)]
		public int ChoosType { get; set; }
		/// <summary>影响目标类型组合id</summary>
		[ProtoMember(23)]
		public int EffectTypeStructId { get; set; }
		/// <summary>最大伤害距离</summary>
		[ProtoMember(25)]
		public int DamageDis { get; set; }
		/// <summary>释放Action组合列表</summary>
		[ProtoMember(26)]
		public int[] ReaActionStructs { get; set; }
		/// <summary>释放Action列表</summary>
		[ProtoMember(27)]
		public int[] ReaActions { get; set; }
		/// <summary>命中Action组合列表</summary>
		[ProtoMember(28)]
		public int[] HitActionStructs { get; set; }
		/// <summary>命中Action列表</summary>
		[ProtoMember(29)]
		public int[] HitActions { get; set; }

	}
}
