using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    /// <summary>
    /// 书籍
    /// </summary>
    public class Book
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Display(Name = "书名")]
        [StringLength(maximumLength: 20, ErrorMessage = "书名不能超过20个字符")]
        public string Title { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public string Genre { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public List<string> Authors { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        [DataType(DataType.Currency)]
        [Range(1,100)]
        public decimal Price { get; set; }
        /// <summary>
        /// 出版日期
        /// </summary>
        [Display(Name ="出版时间")]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
    }
}
