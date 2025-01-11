using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxyNetCore.Application.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalaxyNetCore.Infrastructure.Data;

namespace GalaxyNetCore.Infrastructure.Repositories
{
    /// <summary>
    /// 工作单元实现，管理多个仓储实例并处理事务
    /// 说明：
    /// 类 UnitOfWork：实现了 IUnitOfWork 接口，管理多个仓储实例并统一处理事务。
    /// 仓储缓存：使用字典 _repositories 缓存仓储实例，避免重复创建。
    /// 方法注释：/// <inheritdoc/> 表示继承自接口的文档注释。
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly Dictionary<Type, object> _repositories = new();

        /// <summary>
        /// 构造函数，注入数据库上下文
        /// </summary>
        /// <param name="context">数据库上下文</param>
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public IRepository<T> Repository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IRepository<T>)_repositories[typeof(T)];
            }

            var repository = new Repository<T>(_context);
            _repositories.Add(typeof(T), repository);
            return repository;
        }

        /// <inheritdoc/>
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
