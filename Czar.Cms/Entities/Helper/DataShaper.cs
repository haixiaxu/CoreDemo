using Entities.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace Entities.Helper
{
    public class DataShaper<T> : IDataShaper<T>
    {
        public PropertyInfo[] Properties { get; set; }
        public DataShaper()
        {
            //重写搜索当前包含公共成员或者实例成员
            Properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
        public Entity ShaperData(T entity, string fieldsString)
        {
            var requiredProperties = GetRequiredProperties(fieldsString);
            return FetchDataForEntity(entity, requiredProperties);
        }

        public IEnumerable<Entity> ShaperData(IEnumerable<T> entitys, string fieldsString)
        {
            var requiredProperties = GetRequiredProperties(fieldsString);
            return FetchData(entitys, requiredProperties);
        }
        /// <summary>
        /// 解析获取必需的属性信息
        /// </summary>
        /// <param name="fieldsString"></param>
        /// <returns></returns>
        private IEnumerable<PropertyInfo> GetRequiredProperties(string fieldsString)
        {
            var requiredProperties = new List<PropertyInfo>();
            if (!string.IsNullOrWhiteSpace(fieldsString))
            {
                //将其拆分
                var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (var field in fields)
                {
                    //检查字段是否与实体中的属性匹配
                    var property = Properties.FirstOrDefault(c => c.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));
                    if (property == null)
                        continue;
                    //添加到属性列表中
                    requiredProperties.Add(property);
                }
            }
            else
            {
                requiredProperties = Properties.ToList();
            }
            return requiredProperties;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="entitys"></param>
        /// <param name="requiredProperties"></param>
        /// <returns></returns>
        private IEnumerable<Entity> FetchData(IEnumerable<T> entitys, IEnumerable<PropertyInfo> requiredProperties)
        {
            var shapedData = new List<Entity>();
            foreach (var entity in entitys)
            {
                var shapedObject = FetchDataForEntity(entity, requiredProperties);
                shapedData.Add(shapedObject);
            }
            return shapedData;
        }
        /// <summary>
        /// 获取单个数据实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="requiredProperties"></param>
        /// <returns></returns>
        private Entity FetchDataForEntity(T entity, IEnumerable<PropertyInfo> requiredProperties)
        {
            var shapedObject = new Entity();
            foreach (var property in requiredProperties)
            {
                //使用反射,提取值
                var objectPropertyValue = property.GetValue(entity);
                //添加属性,将属性名称用作键,值用作字典的值
                shapedObject.TryAdd(property.Name, objectPropertyValue);
            }
            return shapedObject;
        }
    }
}
