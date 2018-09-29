using Rrhh.AppService.Base;
using Rrhh.Model.Entities;
using Rrhh.Repository.Repositories;

namespace Rrhh.AppService.Services
{
    public class EmployeeService: BaseService<Employee>
    {                
        public EmployeeService(EmployeeRepository repository)
        {
            this.Repository = repository;
        }
    }
}
