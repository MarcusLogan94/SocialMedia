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
        //[Key]
        //public Guid Id { get; set; }
        //[Required]
        public string Name { get; set; }
        //[Required]
        public string Email { get; set; }
        public ICollection<Post> PostsByUser { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Reply> Replies { get; set; }
       
    }
}
