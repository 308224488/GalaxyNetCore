using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyNetCore.Application.Interfaces
{
    /// <summary>
    /// 工作单元接口，管理多个仓储并处理事务
    /// 说明：
    /// 接口 IUnitOfWork：用于管理多个仓储实例并统一处理事务。
    /// Repository<T>() 方法：提供获取特定实体类型仓储的方法。
    /// CommitAsync() 方法：提交所有更改到数据库，确保事务的一致性。
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 获取指定类型的仓储实例
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <returns>仓储实例</returns>
        IRepository<T> Repository<T>() where T : class;

        /// <summary>
        /// 提交所有更改到数据库
        /// </summary>
        /// <returns>受影响的记录数</returns>
        Task<int> CommitAsync();
    }
}
