using LN.Application.Features.Auth;
using LN.Contracts.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace LimosaNet.Controllers
{

    [ApiController]
    [Route("[controller]")]   
    public class AuthController : ControllerBase
    {
        
        private readonly ILogger<AuthController> _logger;
        private readonly IMediator _mediator;

        public AuthController(ILogger<AuthController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;   
        }

        /// <summary>
        /// Авторизация пользователя по логину и паролю
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<string> Login([FromBody] LoginDto credentials, CancellationToken token)
            =>await _mediator.Send(new Login.Command { LoginModel = credentials }, token);
       
        
    }
}