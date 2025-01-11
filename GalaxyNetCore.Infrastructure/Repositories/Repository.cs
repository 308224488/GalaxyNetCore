using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxyNetCore.Application.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalaxyNetCore.Infrastructure.Data;

namespace GalaxyNetCore.Infrastructure.Repositories
{
    /// <summary>
    /// 通用仓储实现，提供基本的 CRUD 操作
    /// 说明：
    /// 类 Repository<T>：实现了 IRepository<T> 接口，提供基本的 CRUD 操作。
    /// 依赖注入：通过构造函数注入 ApplicationDbContext，实现对数据库的操作。
    /// 方法注释：/// <inheritdoc/> 表示继承自接口的文档注释，保持文档的一致性。
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entities;

        /// <summary>
        /// 构造函数，注入数据库上下文
        /// </summary>
        /// <param name="context">数据库上下文</param>
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        /// <inheritdoc/>
        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entities.Where(predicate).ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        /// <inheritdoc/>
        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }

        /// <inheritdoc/>
        public void Update(T entity)
        {
            _entities.Update(entity);
        }
    }
}
