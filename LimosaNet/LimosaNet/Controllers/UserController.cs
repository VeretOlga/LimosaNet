using LN.Application.Features.Users;
using LN.Contracts.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LimosaNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IMediator _mediator;

        public UserController(ILogger<AuthController> logger, IMediator mediator) {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task RegisterUser([FromBody] UserCreateDto userDto, CancellationToken token)=> 
            await _mediator.Send(new UserRegisterCommand.Command { UserModel = userDto }, token);


        /// <summary>
        /// удаление пользователя
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task DeleteUser(int id, CancellationToken token) =>
            await _mediator.Send(new UserDeleteCommand.Command { Id = id }, token);


        /// <summary>
        /// Получение списка пользователей
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<List<UserViewDto>> UserList(CancellationToken token) =>
            await _mediator.Send(UserListQuery.Query.Instance, token);

        /// <summary>
        /// Получение пользователя по id
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<UserViewDto> UserByIdt(int id, CancellationToken token) =>
            await _mediator.Send(new UserByIdQuery.Query { Id = id },token);


        
    }
}
