using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_001_UpdateMoney
{
    /// <summary>
    /// 金额变化记录
    /// </summary>
    public class ChangeRecord
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 变化的金额
        /// </summary>
        public double Amount { get; set; }
        /// <summary>
        /// 变化后的余额
        /// </summary>
        public double Balance { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
