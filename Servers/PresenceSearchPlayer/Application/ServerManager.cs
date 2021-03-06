﻿using GameSpyLib.Common;
using GameSpyLib.Extensions;
using GameSpyLib.Logging;
using System;
using System.Net;

namespace PresenceSearchPlayer
{
    /// <summary>
    /// A factory that create the instance of servers
    /// </summary>
    public class ServerManager : ServerManagerBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serverName">Server name in XML config file</param>
        public ServerManager(RetroSpyServerName serverName) : base(serverName)
        {
        }

        /// <summary>
        /// Starts a specific server
        /// </summary>
        /// <param name="cfg">The configuration of the specific server to run</param>
        protected override void StartServer(GameSpyLib.RetroSpyConfig.ServerConfig cfg)
        {
            if (cfg.Name == ServerName)
            {
                Server = new GPSPServer(IPAddress.Parse(cfg.ListeningAddress), cfg.ListeningPort).Start();
                Console.WriteLine(
                    StringExtensions.FormatServerTableContext(cfg.Name, cfg.ListeningAddress, cfg.ListeningPort.ToString()));
            }
        }
    }
}
