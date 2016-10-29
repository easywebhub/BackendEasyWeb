using ew.core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.application.Entities.Dto
{
    public class UserModel
    {
        public long UserIdNumber { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime CreateDate { get; set; }
        public string Sex { get; set; }
        public string Status { get; set; }

        public UserModel()
        {
            CreateDate = DateTime.Now;
        }

        public IUser ToEntity(IUser user)
        {
            user.UserName = Email;
            user.Email = Email;
            user.FullName = FullName;
            user.Birthday = Birthday;
            user.Sex = !string.IsNullOrEmpty(Sex) ? Sex.ToLower() : string.Empty;
            user.Status = Status;
            user.CreateDate = CreateDate;
            
            return user;
        }
    }
}
