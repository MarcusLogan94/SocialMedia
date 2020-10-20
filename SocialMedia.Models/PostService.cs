using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class PostService
    {
        private Guid _userId;
        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(CPost post)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Post entity = new Post()
                {
                    Title = post.Title,
                    Text = post.Text,
                    PosterId = _userId,
                };
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
                           Id = m.Id,
                           Title = m.Title,
                           Text = m.Text,
                           PosterId = m.PosterId,
                           PosterName = m.Poster.Name
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
                           Id = m.Id,
                           Title = m.Title,
                           Text = m.Text,
                           PosterId = m.PosterId,
                           PosterName = m.Poster.Name
                       });
                return query.ToList();
            }
        }
        public bool UpdateNote(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.Text == model.Title && e.PosterId == _userId);

                entity.Title = model.Title;
                entity.Text = model.Text;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.Title == e.Text && e.PosterId == _userId);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public UserDetail ConvertUserToUserDetail(User user)
        {
            var userDetail = new UserDetail()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                // PostsByUser = 
            };
            foreach (var post in user.PostsByUser)
            {
                var postListItem = new PostListItem
                {
                    Id = post.Id,
                    Text = post.Text,
                    Title = post.Title,
                    PosterId = post.PosterId,
                    PosterName = post.Poster.Name
                };
                userDetail.PostsByUser.Add(postListItem);
            }
            return userDetail;
        }
    }
}