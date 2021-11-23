using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.ReadingLog.API.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage ="Student Name is Required")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Grade is Required")]
        public string Grade { get; set; }
        public List<BookReadModel>  BooksRead { get; set; }
        
    }
}
