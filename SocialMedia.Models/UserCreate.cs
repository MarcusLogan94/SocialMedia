using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class UserCreate
    {
<<<<<<< HEAD

        [Required]
        public string UserName { get; set; }

        public string Email { get; set; }

=======
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
>>>>>>> origin/develop
    }
}
