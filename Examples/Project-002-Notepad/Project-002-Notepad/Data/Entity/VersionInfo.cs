using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Project_002_Notepad.Data.Entity
{
    [Table("VersionInfo")]
    public partial class VersionInfo
    {
        [Key]
        public string Key { get; set; }

        [Required]
        public int VersionNumber { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
