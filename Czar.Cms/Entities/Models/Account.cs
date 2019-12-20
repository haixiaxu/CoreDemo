using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    /// <summary>
    /// 账户
    /// </summary>
    [Table("account")]
    public class Account
    {
        /// <summary>
        /// 账户编号
        /// </summary>
        public Guid AccountId { get; set; }
        [Required(ErrorMessage = "创建日期是必填的")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "账户类型是必填的")]
        public string AccountType { get; set; }

        [Required(ErrorMessage = "所有者编号是必填的")]
        public Guid OwnerId { get; set; }

        //[ForeignKey(nameof(Owner))]
        //public Guid OwnerId { get; set; }
        /// <summary>
        /// 所有者
        /// </summary>
        public Owner Owner { get; set; }
    }
}
