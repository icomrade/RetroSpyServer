﻿using System;
using System.Collections.Generic;
using System.Linq;
using GameSpyLib.Extensions;

namespace Chat.Entity.Structure.ChatCommand
{
    /// <summary>
    /// Retrieves a list of global key/value for a single user, or all users.
    /// </summary>
    public class GETKEY : ChatCommandBase
    {
        public GETKEY()
        {
            Keys = new List<string>();
        }

        public string Target { get; protected set; }
        public string Cookie { get; protected set; }

        public List<string> Keys { get; protected set; }

        public override bool Parse(string request)
        {
            if (!base.Parse(request))
            { return false; }

            if (_cmdParams.Count < 3)
            {
                return false;
            }

            if (_longParam == null)
            {
                return false;
            }

            if (_longParam.Last() != '\0')
            {
                return false;
            }

            Target = _cmdParams[0];
            Cookie = _cmdParams[1];

            _longParam = _longParam.Substring(0, _longParam.Length - 2);

            Keys = StringExtensions.ConvertKeyStrToList(_longParam);

            return true;
        }
    }
}
