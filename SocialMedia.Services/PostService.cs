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
            var service = CreateUserService();

            var entity =
                new Post()
                {
                    Author = service.GetUserByGUID(_userId),
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
                           AuthorName = m.Author.Name
                       });
                return query.ToList();
            }
        }

        public PostDetail GetPostById(int id)
        {
            //var service = CreateUserService();
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                         ctx
                         .Posts
                         .Single(e => e.PostId == id);
                return
                    new PostDetail
                    {
                        PostId = entity.PostId,
                        Title = entity.Title,
                        Text = entity.Text,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };

            }
        }
        public bool UpdatePost(PostEdit model)
        {
            var service = CreateUserService();
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostId == model.PostId && e.Author == service.GetUserByGUID(_userId));


                entity.Title = model.Title;
                entity.Text = model.Text;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int postId)
        {
            var service = CreateUserService();
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostId == postId && e.Author == service.GetUserByGUID(_userId));

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}