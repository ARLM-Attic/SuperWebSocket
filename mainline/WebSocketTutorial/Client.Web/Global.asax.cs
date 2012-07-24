using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using SuperSocket.Common;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketEngine;
using SuperSocket.SocketEngine.Configuration;
using SuperWebSocket;
using Client.Web.CommunicationControllerService;

namespace Client.Web
{
    public class Global : System.Web.HttpApplication
    {        
        private List<WebSocketSession> m_Sessions = new List<WebSocketSession>();
        private List<WebSocketSession> m_SecureSessions = new List<WebSocketSession>();
        private object m_SessionSyncRoot = new object();
        private object m_SecureSessionSyncRoot = new object();
        private Timer m_SecureSocketPushTimer;
        private CommunicationControllerService.WebSocketServiceClient commService;
        void Application_Start(object sender, EventArgs e)
        {
            LogUtil.Setup();
            StartSuperWebSocketByConfig();            
            var ts = new TimeSpan(0, 0, 5);
            m_SecureSocketPushTimer = new Timer(OnSecureSocketPushTimerCallback, new object(), ts, ts); // push sdata from the server every 5 seconds
            commService = new CommunicationControllerService.WebSocketServiceClient();
        }

        void OnSecureSocketPushTimerCallback(object state)
        {
            lock (m_SessionSyncRoot)
            {
                // SendToAll("Push data from SecureWebSocket. Current Time: " + DateTime.Now);                

                ThermoTemps temp = commService.GetTemperatures(null);
                System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                string sJSON = oSerializer.Serialize(temp);

                SendToAll("Computer Update: " + sJSON);
            }
        }

        void StartSuperWebSocketByConfig()
        {
            var serverConfig = ConfigurationManager.GetSection("socketServer") as SocketServiceConfig;
            if (!SocketServerManager.Initialize(serverConfig))
                return;

            var socketServer = SocketServerManager.GetServerByName("SuperWebSocket") as WebSocketServer;
            Application["WebSocketPort"] = socketServer.Config.Port;

            socketServer.CommandHandler += new CommandHandler<WebSocketSession, WebSocketCommandInfo>(socketServer_CommandHandler);
            socketServer.NewSessionConnected += new SessionEventHandler<WebSocketSession>(socketServer_NewSessionConnected);
            socketServer.SessionClosed += new SessionClosedEventHandler<WebSocketSession>(socketServer_SessionClosed);
            if (!SocketServerManager.Start()) SocketServerManager.Stop();
        }

        void socketServer_NewSessionConnected(WebSocketSession session)
        {
            lock (m_SessionSyncRoot)
                m_Sessions.Add(session);

            //SendToAll("System: " + session.Cookies["name"] + " connected");
        }

        void socketServer_SessionClosed(WebSocketSession session, CloseReason reason)
        {
            lock (m_SessionSyncRoot)
                m_Sessions.Remove(session);

            if (reason == CloseReason.ServerShutdown)
                return;

            //SendToAll("System: " + session.Cookies["name"] + " disconnected");
        }

        // sends data
        void socketServer_CommandHandler(WebSocketSession session, WebSocketCommandInfo commandInfo)
        {            
            int? value = (int.Parse(commandInfo.Data.ToString()));
            ThermoTemps temp = commService.GetTemperatures(value);            
            System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string sJSON = oSerializer.Serialize(temp);
            SendToAll(session.Cookies["name"] + ": " + sJSON);

            // SendToAll(session.Cookies["name"] + ": " + commService.ReverseCommunication(commandInfo.Data));
        }

        void SendToAll(string message)
        {
            lock (m_SessionSyncRoot)
            {
                foreach (var s in m_Sessions) s.SendResponseAsync(message);
            }
        }

        void Application_End(object sender, EventArgs e)
        {
            m_SecureSocketPushTimer.Change(Timeout.Infinite, Timeout.Infinite);
            m_SecureSocketPushTimer.Dispose();
            SocketServerManager.Stop();
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
        }
    }
}
