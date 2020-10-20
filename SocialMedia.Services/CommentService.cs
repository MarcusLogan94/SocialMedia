using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class CommentService
    {

        private readonly Guid _commentId;
        public CommentService(Guid commentId)
        {
            _commentId = commentId;
        }
        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    Text = model.Text,
                    CommentedPost = model.CommentedPost
                };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItems> GetAllComments()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Comments
                    .Select(m => new CommentListItems
                    {
                        CommentId = m.CommentId,
                        Text = m.Text
                    });
                return query.ToList();
            }
        }

        public IEnumerable<CommentListItems> GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Comments
                    
                    .Select(m => new CommentListItems
                    {
                        CommentId = m.CommentId,
                        Text = m.Text
                    });
                return query.ToList();
                
            }
        }
    }
}
