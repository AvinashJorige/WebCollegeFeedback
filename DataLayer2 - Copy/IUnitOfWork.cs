namespace DataLayer
{
    public interface IUnitOfWork
    {
        void Dispose();

        void SaveChanges();
    }
}
