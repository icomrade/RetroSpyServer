﻿using GameSpyLib.Common.Entity.Interface;
using GameSpyLib.Logging;

namespace GameSpyLib.Common.BaseClass
{
    public abstract class CommandHandlerBase
    {
        protected ISession _session;
        public CommandHandlerBase(ISession session)
        {
            _session = session;
        }

        public virtual void Handle()
        {
            LogWriter.LogCurrentClass(this);
        }
    }
}
