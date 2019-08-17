﻿using System;
using System.Collections.Generic;
using System.Text;
using GameSpyLib.Network;

namespace QueryReport.Handler
{
    public class GameServerHandler
    {
        /// <summary>
        /// Our hardcoded Server Validation code
        /// </summary>
        private static readonly byte[] ServerValidateCode = {
                0x72, 0x62, 0x75, 0x67, 0x4a, 0x34, 0x34, 0x64, 0x34, 0x7a, 0x2b,
                0x66, 0x61, 0x78, 0x30, 0x2f, 0x74, 0x74, 0x56, 0x56, 0x46, 0x64,
                0x47, 0x62, 0x4d, 0x7a, 0x38, 0x41, 0x00
            };


        public static void ServerChallengeResponse(QRServer qRServer, UdpPacket packet)
        {
            byte[] challenge = new byte[90];
            byte[] buffer = packet.BytesRecieved;
            int blen = 0;            
        }
    }
}