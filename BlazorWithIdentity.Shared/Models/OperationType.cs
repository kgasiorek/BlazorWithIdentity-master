using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BlazorWithIdentity.Shared.Models
{
    public class OperationType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string TypeShort { get; set; }
    }
}