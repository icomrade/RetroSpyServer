﻿using GameSpyLib.Common.Entity.Interface;
using QueryReport.Entity.Structure;
using QueryReport.Entity.Structure.Packet;
using QueryReport.Server;
using System;
using System.Linq;

namespace QueryReport.Handler.CommandHandler.KeepAlive
{
    public class KeepAliveHandler : QRCommandHandlerBase
    {
        public KeepAliveHandler(ISession session, byte[] recv) : base(session, recv)
        {
        }

        protected override void ConstructeResponse()
        {
            KeepAlivePacket packet = new KeepAlivePacket();
            packet.Parse(_recv);
            _sendingBuffer = packet.GenerateResponse();
            QRSession client = (QRSession)_session.GetInstance();
            var result = GameServer.GetServers(client.RemoteEndPoint);
            if (result.Count != 1)
            {
                _errorCode = Entity.Enumerator.QRErrorCode.Database;
                return;
            }

            GameServer gameServer = result.First();

            gameServer.LastPacket = DateTime.Now;

            GameServer.UpdateServer
                (
                client.RemoteEndPoint,
                gameServer.ServerData.KeyValue["gamename"],
                gameServer);
        }
    }
}
