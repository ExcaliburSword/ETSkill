using System;

namespace ET
{
    [MessageHandler]
    public class C2R_Test01Handler: AMRpcHandler<C2R_Test01,R2C_Test01>
    {
        protected override async ETTask Run(Session session, C2R_Test01 request, R2C_Test01 response, System.Action reply)
        {
            response.Key = "a张三asdasd";
            reply();
            await ETTask.CompletedTask;
        }
    }
}