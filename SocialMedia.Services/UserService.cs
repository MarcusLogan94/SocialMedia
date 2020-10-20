using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class UserService
    {
        private Guid _userId;

        public UserService(Guid userId)
        {
            _userId = userId;
        }
        //
        public bool CreateUser(UserCreate model)
        {
            var entity =
                new CustomUser()
                {
                    UserId = _userId,
                    UserName = model.UserName,
                    Email = model.Email
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CustomUsers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public CustomUser GetUserByGUID(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.CustomUsers
                       .Where(p => p.UserId == _userId)
                       .Select(p => p.UserId == _userId);
                return (CustomUser)query;
            }
        }

        //
    }
}
