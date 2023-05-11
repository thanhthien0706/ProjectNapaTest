using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napa.Models
{
    public class Book : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        private string? _slug;
        public string? Slug
        {
            get
            {
                if (_slug == null)
                {
                    return SlugGenerator.SlugGenerator.GenerateSlug(Title);
                }
                else { return _slug; }
            }

            set
            {
                if (Title != null)
                {
                    _slug = SlugGenerator.SlugGenerator.GenerateSlug(Title);
                }
                else
                {
                    _slug = SlugGenerator.SlugGenerator.GenerateSlug(value);
                }
            }
        }

        [Required]
        [MaxLength(200)]
        public string SubDescription { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime? YearPublished { get; set; }

        [Required]
        [ValidateNever]
        public string Thumbnail { get; set; }

        public bool Published { get; set; } = false;

        public int AuthorTId { get; set; }
        [ForeignKey(nameof(AuthorTId))]
        [ValidateNever]
        public virtual Author Author { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        [ValidateNever]
        public virtual Category Category { get; set; }
    }
}
