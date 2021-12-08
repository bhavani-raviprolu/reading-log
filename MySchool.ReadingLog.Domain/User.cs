using System.Collections.Generic;

namespace MySchool.ReadingLog.Domain
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Role Role { get; set; }

        public IList<Student> Students { get; set; } = new List<Student>();
    }
}