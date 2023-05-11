﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napa.Models.ViewModels
{
    public class BookAdminVM
    {
        public Book Book { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }


        [ValidateNever]
        public IEnumerable<SelectListItem> AuthorList { get; set; }
    }
}
