using AutoMapper;
using Exam.BLL.DTOs;
using Exam.BLL.Services.Contracts;
using Exam.DAL.DataContext;
using Exam.DAL.Entities;
using Exam.DAL.Repositories;
using ExamApi.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.BLL.Services
{
    public class ExamManager : EfCoreRepository<LessonExam>, IExamService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public ExamManager(AppDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task CompletelyDeleteAsync(int? id)
        {
            if (id is null) throw new Exception();

            var deletedEntity = await _dbContext.LessonExams.FindAsync(id);

            if (deletedEntity is null) throw new Exception();


            _dbContext.Remove(deletedEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateById(int? id, ExamUpdateDTO ExamUpdateDTO)
        {
            if (id is null) throw new Exception();

            var existExam = await _dbContext.LessonExams.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (existExam is null) throw new Exception();

            if (ExamUpdateDTO.Id != id) throw new Exception();



            if (ExamUpdateDTO.Score is 0) ExamUpdateDTO.Score = existExam.Score;



            var Exam = _mapper.Map<LessonExam>(ExamUpdateDTO);

            _dbContext.LessonExams.Update(Exam);
            await _dbContext.SaveChangesAsync();
        }


    }
}
