using Rrhh.AppService.Base;
using Rrhh.Model.Entities;
using Rrhh.Repository.Repositories;

namespace Rrhh.AppService.Services
{
    public class IdentificationTypeService : BaseService<IdentificationType>
    {                
        public IdentificationTypeService(IdentificationTypeRepository repository)
            : base(repository)
        {
        }
    }
}
