using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_1_简单测试
{
    public class b1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //设置自增
        public int Id { set; get; }
        public string Value { set; get; }
    }
}
