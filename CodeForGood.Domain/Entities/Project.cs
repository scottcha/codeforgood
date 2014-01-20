using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CodeForGood.Domain.Entities
{
    public class Project
    {
        [HiddenInput(DisplayValue = false)]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Please enter a repository Url")]
        public string ProjectUri { get; set; }

        [Required(ErrorMessage = "Please enter a category")]
        public string Category { get; set; }
    }
}
