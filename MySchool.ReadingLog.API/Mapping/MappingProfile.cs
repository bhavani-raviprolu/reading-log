using AutoMapper;
using MySchool.ReadingLog.API.Models;
using MySchool.ReadingLog.Domain;

namespace MySchool.ReadingLog.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<Student, StudentModel>().ReverseMap();
            CreateMap<BookRead, BookReadModel>().ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.Book.BookName)).ReverseMap(); ;
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<AddUserModel, User>();
        }
    }
}