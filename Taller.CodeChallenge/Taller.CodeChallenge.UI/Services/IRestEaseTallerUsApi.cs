using RestEase;
using Taller.CodeChallenge.Domain.AggregateModels.Request;

namespace Taller.CodeChallenge.UI.Services
{
    public interface IRestEaseTallerUsApi
    {
        [Get("/taller-codechallenge-api/get-users-by-name?userName={userName}")]
        Task<HttpResponseMessage> GetUserNameAsync([Path] string userName, CancellationToken cancellationToken);
    }
}
