using System;

namespace MySchool.ReadingLog.Domain
{
    public class BookRead : BaseEntity
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public DateTime DateRead { get; set; }
    }
}