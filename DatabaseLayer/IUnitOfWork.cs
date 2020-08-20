namespace DatabaseLayer
{
    public interface IUnitOfWork
    {
        void Dispose();

        void SaveChanges();
    }
}
