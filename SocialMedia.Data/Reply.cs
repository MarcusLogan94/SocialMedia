using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Reply : Comment

    {
        public int ReplyId { get; set; }
        //public string ReplyerId { get; set; }
        public CustomUser Replyer { get; set; }
        //public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
