using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.ReadingLog.API.Models
{
    public class BookReadModel
    {
        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        public DateTime DateRead { get; set; }
    }
}
