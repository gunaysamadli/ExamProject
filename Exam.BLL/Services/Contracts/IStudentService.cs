using Exam.BLL.DTOs;
using Exam.DAL.Entities;
using Exam.DAL.Repositories.Contracts;
using ExamApi.Data;

namespace Exam.BLL.Services.Contracts
{
    
    public interface IStudentService : IRepository<Student>
    {
        Task UpdateById(int? id, StudentUpdateDTO studentUpdateDTO);
    }
}
