﻿using GameSpyLib.Common.Entity.Interface;
using System;
using System.Net;
using System.Text;

namespace GameSpyLib.Network
{
    public abstract class TemplateUdpSession : ISession
    {
        public TemplateUdpServer Server { get; }

        public Guid Id { get; }

        public EndPoint RemoteEndPoint { get; }

        public TemplateUdpSession(TemplateUdpServer server, EndPoint endPoint)
        {
            Id = Guid.NewGuid();
            Server = server;
            RemoteEndPoint = endPoint;
        }

        public object GetInstance()
        {
            return this;
        }

        public long Send(byte[] buffer, long offset, long size)
        {
            return Server.Send(RemoteEndPoint, buffer, offset, size);
        }

        public long Send(byte[] buffer)
        {
            return Server.Send(RemoteEndPoint, buffer);
        }

        public long Send(string buffer)
        {
            return Server.Send(RemoteEndPoint, buffer);
        }

        public bool SendAsync(byte[] buffer, long offset, long size)
        {
            return Server.SendAsync(RemoteEndPoint, buffer, offset, size);
        }

        public bool SendAsync(string text)
        {
            return Server.SendAsync(RemoteEndPoint, Encoding.ASCII.GetBytes(text));
        }

        public bool SendAsync(byte[] buffer)
        {
            return Server.SendAsync(RemoteEndPoint, buffer);
        }

        public bool BaseSendAsync(string buffer)
        {
            return Server.BaseSendAsync(RemoteEndPoint, buffer);
        }

        public bool BaseSendAsync(byte[] buffer)
        {
            return Server.BaseSendAsync(RemoteEndPoint, buffer);
        }

        public bool BaseSendAsync(byte[] buffer, long offset, long size)
        {
            return Server.BaseSendAsync(RemoteEndPoint, buffer, offset, size);
        }

    }
}
