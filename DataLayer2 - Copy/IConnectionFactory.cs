using System.Data;

namespace DataLayer
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}
