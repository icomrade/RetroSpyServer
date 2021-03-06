﻿using QueryReport.Entity.Enumerator;

namespace QueryReport.Handler.SystemHandler.ErrorMessage
{
    public class ErrorMessage
    {
        public static string GetErrorMessage(QRErrorCode error)
        {
            switch (error)
            {
                case QRErrorCode.Parse:
                    return "Request parse error!";

                case QRErrorCode.General:
                    return "General error!";

                case QRErrorCode.Database:
                    return "Database error!";

                case QRErrorCode.Network:
                    return "Network error!";

                default:
                    return "Unknown error!";
            }
        }
    }
}
