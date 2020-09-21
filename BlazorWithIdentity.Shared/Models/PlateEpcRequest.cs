using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace BlazorWithIdentity.Shared.Models
{
    public class PlateEpcRequest
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Rejestracja jest wymagana")]
        [StringLength(10, ErrorMessage = "Rejestracja powinna zawierać od 1 do {1} znaków")]
        public string Plate { get; set; }

        [Required(ErrorMessage = "TAG EPC jest wymagany")]
        [StringLength(50, ErrorMessage = "TAG powinien zawierać od 1 do {1} znaków")]
        public string Epc { get; set; }
    }
}