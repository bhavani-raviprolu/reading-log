using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MySchool.ReadingLog.Domain;
using MySchool.ReadingLog.API.Models;
using System.Linq.Expressions;

namespace MySchool.ReadingLog.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<Student, StudentModel>().ReverseMap();
            CreateMap<BookRead, BookReadModel>().ForMember(dest => dest.BookName, opt => opt.MapFrom(src=>src.Book.BookName)).ReverseMap(); ;
        }

        
    }
}
