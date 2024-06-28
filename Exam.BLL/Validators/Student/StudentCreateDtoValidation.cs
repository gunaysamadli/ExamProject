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
                .MinimumLength(3).WithMessage("name 3 simvoldan az olmalidir")
                .MaximumLength(20).WithMessage("name 20 simvoldan chox olmalidir");

            RuleFor(x => x.LastName)
                .NotNull().WithMessage("code null ola bilmez")
                .NotEmpty().WithMessage("code daxil edilmelidir")
                .MaximumLength(3).WithMessage("name 3 simvoldan chox olmalidir");
        }
    }
}
