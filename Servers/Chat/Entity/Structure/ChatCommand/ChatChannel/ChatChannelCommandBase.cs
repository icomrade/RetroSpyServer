﻿namespace Chat.Entity.Structure.ChatCommand
{
    public class ChatChannelCommandBase : ChatCommandBase
    {
        public string ChannelName { get; protected set; }

        public override bool Parse(string request)
        {
            if (!base.Parse(request))
            {
                return false;
            }
            if (_cmdParams.Count < 1)
            {
                return false;
            }
            ChannelName = _cmdParams[0];
            return true;
        }
    }
}
