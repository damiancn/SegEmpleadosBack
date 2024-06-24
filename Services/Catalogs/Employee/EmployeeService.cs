
namespace Services.Employee
{
    using AutoMapper;
    using DataAcccess.Interface;
    using Dtos.Employee;
    using Entities.Models.Catalog;
    using Services.Interface;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EmployeeService : IGenericService<EmployeeDto>
    {
        private readonly ICatalogDao<EmployeeModel> employeeDao;
        private readonly IMapper mapper;
        public EmployeeService(ICatalogDao<EmployeeModel> employeeDao, IMapper mapper)
        {
            this.employeeDao = employeeDao;
            this.mapper = mapper;
        }

        public async Task<List<EmployeeDto>> GetAll()
        {
            return mapper.Map<List<EmployeeDto>>(await this.employeeDao.GetAll());
        }

        public async Task<EmployeeDto> GetById(Guid id)
        {
            return mapper.Map<EmployeeDto>(await this.employeeDao.GetById(id));
        }

        public async Task<EmployeeDto> Post(EmployeeDto model)
        {
            var employeeDto = this.mapper.Map<EmployeeModel>(model);
            return mapper.Map<EmployeeDto>(await this.employeeDao.Post(employeeDto));
        }

        public async Task<EmployeeDto> Put(Guid id, EmployeeDto model)
        {
            var employeeDto = this.mapper.Map<EmployeeModel>(model);
            return mapper.Map<EmployeeDto>(await this.employeeDao.Put(id, employeeDto));
        }
    }
}
