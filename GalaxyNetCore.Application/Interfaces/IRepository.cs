using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace GalaxyNetCore.Application.Interfaces
{
    /// <summary>
    /// 通用仓储接口，定义基本的 CRUD 操作
    /// 说明：
    ///泛型接口 IRepository<T>：允许对不同类型的实体进行操作。
    ///方法注释：详细描述了每个方法的用途，便于理解和维护。
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="id">实体主键</param>
        /// <returns>实体对象</returns>
        Task<T?> GetByIdAsync(int id);

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <returns>实体集合</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// 根据条件查找实体
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <returns>符合条件的实体集合</returns>
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 添加新的实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        Task AddAsync(T entity);

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        void Remove(T entity);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        void Update(T entity);
    }
}
