using Exam.BLL.DTOs;
using Exam.DAL.Repositories.Contracts;
using ExamApi.Data;
namespace Exam.BLL.Services.Contracts
{
    public interface ILessonService : IRepository<Lesson>
    {
        Task UpdateById(int? id, LessonUpdateDTO lessonUpdateDTO);
    }
}
