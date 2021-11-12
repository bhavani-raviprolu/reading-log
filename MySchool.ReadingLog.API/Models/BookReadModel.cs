using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.ReadingLog.API.Models
{
    public class BookReadModel
    {
        public int BookId { get; set; }

        public string BookName { get; set; }
        public DateTime DateRead { get; set; }
    }
}
