using FluentValidation;
using LN.Contracts.DataProviders;
using MediatR;

namespace LN.Application.Features.Users
{
    /// <summary>
    /// Удаление пользователя
    /// </summary>
    public static class UserDeleteCommand
    {
        public sealed class Command : IRequest<int>
        {
            public int Id { get; set; }
        }


        public sealed class UserDeleteCommandValidation : AbstractValidator<Command>
        {
            public UserDeleteCommandValidation()
            {
                RuleFor(_ => _.Id).GreaterThan(-1);
            }
        }


        public sealed class UserDeleteCommandHandler : IRequestHandler<Command, int>
        {

            private readonly IUserProvider _userProvider;

            public UserDeleteCommandHandler(IUserProvider userProvider)
            {
                _userProvider = userProvider;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _userProvider.DeleteUser(request.Id);
            }
        }
    }
}
