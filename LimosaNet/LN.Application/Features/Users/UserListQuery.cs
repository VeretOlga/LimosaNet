using AutoMapper;
using LN.Contracts.DataProviders;
using LN.Contracts.Models;
using MediatR;

namespace LN.Application.Features.Users
{
    /// <summary>
    /// Метод получения всех пользователей
    /// </summary>
    public static class UserListQuery
    {
        public sealed class Query : IRequest<List<UserViewDto>>
        {
            public static readonly Query Instance = new Query();
        }


        /// <summary>
        /// Обработчик запроса получения информации о лицензии
        /// </summary>
        public sealed class UserListQueryHandler : IRequestHandler<Query, List<UserViewDto>>
        {

            private readonly IUserProvider _userProvider;
            private readonly IMapper _mapper;

            public UserListQueryHandler(IUserProvider userProvider, IMapper mapper) 
            {
                _userProvider = userProvider;
                _mapper       = mapper;
            }

            public async Task<List<UserViewDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var usersEntity = await _userProvider.GetUsers();
                return usersEntity.Select(_mapper.Map<UserViewDto>).OrderBy(b => b.Id).ToList();
            }
        }
    }
}
