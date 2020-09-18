using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BlazorWithIdentity.Shared.Models
{
    class OperationType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string TypeShort { get; set; }
    }
}