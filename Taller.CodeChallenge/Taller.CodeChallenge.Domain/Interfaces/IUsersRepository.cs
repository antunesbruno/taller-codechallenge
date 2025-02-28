using Taller.CodeChallenge.Domain.Entities;

namespace Taller.CodeChallenge.Domain.Interfaces
{
    public interface IUsersRepository
    {
        Task<List<Users>> GetUsers(string userName);
        Task<Guid> AddUser(Users user);
        Task<bool> DeleteUser(Guid idUser);
    }
}
