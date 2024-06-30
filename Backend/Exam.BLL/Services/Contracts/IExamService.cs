using Exam.BLL.DTOs;
using Exam.DAL.Entities;
using Exam.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.BLL.Services.Contracts
{

    public interface IExamService : IRepository<LessonExam>
    {
        Task UpdateById(int? id, ExamUpdateDTO examUpdateDTO);
    }
}
