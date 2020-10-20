using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string Text { get; set; }
        
        public CustomUser Author { get; set; }
        
        public Post CommentedPost { get; set; }
        //[ForeignKey(nameof(Author))]
        //public Guid PosterId { get; set; }
        ////public virtual CustomUser Author { get; set; }
        ////[ForeignKey(nameof(CommentOn))]
        //public int PostId { get; set; }
        //public virtual Post CommentOn { get; set; }

    }
}
