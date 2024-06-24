
namespace Facade.Employee.Impl
{
    using DataAcccess.Interface;
    using Dtos.Commons;
    using Dtos.Employee;
    using Facade.Catalogs.Employee;
    using Services.Interface;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EmployeeFacade : IEmployeeFacade
    {
        private readonly IGenericService<EmployeeDto> modelService;

        public EmployeeFacade(IGenericService<EmployeeDto> modelService)
        {
            this.modelService = modelService;
        }

        public async Task<ResponseDto<List<EmployeeDto>>> GetAll()
        {
            return new ResponseDto<List<EmployeeDto>>
            {
                MesageError = null,
                Ok = true,
                Mesage = "Busqueda exitosa de Empleados",
                Dto = await this.modelService.GetAll(),
            };
        }

        public async Task<ResponseDto<EmployeeDto>> GetById(Guid id)
        {
            return new ResponseDto<EmployeeDto>
            {
                MesageError = null,
                Ok = true,
                Mesage = "Busqueda exitosa de Empleado",
                Dto = await this.modelService.GetById(id),
            };
        }

        public async Task<ResponseDto<EmployeeDto>> Post(EmployeeDto employee)
        {
            return new ResponseDto<EmployeeDto>
            {
                MesageError = null,
                Ok = true,
                Mesage = "Se generó el empleado con éxito",
                Dto = await this.modelService.Post(employee),
            };
        }

        public async Task<ResponseDto<EmployeeDto>> Put(Guid id, EmployeeDto employee)
        {
            return new ResponseDto<EmployeeDto>
            {
                MesageError = null,
                Ok = true,
                Mesage = "Se genero el cambio con éxito",
                Dto = await this.modelService.Put(id, employee),
            };
        }
    }
}
