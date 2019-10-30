namespace Project_002_Notepad.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.SQLite;
    using Project_002_Notepad.Data.Entity;

    public partial class NotepadContext : DbContext
    {
        //public Model1()NotepadContext
        //    : base("name=Model1")
        //{
        //}
        //public NotepadContext()
        //   : base(new SQLiteConnection(@"Data Source=C:\Users\wolfy\AppData\Local\client\data\my.db;"), false)
        //{

        //}
        public NotepadContext(SQLiteConnection connection, bool contextOwnsConnection)
          : base(connection, contextOwnsConnection)
        {

        }

        public virtual DbSet<NotepadInfo> NotepadInfo { get; set; }
        public virtual DbSet<VersionInfo> VersionInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
