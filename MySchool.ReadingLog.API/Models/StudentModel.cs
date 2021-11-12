using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.ReadingLog.API.Models
{
    public class StudentModel
    {
        public string StudentName { get; set; }
        public string Grade { get; set; }
        public List<BookReadModel>  BooksReadModel { get; set; }
        
    }
}
