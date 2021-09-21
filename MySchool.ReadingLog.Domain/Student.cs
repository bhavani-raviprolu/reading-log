using System.Collections.Generic;

namespace MySchool.ReadingLog.Domain
{
    public class Student : BaseEntity
    {
        public string StudentName { get; set; }
        public string Grade { get; set; }
        public List<BookRead> BooksRead { get; set; }
    }
}