namespace Facade.Catalogs.Employee
{
    using Dtos.Commons;
    using Dtos.Employee;
    public interface IEmployeeFacade
    {
        Task<ResponseDto<List<EmployeeDto>>> GetAll();
        Task<ResponseDto<EmployeeDto>> GetById(Guid id);
        Task<ResponseDto<EmployeeDto>> Post(EmployeeDto employee);
        Task<ResponseDto<EmployeeDto>> Put(Guid id, EmployeeDto employee);
    }
}
