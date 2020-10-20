using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class LikeService
    {
        private readonly Guid _likeId;

        public LikeService(Guid likeId)
        {
            _likeId = likeId;
        }

        public bool CreateLike(LikeCreate model)
        {
            var entity =
                new Like()
                {
                    PostId = model.PostId,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Like.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IHttpActionResult Post(LikeCreate like)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.CreateComment(comment))
                return InternalServerError();

            return Ok();
        }

        //public IEnumerable<LikeListItem> GetAllLikes() 
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //                .Likes
        //                .Where(e => e.OwnerId == _userId)
        //                .Select(
        //                    e =>
        //                        new NoteListItem
        //                        {
        //                            NoteId = e.NoteId,
        //                            Title = e.Title,
        //                            CreatedUtc = e.CreatedUtc
        //                        }
        //                );

        //        return query.ToArray();
        //    }
        //}

        //public NoteDetail GetNoteById(int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .Notes
        //                .Single(e => e.NoteId == id && e.OwnerId == _userId);
        //        return
        //            new NoteDetail
        //            {
        //                NoteId = entity.NoteId,
        //                Title = entity.Title,
        //                Content = entity.Content,
        //                CreatedUtc = entity.CreatedUtc,
        //                ModifiedUtc = entity.ModifiedUtc
        //            };
        //    }
        //}

        ////public bool UpdateNote(NoteEdit model)
        ////{
        ////    using (var ctx = new ApplicationDbContext())
        ////    {
        ////        var entity =
        ////            ctx
        ////                .Notes
        ////                .Single(e => e.NoteId == model.NoteId && e.OwnerId == _userId);

        ////        entity.Title = model.Title;
        ////        entity.Content = model.Content;
        ////        entity.ModifiedUtc = DateTimeOffset.UtcNow;

        ////        return ctx.SaveChanges() == 1;
        ////    }
        ////}

        ////public bool DeleteNote(int noteId)
        ////{
        ////    using (var ctx = new ApplicationDbContext())
        ////    {
        ////        var entity =
        ////            ctx
        ////                .Notes
        ////                .Single(e => e.NoteId == noteId && e.OwnerId == _userId);

        ////        ctx.Notes.Remove(entity);

        ////        return ctx.SaveChanges() == 1;
        ////    }
        ////}
    }
}
