using Taller.CodeChallenge.Domain.Interfaces;
using Taller.CodeChallenge.Infrastructure.Repositories.DbContext;

namespace Taller.CodeChallenge.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity : class
    {
        private readonly DbContextInMemory _context;

        private bool isDisposed;

        public BaseRepository(DbContextInMemory context)
        {
            this._context = context;
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

       
        public async Task InsertEntity(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            await _context.SaveChangesAsync();
        }        

        public async Task<bool> DeleteById(Guid id)
        {
            var item = await GetById(id);

            if (item != null)
            {
                _context.Set<TEntity>().Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }      

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed) return;

            if (disposing)
            {             
                _context.Dispose();
            }          

            isDisposed = true;
        }
    }
}
