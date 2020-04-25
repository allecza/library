using Npgsql;

namespace ShopOnline.DataAccess
{
    public class DataBaseConnectionService
    {
        public string HostAddress { get; set; }
        public string  HostName { get; set; }
        public string HostPassword { get; set; }
        public string DatabaseName { get; set; }
        
        public DataBaseConnectionService(string hostAddress, string hostName, string hostPassword, string databaseName)
        {
            HostAddress = hostAddress;
            HostName = hostName;
            HostPassword = hostPassword;
            DatabaseName = databaseName;
        }

        public NpgsqlConnection GetDatabaseConnectionObject()
        {
            var connectionString = $"Host={HostAddress};Username={HostName};Password={HostPassword};Database={DatabaseName}";
            return new NpgsqlConnection(connectionString);
        }
    }
}
