using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napa.Models
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display order about 1-100")]
        public int DisplayOrder { get; set; }
    }
}
