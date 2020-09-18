using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BlazorWithIdentity.Shared.Models
{
    public class PlateEpc
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public string Epc { get; set; }
    }
}