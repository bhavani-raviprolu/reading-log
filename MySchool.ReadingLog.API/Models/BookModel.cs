using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.ReadingLog.API.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
