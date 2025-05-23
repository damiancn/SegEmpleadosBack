namespace SeguimientoEmpleadosAPI.Controllers.Catalogs
{
    using Dtos.Beneficiary;
    using Dtos.Commons;
    using Facade.Beneficiary;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BeneficiaryController : ControllerBase
    {
        private readonly IBeneficiaryFacade beneficiary;

        public BeneficiaryController(IBeneficiaryFacade beneficiary)
        {
            this.beneficiary = beneficiary;
        }

        [ProducesResponseType(typeof(ResponseDto<List<BeneficiaryDto>>), (int)HttpStatusCode.Unauthorized, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<BeneficiaryDto>>), (int)HttpStatusCode.OK, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<BeneficiaryDto>>), (int)HttpStatusCode.NotFound, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<BeneficiaryDto>>), (int)HttpStatusCode.BadRequest, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<BeneficiaryDto>>), (int)HttpStatusCode.InternalServerError, "application/json")]
        [HttpGet]
        public async Task<ResponseDto<List<BeneficiaryDto>>> GetAll()
        {
            return await beneficiary.GetAll();
        }

        [ProducesResponseType(typeof(ResponseDto<List<BeneficiaryDto>>), (int)HttpStatusCode.Unauthorized, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<BeneficiaryDto>>), (int)HttpStatusCode.OK, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<BeneficiaryDto>>), (int)HttpStatusCode.BadRequest, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<BeneficiaryDto>>), (int)HttpStatusCode.NotFound, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<BeneficiaryDto>>), (int)HttpStatusCode.InternalServerError, "application/json")]
        [HttpGet("id")]
        public async Task<ResponseDto<BeneficiaryDto>> GetById(Guid id)
        {
            return await beneficiary.GetById(id);
        }
       
        [ProducesResponseType(typeof(ResponseDto<List<BeneficiaryDto>>), (int)HttpStatusCode.Unauthorized, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<BeneficiaryDto>>), (int)HttpStatusCode.Created, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<BeneficiaryDto>>), (int)HttpStatusCode.NotFound, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<BeneficiaryDto>>), (int)HttpStatusCode.InternalServerError, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<BeneficiaryDto>>), (int)HttpStatusCode.BadRequest, "application/json")]
        [HttpPost]
        public async Task<ResponseDto<BeneficiaryDto>> Post(BeneficiaryDto model)
        {
            return await beneficiary.Post(model);
        }
        [ProducesResponseType(typeof(ResponseDto<List<BeneficiaryDto>>), (int)HttpStatusCode.Unauthorized, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<BeneficiaryDto>>), (int)HttpStatusCode.OK, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<BeneficiaryDto>>), (int)HttpStatusCode.NotFound, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<BeneficiaryDto>>), (int)HttpStatusCode.InternalServerError, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<BeneficiaryDto>>), (int)HttpStatusCode.BadRequest, "application/json")]
        [HttpPut("{id:Guid}/id")]
        public async Task<ResponseDto<BeneficiaryDto>> Put(Guid id, BeneficiaryDto model)
        {
            return await beneficiary.Put(id, model);
        }
    }
}
