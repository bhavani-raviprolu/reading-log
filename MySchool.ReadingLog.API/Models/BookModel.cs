using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.ReadingLog.API.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Book Name is Required")]
        public string BookName { get; set; }
        
    }
}
