using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PC.Common.Helpers
{
    public abstract class BaseImport
    {
        [Description("行号")]
        public string RowNum { get; set; }
    }
}
