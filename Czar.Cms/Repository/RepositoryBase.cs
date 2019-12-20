using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    /// <summary>
    /// 仓储抽象类 定义CRUD方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        public void Create(T entity)
        {
             this.RepositoryContext.Set<T>().Add(entity);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> FindAll()
        {
           return this.RepositoryContext.Set<T>().AsNoTracking();
        }
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
           return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }
    }
}
