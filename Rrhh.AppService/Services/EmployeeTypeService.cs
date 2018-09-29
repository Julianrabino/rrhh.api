using Rrhh.AppService.Base;
using Rrhh.Model.Entities;
using Rrhh.Repository.Repositories;

namespace Rrhh.AppService.Services
{
    public class EmployeeTypeService: BaseService<EmployeeType>
    {                
        public EmployeeTypeService(EmployeeTypeRepository repository)
        {
            this.Repository = repository;
        }
    }
}
