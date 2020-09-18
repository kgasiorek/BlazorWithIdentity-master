using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorWithIdentity.Shared
{
    public class PlanRequest
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Typ jest wymagany")]
        [StringLength(2) ]
        public string Type { get; set; }

        [Required(ErrorMessage = "Data jest wymagana")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Rejestracja jest wymagana")]
        [StringLength(10)]
        public string Plate { get; set; }

        [Required(ErrorMessage = "Nazwa firmy jest wymagana")]
        [StringLength(50)]
        public string Company { get; set; }

        public string Driver { get; set; }

        public int WeightFrist { get; set; }

        public int WeightSecond { get; set; }
    }
}
