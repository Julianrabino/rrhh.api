using Rrhh.Model.Entities;
using Rrhh.Repository.Base;
using Rrhh.Repository.Contexts;

namespace Rrhh.Repository.Repositories
{
    public class EmployeeTypeRepository: BaseRepository<EmployeeType>
    {
        public EmployeeTypeRepository(EmployeeTypeContext dbContext)
        {
            this.DbContext = dbContext;
        }
    }
}
