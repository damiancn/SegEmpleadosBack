using Dtos.Commons;
using Dtos.Security.Credential;
using Dtos.Security.Login;
using Dtos.Security.User;
using Facade.Security.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SeguimientoEmpleadosAPI.Controllers.Security
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserFacade user;
        private readonly IConfiguration config;

        public LoginController(IUserFacade user, IConfiguration config)
        {
            this.user = user;
            this.config = config;
        }

        [ProducesResponseType(typeof(ResponseDto<List<UserDto>>), (int)HttpStatusCode.OK, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<UserDto>>), (int)HttpStatusCode.NotFound, "application/json")]
        [HttpPost("login")]
        public async Task<ResponseDto<CredentialDto>> Login(LoginDto login)
        {
            login.Key = this.config["ConfiguracionJWT:Key"];
            login.Audience = this.config["ConfiguracionJWT:Audience"];
            login.Issuer = this.config["ConfiguracionJWT:Issuer"];
            return await user.GetMenu(login);
        }
    }
}
