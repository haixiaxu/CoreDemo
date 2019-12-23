using System;

namespace Entities.Dto
{
    /// <summary>
    /// 所有者Dto
    /// </summary>
    public class OwnerDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime DataOfBirth { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
    }
}
