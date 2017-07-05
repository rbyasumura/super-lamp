﻿namespace Advance.Framework.Loggers.Interfaces
{
    public interface ILogger
    {
        void Log(string message);

        void Log(string format, params object[] args);
    }
}
