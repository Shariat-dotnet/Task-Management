namespace TaskManagement.Core.ConfigurationSettings
{
    public class AppSettings
    {
       
        //public bool IsWriteLog { get; set; }
        public string AllowedHosts { get; set; }
        public PostgreSql PostgreSql { get; set; }
        public Logging Logging { get; set; }
    }

    public class PostgreSql
    {
        public string db_conn_string { get; set; }
        public string password { get; set; }
    }
    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }
    public class LogLevel
    {
        public string Default { get; set; }
        public string Microsoft { get; set; }
        public string Lifetime { get; set; }
    }
}
