using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Napa.Models
{
    public class Author : BaseEntity
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public string? Description { get; set; }

        [DisplayName("Date of birth")]
        public DateTime? Dob { get; set; }
    }
}
