using DatabaseLayer;

namespace ServiceLayer
{
    public static class ConnectionHelper
    {
        public static IConnectionFactory GetConnection()
        {
            return new DbConnectionFactory("LocalConnection");
        }
    }
}
