using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class CustomUser
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
       


    }
}
