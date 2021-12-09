using MySchool.ReadingLog.Domain;
using System.Collections.Generic;

namespace MySchool.ReadingLog.API.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Role Role { get; set; }

        public IList<StudentModel> Students { get; set; }
    }
}