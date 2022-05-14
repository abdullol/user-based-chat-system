using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ubcs_server.Models.Cats
{
    public class CreateCatRequestModel
    {
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
