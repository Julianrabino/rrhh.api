using Rrhh.Model.Entities;
using Rrhh.Repository.Base;
using Rrhh.Repository.Contexts;

namespace Rrhh.Repository.Repositories
{
    public class EmployeeRepository: BaseRepository<Employee>
    {
        public EmployeeRepository(EmployeeContext dbContext)
        {
            this.DbContext = dbContext;
        }
    }
}
