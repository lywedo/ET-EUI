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
        public const int ERR_NetorkError = 200002;
        public const int ERR_LoginInfoError = 200003;
        public const int ERR_AccountNameFormError = 200004;
        public const int ERR_PassswordFormError = 200005;
        public const int ERR_AccountIntBlackListError = 200006;
        public const int ERR_LoginPasswordError = 200007; //登陆密码错误
        public const int ERR_RequestRepeatedly = 200008;
        public const int ERR_TokenError = 200009;
        public const int ERR_RoleNameIsNull = 200010; //游戏角色名字为空
        public const int ERR_RoleNameSame = 200011;
        public const int ERR_RoleNotExit = 200012; //游戏角色不存在
        public const int ERR_ConnectGateKeyError = 200013; //连接Gate的令牌错误
        public const int ERR_RequestSceneTypeError = 200014; //请求的Scene错误
    }
}