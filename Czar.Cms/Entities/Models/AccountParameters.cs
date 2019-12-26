using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    /// <summary>
    /// 账户查询参数
    /// </summary>
   public class AccountParameters:QueryStringParameters
    {
        public AccountParameters()
        {
            OrderBy = "DateCreated";
        }
    }
}
