using System.Collections.Generic;

namespace MySchool.ReadingLog.Domain
{
    public class Book : BaseEntity
    {
        public string BookName { get; set; }
        public List<BookRead> BooksRead { get; set; }
    }
}