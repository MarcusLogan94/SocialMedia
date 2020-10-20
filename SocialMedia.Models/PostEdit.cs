using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class PostEdit
    {
        public string Title { get; set; }
        public string Text { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
