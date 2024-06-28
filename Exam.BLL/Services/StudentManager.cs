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
    public class StudentManager : EfCoreRepository<Student>, IStudentService
    {

        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public StudentManager(AppDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task CompletelyDeleteAsync(int? id)
        {
            if (id is null) throw new Exception();

            var deletedEntity = await _dbContext.Students.FindAsync(id);

            if (deletedEntity is null) throw new Exception();


            _dbContext.Remove(deletedEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateById(int? id, StudentUpdateDTO studentUpdateDTO)
        {
            if (id is null) throw new Exception();

            var existStudent = await _dbContext.Students.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (existStudent is null) throw new Exception();

            if (studentUpdateDTO.Id != id) throw new Exception();



            if (studentUpdateDTO.FirstName is null) studentUpdateDTO.FirstName = existStudent.FirstName;



            var Student = _mapper.Map<Student>(studentUpdateDTO);

            _dbContext.Students.Update(Student);
            await _dbContext.SaveChangesAsync();
        }

    }
}
