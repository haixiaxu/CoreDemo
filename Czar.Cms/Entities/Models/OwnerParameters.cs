
using System;

namespace Entities.Models
{
    /// <summary>
    /// 所有者查询参数
    /// </summary>
    public class OwnerParameters: QueryStringParameters
    {
        public OwnerParameters()
        {
            OrderBy = "name";
        }
        /// <summary>
        /// 最小的出生年份
        /// </summary>
        public uint MinYearOfBirth { get; set; }
        /// <summary>
        /// 最大出生年份
        /// </summary>
        public uint MaxYearOfBirth { get; set; } = (uint)DateTime.Now.Year;
        /// <summary>
        /// 有效年份范围
        /// </summary>
        public bool ValidYearRange => MaxYearOfBirth > MinYearOfBirth;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
    }
}
