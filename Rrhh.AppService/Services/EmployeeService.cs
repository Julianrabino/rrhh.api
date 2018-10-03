using Rrhh.AppService.Base;
using Rrhh.Model.Entities;
using Rrhh.Repository.Repositories;

namespace Rrhh.AppService.Services
{
    public class EmployeeService: BaseService<Employee>
    {
        protected new EmployeeRepository Repository { get; set; }

        public EmployeeService(EmployeeRepository repository)
            : base(repository)
        {
            this.Repository = repository;
        }

        public bool Existe(int identificationTypeId, int identificationNumber)
        {
            return this.Repository.Existe(identificationTypeId, identificationNumber);
        }
    }
}
