namespace SeguimientoEmpleadosAPI.Controllers.Security
{
    using Dtos.Commons;
    using Dtos.Security.Page;
    using Facade.Security.Pages;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;

    [Route("api/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly IPageFacade page;

        public PageController(IPageFacade page)
        {
            this.page = page;
        }
        [ProducesResponseType(typeof(ResponseDto<List<PageDto>>), (int)HttpStatusCode.OK, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PageDto>>), (int)HttpStatusCode.NotFound, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PageDto>>), (int)HttpStatusCode.InternalServerError, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PageDto>>), (int)HttpStatusCode .BadRequest, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PageDto>>), (int)HttpStatusCode.Unauthorized, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PageDto>>), (int)HttpStatusCode.InternalServerError, "application/json")]
        [HttpGet]
        public async Task<ResponseDto<List<PageDto>>> GetAll()
        {
            return await page.GetAll();
        }
        [ProducesResponseType(typeof(ResponseDto<List<PageDto>>), (int)HttpStatusCode.Unauthorized, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PageDto>>), (int)HttpStatusCode.OK, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PageDto>>), (int)HttpStatusCode.BadRequest, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PageDto>>), (int)HttpStatusCode.NotFound, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PageDto>>), (int)HttpStatusCode.InternalServerError, "application/json")]
        [HttpGet("id")]
        public async Task<ResponseDto<PageDto>> GetById(Guid id)
        {
            return await page.GetById(id);
        }
        [ProducesResponseType(typeof(ResponseDto<List<PageDto>>), (int)HttpStatusCode.Unauthorized, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PageDto>>), (int)HttpStatusCode.Created, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PageDto>>), (int)HttpStatusCode.NotFound, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PageDto>>), (int)HttpStatusCode.InternalServerError, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PageDto>>), (int)HttpStatusCode.BadRequest, "application/json")]
        [HttpPost]
        public async Task<ResponseDto<PageDto>> Post(PageDto model)
        {
            return await page.Post(model);
        }
        [ProducesResponseType(typeof(ResponseDto<List<PageDto>>), (int)HttpStatusCode.Unauthorized, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PageDto>>), (int)HttpStatusCode.OK, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PageDto>>), (int)HttpStatusCode.NotFound, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PageDto>>), (int)HttpStatusCode.InternalServerError, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<PageDto>>), (int)HttpStatusCode.BadRequest, "application/json")]
        [HttpPut("{id:Guid}/id")]
        public async Task<ResponseDto<PageDto>> Put(Guid id, PageDto model)
        {
            return await page.Put(id, model);
        }
    }
}
