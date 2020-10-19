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
        private Guid _userId;
        public void CreatePost(Guid userId)
        {
            _userId = userId;
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }
        public Guid PosterId { get; set; }
        public string PosterName { get; set; }

    }
}