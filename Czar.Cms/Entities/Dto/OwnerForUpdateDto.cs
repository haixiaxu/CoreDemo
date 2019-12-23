using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dto
{
    /// <summary>
    /// 更新所有者Dto(数据传输对象)
    /// </summary>
    public class OwnerForUpdateDto
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名称是必填的")]
        [StringLength(60, ErrorMessage = "名称不能超过60个字符")]
        public string Name { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        [Required(ErrorMessage = "出生日期是必填的")]
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [Required(ErrorMessage = "地址是必填的")]
        [StringLength(100, ErrorMessage = "地址不能超过100个字符")]
        public string Address { get; set; }
    }
}
