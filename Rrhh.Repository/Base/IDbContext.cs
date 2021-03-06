﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Rrhh.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rrhh.Repository.Base
{
    public interface IDbContext<TEntity>
        where TEntity : class, IEntity
    {
        DatabaseFacade Database { get; }

        DbSet<TEntity> DbSet { get; }

        int SaveChanges();

        TEntity Add(TEntity entity);
       
        IEnumerable<TEntity> GetAll();

        void Remove(TEntity entity);

        TEntity Update(TEntity entity);
    }
}
