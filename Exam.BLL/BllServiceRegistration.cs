using Exam.BLL.DTOs;
using Exam.BLL.Services;
using Exam.BLL.Services.Contracts;
using Exam.BLL.Validators.Exam;
using Exam.BLL.Validators.Lesson;
using Exam.BLL.Validators.Student;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.BLL
{
    public static class BllServiceRegistration
    {
        public static IServiceCollection AddBllServices(this IServiceCollection services)
        {



            services.AddScoped<ILessonService, LessonManager>();
            services.AddScoped<IValidator<LessonCreateDTO>, LessonCreateDtoValidation>();

            services.AddScoped<IStudentService, StudentManager>();
            services.AddScoped<IValidator<StudentCreateDTO>, StudentCreateDtoValidation>();

            services.AddScoped<IExamService, ExamManager>();
            services.AddScoped<IValidator<ExamCreateDTO>, ExamCreateDtoValidation>();

            return services;
        }
    }
}
