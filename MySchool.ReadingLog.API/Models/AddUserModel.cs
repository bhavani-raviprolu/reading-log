using MySchool.ReadingLog.Domain;

namespace MySchool.ReadingLog.API.Models
{
    public class AddUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Role { get; set; }
    }
}