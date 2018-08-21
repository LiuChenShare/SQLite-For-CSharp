using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chy.SQLite
{
    public class ScriptTypeM
    {
        public Guid ScriptTypeId { get; set; }
        public string ScriptType { get; set; }
        public bool IsUsing { get; set; }
    }
}
