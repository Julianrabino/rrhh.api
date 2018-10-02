using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Rrhh.Model.Entities;
using Rrhh.Repository.Base;

namespace Rrhh.Repository.Contexts
{
    public class IdentificationTypeContext : DbContext, IDbContext<IdentificationType>
    {
        public IdentificationTypeContext(DbContextOptions<IdentificationTypeContext> options) 
            : base(options)
        {
        }

        public DbSet<IdentificationType> DbSet { get; set; }

        public IdentificationType Add(IdentificationType entity)
        {
            return base.Add(entity).Entity;
        }

        public IEnumerable<IdentificationType> GetAll()
        {
            return this.DbSet;
        }

        public void Remove(IdentificationType entity)
        {
            base.Remove(entity);
        }

        public IdentificationType Update(IdentificationType entity)
        {
            return base.Update(entity).Entity;
        }
    }
}
