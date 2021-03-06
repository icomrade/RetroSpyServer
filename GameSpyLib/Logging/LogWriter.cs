﻿using GameSpyLib.Common;
using GameSpyLib.Extensions;
using GameSpyLib.RetroSpyConfig;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;

namespace GameSpyLib.Logging
{

    /// <summary>
    /// Provides an object wrapper for a file that is used to
    /// store LogMessage's into. Uses a Multi-Thread safe Queueing
    /// system, and provides full Asynchronous writing and flushing
    /// </summary>
    public class LogWriter
    {

        public static Logger Log { get; protected set; }

        static LogWriter()
        {
            switch (ConfigManager.Config.MinimumLogLevel)
            {
                case LogEventLevel.Verbose:
                    Log = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console(
               outputTemplate: "{Timestamp:[HH:mm:ss]} [{Level:u4}] {Message:}{NewLine}{Exception}")
                .WriteTo.File($"Logs/[{ServerManagerBase.ServerName}]-.log",
                outputTemplate: "{Timestamp:[yyyy-MM-dd HH:mm:ss]} [{Level:u4}] {Message:}{NewLine}{Exception}", rollingInterval: RollingInterval.Day)
                .CreateLogger();
                    break;
                case LogEventLevel.Information:
                    Log = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console(
               outputTemplate: "{Timestamp:[HH:mm:ss]} [{Level:u4}] {Message:}{NewLine}{Exception}")
                .WriteTo.File($"Logs/[{ServerManagerBase.ServerName}]-.log",
                outputTemplate: "{Timestamp:[yyyy-MM-dd HH:mm:ss]} [{Level:u4}] {Message:}{NewLine}{Exception}", rollingInterval: RollingInterval.Day)
                .CreateLogger();
                    break;
                case LogEventLevel.Debug:
                    Log = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(
               outputTemplate: "{Timestamp:[HH:mm:ss]} [{Level:u4}] {Message:}{NewLine}{Exception}")
                .WriteTo.File($"Logs/[{ServerManagerBase.ServerName}]-.log",
                outputTemplate: "{Timestamp:[yyyy-MM-dd HH:mm:ss]} [{Level:u4}] {Message:}{NewLine}{Exception}", rollingInterval: RollingInterval.Day)
                .CreateLogger();
                    break;
                case LogEventLevel.Warning:
                    Log = new LoggerConfiguration()
                .MinimumLevel.Warning()
                .WriteTo.Console(
               outputTemplate: "{Timestamp:[HH:mm:ss]} [{Level:u4}] {Message:}{NewLine}{Exception}")
                .WriteTo.File($"Logs/[{ServerManagerBase.ServerName}]-.log",
                outputTemplate: "{Timestamp:[yyyy-MM-dd HH:mm:ss]} [{Level:u4}] {Message:}{NewLine}{Exception}", rollingInterval: RollingInterval.Day)
                .CreateLogger();
                    break;
                case LogEventLevel.Error:
                    Log = new LoggerConfiguration()
                .MinimumLevel.Error()
                .WriteTo.Console(
               outputTemplate: "{Timestamp:[HH:mm:ss]} [{Level:u4}] {Message:}{NewLine}{Exception}")
                .WriteTo.File($"Logs/[{ServerManagerBase.ServerName}]-.log",
                outputTemplate: "{Timestamp:[yyyy-MM-dd HH:mm:ss]} [{Level:u4}] {Message:}{NewLine}{Exception}", rollingInterval: RollingInterval.Day)
                .CreateLogger();
                    break;
                case LogEventLevel.Fatal:
                    Log = new LoggerConfiguration()
                .MinimumLevel.Fatal()
                .WriteTo.Console(
               outputTemplate: "{Timestamp:[HH:mm:ss]} [{Level:u4}] {Message:}{NewLine}{Exception}")
                .WriteTo.File($"Logs/[{ServerManagerBase.ServerName}]-.log",
                outputTemplate: "{Timestamp:[yyyy-MM-dd HH:mm:ss]} [{Level:u4}] {Message:}{NewLine}{Exception}", rollingInterval: RollingInterval.Day)
                .CreateLogger();
                    break;
            }
        }

        /// <summary>
        /// Convient to print log
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        public static void ToLog(LogEventLevel level, string message)
        {
            switch (level)
            {
                case LogEventLevel.Verbose:
                    Log.Verbose($"[{ServerManagerBase.ServerName}] " + message);
                    break;
                case LogEventLevel.Information:
                    Log.Information($"[{ServerManagerBase.ServerName}] " + message);
                    break;
                case LogEventLevel.Debug:
                    Log.Debug($"[{ServerManagerBase.ServerName}] " + message);
                    break;
                case LogEventLevel.Error:
                    Log.Error($"[{ServerManagerBase.ServerName}] " + message);
                    break;
                case LogEventLevel.Fatal:
                    Log.Fatal($"[{ServerManagerBase.ServerName}] " + message);
                    break;
                case LogEventLevel.Warning:
                    Log.Warning($"[{ServerManagerBase.ServerName}] " + message);
                    break;
            }
        }

        public static void ToLog(Exception e)
        {
            ToLog(LogEventLevel.Error, e.ToString());
        }

        public static void ToLog(string message)
        {
            ToLog(LogEventLevel.Information, message);
        }

        public static void UnknownDataRecieved(string data)
        {
            ToLog(LogEventLevel.Error, $"[Unknown] {data}");
        }
        public static void UnknownDataRecieved(byte[] data)
        {
            ToLog(LogEventLevel.Error, $"[Unknown] {StringExtensions.ReplaceUnreadableCharToHex(data)}");
        }

        public static void LogCurrentClass(object param)
        {
            ToLog(LogEventLevel.Verbose, $"[ => ] [{param.GetType().Name}]");
        }
    }

}
