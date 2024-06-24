

namespace DataAcccess.Employee
{
    using DataAcccess.Interface;
    using DataAcccess.Util;
    using Entities.Core;
    using Entities.Models.Catalog;
    using Microsoft.EntityFrameworkCore;
    using Resources.Util;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EmployeeDao : ICatalogDao<EmployeeModel>
    {
        private readonly IDataBaseContext ctx;

        public EmployeeDao(IDataBaseContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<List<EmployeeModel>> GetAll()
        {
            var employee = await this.ctx.Employees.ToListAsync();
            SqlValidation<EmployeeModel>.VailidateCountList(employee, "Empleado");
            return employee;
        }

        public async Task<EmployeeModel> GetById(Guid id)
        {
            var employeeById = await this.ctx.Employees.Include(e => e.Beneficiary).Where(x => x.Id == id).FirstOrDefaultAsync();
            SqlValidation<EmployeeModel>.VailidateFound(employeeById, "Empleado");
            return employeeById;
        }

        public async Task<EmployeeModel> Post(EmployeeModel employee)
        {
            employee.Id = new Guid();
            employee.Age = DateUtil.GetAge(employee.BirthDate);
            this.ctx.Employees.Add(employee);
            await ((DataBaseContext)this.ctx).SaveChangesAsync();
            return employee;
        }

        public async Task<EmployeeModel> Put(Guid id, EmployeeModel employee)
        {
            var employeeById = await this.ctx.Employees.Where(e => e.Id == id).FirstOrDefaultAsync();
            SqlValidation<EmployeeModel>.VailidateFound(employeeById, "Empleado");
            employeeById.Name = employee.Name;
            employeeById.FirstName = employee.FirstName;
            employeeById.SeconLastName = employee.SeconLastName;
            employeeById.Salary = employee.Salary;
            employeeById.Position = employee.Position;
                    employeeById.Age = DateUtil.GetAge(employee.BirthDate);
            employeeById.DateAcces = employeeById.DateAcces;
            employeeById.BirthDate = employeeById.BirthDate;
            employeeById.Fotography = employeeById.Fotography;
            await ((DataBaseContext)this.ctx).SaveChangesAsync();
            return employeeById;
        }
    }
}
