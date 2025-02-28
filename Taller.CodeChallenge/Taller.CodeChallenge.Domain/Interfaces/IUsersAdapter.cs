using Taller.CodeChallenge.Domain.AggregateModels.Request;

namespace Taller.CodeChallenge.Domain.Interfaces
{
    public interface IUsersAdapter
    {
        Task<List<UserModel>> GetUsers(string userName, CancellationToken cancellationToken);
        Task<Guid> AddUsers(UserModelToAdd userModel, CancellationToken cancellationToken);
        Task<bool> DeleteUsersById(Guid idUser, CancellationToken cancellationToken);
    }
}
