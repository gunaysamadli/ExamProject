using Exam.BLL.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.BLL.Validators.Student
{
 
    public class StudentCreateDtoValidation : AbstractValidator<StudentCreateDTO>
    {
        public StudentCreateDtoValidation()
        {
            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("name null ola bilmez")
                .NotEmpty().WithMessage("name daxil edilmelidir")
                .MaximumLength(20).WithMessage(" 20 simvoldan chox olmamalidir");

            RuleFor(x => x.LastName)
                .NotNull().WithMessage("code null ola bilmez")
                .NotEmpty().WithMessage("code daxil edilmelidir")
               .MaximumLength(20).WithMessage(" 20 simvoldan chox olmamalidir");
        }
    }
}
