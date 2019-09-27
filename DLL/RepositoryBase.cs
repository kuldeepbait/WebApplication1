using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace WebApplication1.DLL
{

    public abstract class RepositoryBase<T> :DbContext,IDisposable, IRepositoryBase<T> where T : class
    {
        const int FKConstraint = 547;
        protected DbContext RepositoryContext { get; set; }
        public RepositoryBase(DbContext repositoryContext)
        {
            repositoryContext.Configuration.LazyLoadingEnabled = true;
            this.RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
             return this.RepositoryContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
           return this.RepositoryContext.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            if (entity.GetType().GetProperty("CreatedDate") != null)
            {
                Type type = entity.GetType();
                PropertyInfo prop = type.GetProperty("CreatedDate");
                prop.SetValue(entity, new DateTime(), null);
            }
            if (entity.GetType().GetProperty("CreatedBy") != null)
            {
                Type type = entity.GetType();
                PropertyInfo prop = type.GetProperty("CreatedDate");
                prop.SetValue(entity, "Kuldeep", null);
            }
            this.RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            if (entity.GetType().GetProperty("CreatedDate") != null)
            {
                Type type = entity.GetType();
                PropertyInfo prop = type.GetProperty("CreatedDate");
                prop.SetValue(entity, new DateTime(), null);
            }
            if (entity.GetType().GetProperty("CreatedBy") != null)
            {
                Type type = entity.GetType();
                PropertyInfo prop = type.GetProperty("CreatedDate");
                prop.SetValue(entity, "Kuldeep", null);
            }
            this.RepositoryContext.Set<T>().Attach(entity);
            this.RepositoryContext.Entry(entity).State=EntityState.Modified;
        }

        public void Delete(T entity)
        {
             this.RepositoryContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            try
            {
                this.RepositoryContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var sqlException = ex.GetBaseException() as SqlException;
                if (sqlException != null)
                {
                    var number = sqlException.Number;
                    if (number == FKConstraint)
                    {
                        throw sqlException;
                    }
                }

            }
        }

        public void DeleteAll(List<T> entity)
        {
            this.RepositoryContext.Set<T>().RemoveRange(entity);
        }

        public void CreateAll(List<T> entity)
        {
            this.RepositoryContext.Set<T>().AddRange(entity);
        }

        public void Dispose()
        {
            if (this.RepositoryContext != null)
            {
                this.RepositoryContext.Dispose();
            }
        }
    }
}