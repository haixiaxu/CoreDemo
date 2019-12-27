using Entities.Models;
using System.Collections.Generic;
using System.Dynamic;

namespace Entities.Helper
{
    /// <summary>
    /// 数据整形
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataShaper<T>
    {
        /// <summary>
        /// 整形数据
        /// </summary>
        /// <param name="entitys">实体集合</param>
        /// <param name="fieldsString">查询字符串参数</param>
        /// <returns></returns>
        IEnumerable<Entity> ShaperData(IEnumerable<T> entitys, string fieldsString);
        /// <summary>
        /// 整形数据
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="fieldsString">查询字符串参数</param>
        /// <returns></returns>
        Entity ShaperData(T entity, string fieldsString);
    }
}
