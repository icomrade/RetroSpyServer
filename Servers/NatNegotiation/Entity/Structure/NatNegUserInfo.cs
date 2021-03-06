﻿using NatNegotiation.Entity.Structure.Packet;
using System;
using System.Net;

namespace NatNegotiation.Entity.Structure
{
    public class NatNegUserInfo
    {
        public byte Version;
        public int Cookie;
        public byte ClientIndex;
        public byte PortType;
        public bool IsConnected;
        public bool IsGotInit;
        public bool IsGotConnectAck;
        public bool IsGotErtAck;
        public bool IsGotReport;
        public GameInfo Game;
        public string GameName;

        public int InternalIP;
        public short InternalPort;

        public DateTime ConnectPacketTime;
        public DateTime LastPacketTime;
        public DateTime SentConnectPacketTime;

        public NatNegUserInfo TargetClient;

        public NatNegUserInfo()
        {
            LastPacketTime = DateTime.Now;
        }

        public void Parse(InitPacket init)
        {
            Version = init.Version;
            Cookie = init.Cookie;
            PortType = init.PortType;
            ClientIndex = init.ClientIndex;
            IsGotInit = true;
        }

        public void Parse(ConnectPacket connect)
        {

        }
    }
}
