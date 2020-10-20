using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class CommentCreate
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public Post CommentedPost { get; set; }

    }
}
