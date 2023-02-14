using ng_MasterDetails.Models;
using ng_MasterDetails.Repositories.Interface;

namespace ng_MasterDetails.Repositories
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        ProductDbContext db;
        public UnitOfWork(ProductDbContext db)
        {
            this.db = db;
        }
        public async Task CompleteAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.db.Dispose();
        }

        public IGenericRepo<T> GetRepo<T>() where T : class, new()
        {
            return new GenericRepo<T>(this.db);
        }
    }
}
