using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SuperMed.Models.ViewModels
{
    public class CreateVisitViewModel
    {
        [Required]
        public string Doctor { get; set; }

        public IEnumerable<SelectListItem> Doctors { get; set; }
    }
}
