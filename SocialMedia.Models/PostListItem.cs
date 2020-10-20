using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class PostListItem
    {
        //private Guid _userId;
        //public void CreatePost(Guid userId)
        //{
        //    _userId = userId;
        //}
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }
        //public Guid AuthorId { get; set; }
        //public string PosterName { get; set; }

    }
}