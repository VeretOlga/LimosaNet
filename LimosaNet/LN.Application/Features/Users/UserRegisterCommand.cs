using AutoMapper;
using FluentValidation;
using LN.Contracts.DataProviders;
using LN.Contracts.Models;
using LN.Contracts.Service;
using LN.Core.Entities;
using MediatR;

namespace LN.Application.Features.Users
{
    public static class UserRegisterCommand
    {
        public sealed class Command:IRequest<int>
        {
            public UserCreateDto UserModel { get; set; }
        }


        public sealed class UserRegisterValidation: AbstractValidator<Command>
        {
            public UserRegisterValidation() 
            {
                RuleFor(x => x.UserModel.FirstName).NotEmpty();
                RuleFor(x => x.UserModel.SecondName).NotEmpty();
                RuleFor(x => x.UserModel.Old).GreaterThan(0);

            }
        }

        public sealed class UserRegisterCommandHandler: IRequestHandler<Command, int>
        {
            private readonly IAuthService _authService;
            private readonly IUserProvider _userProvider;
            private readonly IMapper _mapper;
            public UserRegisterCommandHandler(IUserProvider userProvider, IMapper mapper, IAuthService authService) 
            {
                _userProvider = userProvider;
                _mapper = mapper;
                _authService = authService;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<UserEntity>(request.UserModel);
                entity.HashPassword = _authService.Hash(request.UserModel.Password);
                return  await _userProvider.RegisterUser(entity);                
            }        
        }
    }
}
