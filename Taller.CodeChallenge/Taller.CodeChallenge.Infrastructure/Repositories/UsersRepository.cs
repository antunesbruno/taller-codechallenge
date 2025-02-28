using Microsoft.EntityFrameworkCore;
using Taller.CodeChallenge.Domain.Entities;
using Taller.CodeChallenge.Domain.Interfaces;
using Taller.CodeChallenge.Infrastructure.Repositories.DbContext;

namespace Taller.CodeChallenge.Infrastructure.Repositories
{
    public class UsersRepository : BaseRepository<Users>, IUsersRepository
    {
        protected readonly DbContextInMemory context;

        public UsersRepository(DbContextInMemory context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<List<Users>> GetUsers(string userName)
        {
            return await context.Users.Where(s => s.UserName.ToLower().Contains(userName)).ToListAsync();
        }

        public async Task<Guid> AddUser(Users user)
        {
            await InsertEntity(user);

            return user.Id;
        }

        public async Task<bool> DeleteUser(Guid idUser)
        {
            return await DeleteById(idUser);            
        }
    }
}
