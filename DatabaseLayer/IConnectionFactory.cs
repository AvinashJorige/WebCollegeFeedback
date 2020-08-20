using System.Data;

namespace DatabaseLayer
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}
