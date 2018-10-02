using Rrhh.Model.Entities;
using Rrhh.Repository.Base;
using Rrhh.Repository.Contexts;

namespace Rrhh.Repository.Repositories
{
    public class IdentificationTypeRepository : BaseRepository<IdentificationType>
    {
        public IdentificationTypeRepository(IdentificationTypeContext dbContext)
        {
            this.DbContext = dbContext;
        }
    }
}
