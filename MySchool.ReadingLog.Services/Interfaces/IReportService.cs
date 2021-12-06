using MySchool.ReadingLog.Domain;
using System.Collections.Generic;

namespace MySchool.ReadingLog.Services.Interfaces
{
    public interface IReportService
    {
        List<BooksReadbyGrade> GetBooksReadbyGrade(string grade);
    }
}