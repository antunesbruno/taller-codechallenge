using AutoMapper;
using Taller.CodeChallenge.Domain.AggregateModels.Request;
using Taller.CodeChallenge.Domain.Entities;

namespace Taller.CodeChallenge.Infrastructure.Adapters.Mapping
{
    public class UsersMap : Profile
    {
        public UsersMap()
        {
            CreateMap<Users, UserModel>()
                .ForMember(dest => dest.IdUser, m => m.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, m => m.MapFrom(src => src.UserName));

            CreateMap<UserModelToAdd, Users>()
                .ForMember(dest => dest.Id, m => Guid.NewGuid())
                .ForMember(dest => dest.UserName, m => m.MapFrom(src => src.UserName))
                .ReverseMap();
        }
    }
}
