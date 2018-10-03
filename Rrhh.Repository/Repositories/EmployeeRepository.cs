using Rrhh.Model.Entities;
using Rrhh.Repository.Base;
using Rrhh.Repository.Contexts;

namespace Rrhh.Repository.Repositories
{
    public class EmployeeRepository: BaseRepository<Employee>
    {
        protected new EmployeeContext DbContext { get; set; }

        public EmployeeRepository(EmployeeContext dbContext)
            : base(dbContext)
        {
            this.DbContext = dbContext;
        }

        public bool Existe(int identificationTypeId, int identificationNumber)
        {
            return this.DbContext.ExistePorTipoNumeroIdentificacion(identificationTypeId, identificationNumber);
        }
    }
}
