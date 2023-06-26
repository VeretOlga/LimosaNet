using LN.Contracts.DataProviders;
using LN.Contracts.Models;
using LN.Contracts.Service;
using MediatR;

namespace LN.Application.Features.Auth
{
    /// <summary>
    /// Команда для логина по паролю и логину
    /// </summary>
    public static class Login
    {
        public sealed  class Command:IRequest <string>
        {
            public LoginDto LoginModel{ get; set; }
        }

        public sealed class LoginCommandHandler: IRequestHandler<Command, string>
        {
            private readonly IAuthService _authService;
            private readonly IUserProvider _userProvider;
            public LoginCommandHandler(IAuthService authService, IUserProvider userProvider)
            {
                _authService = authService;
                _userProvider = userProvider;
            }

            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    //поиск пользователя по логину
                    var entity =await _userProvider.GetUserByEmail(request.LoginModel.Email.Trim());
                    //проверка пароля
                    var verify = _authService.Verify(request.LoginModel.Password, entity.HashPassword);
                    //формирование токена
                    if (verify)  return _authService.GenerateToken(request.LoginModel.Email);
                    
                    return string.Empty;
                }
                catch(Exception ex)
                {
                    return string.Empty;
                }
                

                
            }
        }
    }
}
