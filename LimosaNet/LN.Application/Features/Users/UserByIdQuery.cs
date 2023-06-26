using AutoMapper;
using FluentValidation;
using LN.Contracts.DataProviders;
using LN.Contracts.Models;
using MediatR;

namespace LN.Application.Features.Users
{
    /// <summary>
    /// получение пользователя по ID
    /// </summary>
    public static class UserByIdQuery
    {
        public sealed class Query : IRequest<UserViewDto>
        {
            public int Id { get; set; }
        }

        public sealed class UserByIdQueryValidation : AbstractValidator<Query>
        {
            public UserByIdQueryValidation()
            {
                RuleFor(_ => _.Id).GreaterThan(-1);
            }
        }

        public sealed class UserByIdQueryHandler : IRequestHandler<Query, UserViewDto>
        {

            private readonly IUserProvider _userProvider;
            private readonly IMapper _mapper;

            public UserByIdQueryHandler(IUserProvider userProvider, IMapper mapper) 
            {
                _userProvider = userProvider;
                _mapper = mapper;
            }

            public async Task<UserViewDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var enitity = await _userProvider.GetUserById(request.Id);
                return _mapper.Map<UserViewDto>(enitity);
            }
        }
    }
}
