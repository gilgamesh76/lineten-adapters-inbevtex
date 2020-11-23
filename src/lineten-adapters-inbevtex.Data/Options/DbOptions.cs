using System;

namespace lineten_adapters_inbevtex.Data.Options
{
    /// <summary>
    /// Represents strongly typed environment configuration
    /// </summary>
    public class DbOptions
    {
        public string DbServer { get; set; }
        public string DbUsername { get; set; }
        public string DbPassword { get; set; }
        public string DbDatabase { get; set; }
    }
}
