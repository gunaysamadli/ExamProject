using AutoMapper;
using Exam.BLL.Dtos;
using Exam.BLL.DTOs;
using Exam.DAL.Entities;
using ExamApi.Data;

namespace Exam.BLL.Mapping
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            CreateMap<Lesson,LessonDTO>().ReverseMap();
            CreateMap<Lesson, LessonCreateDTO>().ReverseMap();
            CreateMap<Lesson, LessonUpdateDTO>().ReverseMap();

            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Student, StudentCreateDTO>().ReverseMap();
            CreateMap<Student, StudentUpdateDTO>().ReverseMap();

            CreateMap<LessonExam, ExamDTO>().ReverseMap();
            CreateMap<LessonExam, ExamCreateDTO>().ReverseMap();
            CreateMap<LessonExam, ExamUpdateDTO>().ReverseMap();
        }
    }
}
