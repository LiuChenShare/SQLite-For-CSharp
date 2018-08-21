using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Test_1_简单测试
{
    public class Person
    {
        [Key]
        public Guid Id { set; get; }
        public string Name { set; get; }
    }
}
