using AutoMapper;
using Taller.CodeChallenge.Domain.AggregateModels.Request;
using Taller.CodeChallenge.Domain.Entities;
using Taller.CodeChallenge.Domain.Interfaces;

namespace Taller.CodeChallenge.Infrastructure.Adapters
{
    public class UsersAdapter : IUsersAdapter
    {
        public readonly IUsersRepository _usersRepository;
        public readonly IMapper _mapper;

        public UsersAdapter(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<Guid> AddUsers(UserModelToAdd userModel, CancellationToken cancellationToken)
        {
            var userEntity = _mapper.Map<UserModelToAdd, Users>(userModel);
            return await _usersRepository.AddUser(userEntity);
        }

        public async Task<bool> DeleteUsersById(Guid idUser, CancellationToken cancellationToken)
        {
            return await _usersRepository.DeleteUser(idUser);            
        }

        public async Task<List<UserModel>> GetUsers(string userName, CancellationToken cancellationToken)
        {
            var users = await _usersRepository.GetUsers(userName);

            return _mapper.Map<List<Users>, List<UserModel>>(users);
        }
    }
}




