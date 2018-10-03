using Microsoft.EntityFrameworkCore;
using Rrhh.Model.Entities;
using Rrhh.Repository.Base;
using System.Collections.Generic;
using System.Linq;

namespace Rrhh.Repository.Contexts
{
    public class EmployeeContext: DbContext, IDbContext<Employee>
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> DbSet { get; set; }
        
        public Employee Add(Employee entity)
        {
            this.Entry(entity.EmployeeType).State = EntityState.Unchanged;
            this.Entry(entity.IdentificationType).State = EntityState.Unchanged;
            return base.Add(entity).Entity;
        }

        public IEnumerable<Employee> GetAll()
        {
            return this.DbSet;
        }

        public void Remove(Employee entity)
        {
            this.Entry(entity.EmployeeType).State = EntityState.Unchanged;
            this.Entry(entity.IdentificationType).State = EntityState.Unchanged;
            base.Remove(entity);
        }

        public Employee Update(Employee entity)
        {
            this.Entry(entity.EmployeeType).State = EntityState.Unchanged;
            this.Entry(entity.IdentificationType).State = EntityState.Unchanged;
            return base.Update(entity).Entity;
        }

        public bool ExistePorTipoNumeroIdentificacion(int identificationTypeId, int identificationNumber)
        {
            return this.DbSet.Any(e =>
                e.IdentificationType.Id == identificationTypeId &&
                e.IdentificationNumber == identificationNumber);
        }
    }
}
