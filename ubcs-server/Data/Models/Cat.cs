using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ubcs_server.Models;

namespace ubcs_server.Data.Models
{
    public class Cat
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(Validation.Cat.MaxDescriptionLength)]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
