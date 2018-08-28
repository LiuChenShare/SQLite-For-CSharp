using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_001_UpdateMoney.Data
{
    /// <summary>
    /// 银行账户
    /// </summary>
    public class VaultInfo
    {
        //[Key]
        //public Guid Id { get; set; }
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 余额
        /// </summary>
        public double Balance { get; set; }
    }
}
