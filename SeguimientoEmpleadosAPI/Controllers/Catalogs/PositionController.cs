namespace SeguimientoEmpleadosAPI.Controllers.Catalogs
{
    using Dtos.Catalogs.Position;
    using Dtos.Commons;
    using Facade.Catalogs.Position;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PositionController : ControllerBase
    {
        private readonly IPositionFacade position;
        public PositionController(IPositionFacade position)
        {
            this.position = position;
        }

        [ProducesResponseType(typeof(ResponseDto<List<PositionDto>>), (int)HttpStatusCode.OK, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PositionDto>>), (int)HttpStatusCode.NotFound, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PositionDto>>), (int)HttpStatusCode.InternalServerError, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PositionDto>>), (int)HttpStatusCode.BadRequest, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PositionDto>>), (int)HttpStatusCode.Unauthorized, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PositionDto>>), (int)HttpStatusCode.InternalServerError, "application/json")]
        [HttpGet]
        public async Task<ResponseDto<List<PositionDto>>> GetAll()
        {
            return await position.GetAll();
        }

        [ProducesResponseType(typeof(ResponseDto<List<PositionDto>>), (int)HttpStatusCode.OK, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PositionDto>>), (int)HttpStatusCode.NotFound, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PositionDto>>), (int)HttpStatusCode.InternalServerError, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PositionDto>>), (int)HttpStatusCode.Unauthorized, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PositionDto>>), (int)HttpStatusCode.BadRequest, "application/json")]
        [HttpGet("id")]
        public async Task<ResponseDto<PositionDto>> Get(Guid id)
        {
            return await position.GetById(id);
        }
        [ProducesResponseType(typeof(ResponseDto<List<PositionDto>>), (int)HttpStatusCode.Created, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PositionDto>>), (int)HttpStatusCode.NotFound, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PositionDto>>), (int)HttpStatusCode.InternalServerError, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PositionDto>>), (int)HttpStatusCode.Unauthorized, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PositionDto>>), (int)HttpStatusCode.BadRequest, "application/json")]
        [HttpPost]
        public async Task<ResponseDto<PositionDto>> Post(PositionDto model)
        {
            return await position.Post(model);
        }
        [ProducesResponseType(typeof(ResponseDto<List<PositionDto>>), (int)HttpStatusCode.OK, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PositionDto>>), (int)HttpStatusCode.NotFound, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PositionDto>>), (int)HttpStatusCode.InternalServerError, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PositionDto>>), (int)HttpStatusCode.Unauthorized, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PositionDto>>), (int)HttpStatusCode.BadRequest, "application/json")]
        [HttpPut("{id:Guid}/id")]
        public async Task<ResponseDto<PositionDto>> Put(Guid id, PositionDto model)
        {
            return await position.Put(id, model);
        }
    }
}
