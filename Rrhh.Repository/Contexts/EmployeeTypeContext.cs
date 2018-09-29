using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Rrhh.Model.Entities;
using Rrhh.Repository.Base;

namespace Rrhh.Repository.Contexts
{
    public class EmployeeTypeContext: DbContext, IDbContext<EmployeeType>
    {
        public EmployeeTypeContext(DbContextOptions<EmployeeTypeContext> options) 
            : base(options)
        {
        }

        //public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<EmployeeType> DbSet { get; set; }

        public EmployeeType Add(EmployeeType entity)
        {
            return base.Add(entity).Entity;
        }

        public IEnumerable<EmployeeType> GetAll()
        {
            return this.DbSet;
        }

        public void Remove(EmployeeType entity)
        {
            base.Remove(entity);
        }

        public EmployeeType Update(EmployeeType entity)
        {
            return base.Update(entity).Entity;
        }
    }
}
