namespace SeguimientoEmpleadosAPI.Controllers.Catalogs
{
    using Dtos.Commons;
    using Dtos.Employee;
    using Facade.Catalogs.Employee;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeFacade employee;

        public EmployeeController(IEmployeeFacade employee)
        {
            this.employee = employee;
        }

        [ProducesResponseType(typeof(ResponseDto<List<EmployeeDto>>), (int)HttpStatusCode.OK, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<EmployeeDto>>), (int)HttpStatusCode.NotFound, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<EmployeeDto>>), (int)HttpStatusCode.InternalServerError, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<EmployeeDto>>), (int)HttpStatusCode.Unauthorized, "application/json")]
        [HttpGet]
        public async Task<ResponseDto<List<EmployeeDto>>> GetAll()
        {
            return await employee.GetAll();
        }

        [ProducesResponseType(typeof(ResponseDto<List<EmployeeDto>>), (int)HttpStatusCode.OK, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<EmployeeDto>>), (int)HttpStatusCode.NotFound, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<EmployeeDto>>), (int)HttpStatusCode.InternalServerError, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<EmployeeDto>>), (int)HttpStatusCode.Unauthorized, "application/json")]
        [HttpGet("id")]
        public async Task<ResponseDto<EmployeeDto>> GetById(Guid id)
        {
            return await employee.GetById(id);
        }

        [ProducesResponseType(typeof(ResponseDto<List<EmployeeDto>>), (int)HttpStatusCode.Created, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<EmployeeDto>>), (int)HttpStatusCode.NotFound, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<EmployeeDto>>), (int)HttpStatusCode.InternalServerError, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<EmployeeDto>>), (int)HttpStatusCode.Unauthorized, "application/json")]
        [HttpPost]
        public async Task<ResponseDto<EmployeeDto>> Post(EmployeeDto model)
        {
            return await employee.Post(model);
        }

        [ProducesResponseType(typeof(ResponseDto<List<EmployeeDto>>), (int)HttpStatusCode.OK, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<EmployeeDto>>), (int)HttpStatusCode.NotFound, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<EmployeeDto>>), (int)HttpStatusCode.InternalServerError, "application/json")]
        [ProducesResponseType(typeof(ResponseDto<List<EmployeeDto>>), (int)HttpStatusCode.Unauthorized, "application/json")]
        [HttpPut("{id:Guid}/id")]
        public async Task<ResponseDto<EmployeeDto>> Put(Guid id, EmployeeDto model)
        {
            return await employee.Put(id, model);
        }
    }
}
