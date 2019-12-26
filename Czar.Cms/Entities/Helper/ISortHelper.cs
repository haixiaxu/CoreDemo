using System.Linq;

namespace Entities.Helper
{
    /// <summary>
    /// 排序帮助接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISortHelper<T>
    {
        /// <summary>
        /// 应用排序
        /// </summary>
        /// <param name="entitys">要排序的列表</param>
        /// <param name="orderByQueryString">排序的查询字段</param>
        /// <returns></returns>
        IQueryable<T> ApplySort(IQueryable<T> entitys, string orderByQueryString);
    }
}
