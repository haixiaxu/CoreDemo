using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;


namespace Entities.Helper
{
    /// <summary>
    /// 排序帮助类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SortHelper<T> : ISortHelper<T>
    {
        /// <summary>
        /// 应用排序
        /// </summary>
        /// <param name="entitys">要排序的列表</param>
        /// <param name="orderByQueryString">排序的字符串</param>
        /// <returns></returns>
        public IQueryable<T> ApplySort(IQueryable<T> entitys, string orderByQueryString)
        {
            //如果列表为空,退出该方法
            if (!entitys.Any())
                return entitys;
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return entitys;
            //拆分查询字符串获取各个字段
            var orderParames = orderByQueryString.Trim().Split(',');
            //使用反射来准备PropertyInfo代表实体的对象列表,需要检查查询字符串接收到的字段在实体中是否存在
            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();
            //遍历所有参数并检查是否存在
            foreach (var param in orderParames)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;
                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(c => c.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));
                //如果找不到属性,则跳过循环,然后转到列表中的下一个参数
                if (objectProperty == null)
                    continue;
                //如果找到该属性,则将其返回,并检查参数是否在字符串末尾包含倒序
                var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";
                //使用StringBuilder在每个循环中构建查询
                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {sortingOrder}, ");
            }
            //删除多余的逗号,并进行检查以查看查询中是否包含某些内容
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            return entitys.OrderBy(orderQuery);
        }
    }
}
