namespace ET
{
    public static partial class ErrorCode
    {
        public const int ERR_Success = 0;

        // 1-11004 是SocketError请看SocketError定义
        //-----------------------------------
        // 100000-109999是Core层的错误
        
        // 110000以下的错误请看ErrorCore.cs
        
        // 这里配置逻辑层的错误码
        // 110000 - 200000是抛异常的错误
        // 200001以上不抛异常

        #region 技能错误
        public const int ERR_SkillSuccess = 0;
        public const int ERR_HasNoSkill = 201001;
        public const int ERR_SkillCostNotEnough = 201002;
        public const int ERR_BanSkillArea = 201003;
        public const int ERR_BeSilenced = 201004;
        public const int ERR_CantUseTarget = 201005;
        public const int ERR_OutOfSkillRange = 201006;
        public const int ERR_SkillColding = 201007;
        public const int ERR_LosePlayerInfo = 201008;
        public const int ERR_SkillBroken = 201009;
        #endregion
      

    }
}