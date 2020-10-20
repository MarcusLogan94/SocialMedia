using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMedia.Models;

namespace SocialMedia.Services
{
    public class PostService
    {
        private Guid _userId;
        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    PosterId = _userId,
                    Title = model.Title,
                    Text = model.Text,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListItem> GetAllPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Posts
                       .Select(m => new PostListItem
                       {
                           PostId = m.PostId,
                           Title = m.Title,
                           Text = m.Text,
                           //AuthorId = m.PosterId,
                           //PosterName = m.Poster.Name
                       });
                return query.ToList();
            }
        }

        public IEnumerable<PostListItem> GetPostsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Posts
                       .Where(p => p.PosterId == _userId)
                       .Select(m => new PostListItem
                       {
                           PostId = m.PostId,
                           Title = m.Title,
                           Text = m.Text,
                           //CreatedUtc = entity.CreatedUtc,
                           //ModifiedUtc = entity.ModifiedUtc
                           //PosterId = m.PosterId,
                           //PosterName = m.Poster.Name
                       });
                return query.ToList();
            }
        }
        public bool UpdatePost(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostId == model.PostId && e.PosterId == _userId);


                entity.Title = model.Title;
                entity.Text = model.Text;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostId == postId && e.PosterId == _userId);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}