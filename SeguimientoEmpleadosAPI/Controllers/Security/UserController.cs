using Dtos.Commons;
using Dtos.Security.Credential;
using Dtos.Security.Login;
using Dtos.Security.User;
using Facade.Security.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SeguimientoEmpleadosAPI.Controllers.Security
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserFacade user;

        public UserController(IUserFacade user)
        {
            this.user = user;
        }
        [ProducesResponseType(typeof(ResponseDto<List<UserDto>>), (int)HttpStatusCode.OK, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<UserDto>>), (int)HttpStatusCode.OK, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<UserDto>>), (int)HttpStatusCode.NotFound, "application/json")]
        [HttpGet]
        public async Task<ResponseDto<List<UserDto>>> GetAll()
        {
            return await user.GetAll();
        }

        [ProducesResponseType(typeof(ResponseDto<List<UserDto>>), (int)HttpStatusCode.OK, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<UserDto>>), (int)HttpStatusCode.OK, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<UserDto>>), (int)HttpStatusCode.NotFound, "application/json")]
        [HttpGet("id")]
        public async Task<ResponseDto<UserDto>> GetById(Guid id)
        {
            return await user.GetById(id);
        }

        [ProducesResponseType(typeof(ResponseDto<List<UserDto>>), (int)HttpStatusCode.OK, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<UserDto>>), (int)HttpStatusCode.Created, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<UserDto>>), (int)HttpStatusCode.NotFound, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<UserDto>>), (int)HttpStatusCode.InternalServerError, "application/json")]
        [HttpPost]
        public async Task<ResponseDto<UserDto>> Post(UserDto model)
        {
            return await user.Post(model);
        }

        [ProducesResponseType(typeof(ResponseDto<List<UserDto>>), (int)HttpStatusCode.OK, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<UserDto>>), (int)HttpStatusCode.OK, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<UserDto>>), (int)HttpStatusCode.NotFound, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<UserDto>>), (int)HttpStatusCode.InternalServerError, "application/json")]
        [HttpPut("{id:Guid}/id")]
        public async Task<ResponseDto<UserDto>> Put(Guid id, UserDto model)
        {
            return await user.Put(id, model);
        }
    }
}
