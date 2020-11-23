using LineTen.DataAccess.EntityFramework.Repository;

namespace lineten_adapters_inbevtex.Data.Database
{
    public class ApplicationRepository<TEntity> :Repository<TEntity, ApplicationDbContext> where TEntity : class, new()
    {
        public ApplicationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
