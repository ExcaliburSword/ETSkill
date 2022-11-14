using System;


namespace ET
{
    public static class LoginHelper
    {
        public static async ETTask Login(Scene zoneScene, string address, string account, string password)
        {
            try
            {
                // 创建一个ETModel层的Session
                R2C_Login r2CLogin;
                Session session = null;
                try
                {
                    session = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(address));
                    {
                        r2CLogin = (R2C_Login) await session.Call(new C2R_Login() { Account = account, Password = password });
                    }
                }
                finally
                {
                    session?.Dispose();
                }

                // 创建一个gate Session,并且保存到SessionComponent中
                Session gateSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(r2CLogin.Address));
                gateSession.AddComponent<PingComponent>();
                zoneScene.AddComponent<SessionComponent>().Session = gateSession;
				
                G2C_LoginGate g2CLoginGate = (G2C_LoginGate)await gateSession.Call(
                    new C2G_LoginGate() { Key = r2CLogin.Key, GateId = r2CLogin.GateId});

                Log.Debug("登陆gate成功!");

                Game.EventSystem.PublishAsync(new EventType.LoginFinish() {ZoneScene = zoneScene}).Coroutine();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }  
        public static async ETTask Login1(Scene zoneScene, string address)
        {
            Session session = null;
            R2C_Test01 r2CTest01 = null;
            session= zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(address));
            r2CTest01=  (R2C_Test01)  await session.Call(new C2R_Test01() { Account = "as", Password = "s12 s" });
            Log.Debug("................"+r2CTest01.Key+"||||||||||||||||||||||");
            session.Send(new C2R_Test02(){Hello = "hel"});
        } 
    }
}