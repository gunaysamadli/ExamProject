using AutoMapper;
using Exam.BLL.DTOs;
using Exam.BLL.Services.Contracts;
using Exam.DAL.DataContext;
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
    public class LessonManager : EfCoreRepository<Lesson>, ILessonService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public LessonManager(AppDbContext dbContext,  IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task CompletelyDeleteAsync(int? id)
        {
            if (id is null) throw new Exception();

            var deletedEntity = await _dbContext.Lessons.FindAsync(id);

            if (deletedEntity is null) throw new Exception();


            _dbContext.Remove(deletedEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateById(int? id, LessonUpdateDTO lessonUpdateDTO)
        {
            if (id is null) throw new Exception();

            var existLesson = await _dbContext.Lessons.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (existLesson is null) throw new Exception();

            if (lessonUpdateDTO.Id != id) throw new Exception();

            

            if (lessonUpdateDTO.Name is null) lessonUpdateDTO.Name = existLesson.Name;

           

            var Lesson = _mapper.Map<Lesson>(lessonUpdateDTO);

            _dbContext.Lessons.Update(Lesson);
            await _dbContext.SaveChangesAsync();
        }

        
    }
}
