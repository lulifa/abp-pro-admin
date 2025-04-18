﻿using Microsoft.Extensions.Logging;

namespace RuiChen.AbpPro.Logging
{
    public class LogInfo
    {

        public DateTime TimeStamp { get; set; }
        public LogLevel Level { get; set; }
        public string Message { get; set; }
        public LogField Fields { get; set; }
        public List<LogException> Exceptions { get; set; }

    }
}
