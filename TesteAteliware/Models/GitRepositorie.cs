using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalTest.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalTest.Models
{
    public class GitRepositorie
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Linguagem")]
        public string Language { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public string Url { get; set; }
        public int WatchCount { get; set; }

   

    }
}
