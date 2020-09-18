using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorWithIdentity.Shared.Models
{

    public class OperationTypeRequest
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Typ jest wymagany")]
        [StringLength(10)]
        public string Type { get; set; }

        [Required(ErrorMessage = "Skrót typu jest wymagany")]
        [StringLength(2)]
        public string TypeShort { get; set; }
    }
}