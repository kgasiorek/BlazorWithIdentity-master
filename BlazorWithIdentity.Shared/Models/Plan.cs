using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorWithIdentity.Shared.Models
{
    public class Plan
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public DateTime Date { get; set; }

        public string Plate { get; set; }

        public string Company { get; set; }

        public string Driver { get; set; }

        public int WeightFrist { get; set; }

        public int WeightSecond { get; set; }
    }
}
