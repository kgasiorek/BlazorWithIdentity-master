using Newtonsoft.Json.Serialization;
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
        [StringLength(10)]
        public string Type { get; set; }

        [Required(ErrorMessage = "Data jest wymagana")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Rejestracja jest wymagana")]
        [StringLength(10, ErrorMessage = "Rejestracja powinna zawierać od 1 do {1} znaków")]
        public string Plate { get; set; }

        [Required(ErrorMessage = "Nazwa firmy jest wymagana")]
        [StringLength(50, ErrorMessage = "Nazwa powinna zawierać od 1 do {1} znaków")]
        public string Company { get; set; }

        public string Driver { get; set; }

        public int WeightFrist { get; set; }

        public int WeightSecond { get; set; }
    }
}
