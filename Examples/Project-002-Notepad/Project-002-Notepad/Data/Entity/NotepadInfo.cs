namespace Project_002_Notepad.Data.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NotepadInfo")]
    public partial class NotepadInfo
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }

        [Required]
        public string NotepadContent { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
