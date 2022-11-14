﻿using System;

namespace ET
{
    [ActorMessageHandler]
    public abstract class AMActorLocationRpcHandler<E, Request, Response>: IMActorHandler where E : Entity where Request : class, IActorLocationRequest where Response : class, IActorLocationResponse
    {
        protected abstract ETTask Run(E unit, Request request, Response response, System.Action reply);

        public async ETTask Handle(Entity entity, object actorMessage, Action<IActorResponse> reply)
        {
            try
            {
                Request request = actorMessage as Request;
                if (request == null)
                {
                    Log.Error($"消息类型转换错误: {actorMessage.GetType().FullName} to {typeof (Request).Name}");
                    return;
                }

                E ee = entity as E;
                if (ee == null)
                {
                    Log.Error($"Actor类型转换错误: {entity.GetType().Name} to {typeof (E).Name} --{typeof (Request).Name}");
                    return;
                }

                int rpcId = request.RpcId;
                Response response = Activator.CreateInstance<Response>();

                void Reply()
                {
                    response.RpcId = rpcId;
                    reply.Invoke(response);
                }

                try
                {
                    await this.Run(ee, request, response, Reply);
                }
                catch (Exception exception)
                {
                    Log.Error(exception);
                    response.Error = ErrorCore.ERR_RpcFail;
                    response.Message = exception.ToString();
                    Reply();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"解释消息失败: {actorMessage.GetType().FullName}", e);
            }
        }

        public Type GetRequestType()
        {
            return typeof (Request);
        }

        public Type GetResponseType()
        {
            return typeof (Response);
        }
    }
}