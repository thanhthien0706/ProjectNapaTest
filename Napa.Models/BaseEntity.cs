using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napa.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [ValidateNever]
        public DateTime? CreateAt { get; set; }

        [ValidateNever]
        public DateTime? UpdateAt { get; set; }

        public DateTime? DeleteAt { get; set; }
    }
}
