using Exam.BLL.DTOs;
using FluentValidation;

namespace Exam.BLL.Validators.Lesson
{
    public class LessonCreateDtoValidation : AbstractValidator<LessonCreateDTO>
    {
        public LessonCreateDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("name null ola bilmez")
                .NotEmpty().WithMessage("name daxil edilmelidir")
                .MinimumLength(3).WithMessage("name 3 simvoldan az olmalidir")
                .MaximumLength(20).WithMessage("name 20 simvoldan chox olmalidir");

            RuleFor(x => x.Code)
                .NotNull().WithMessage("code null ola bilmez")
                .NotEmpty().WithMessage("code daxil edilmelidir")
                .MaximumLength(3).WithMessage("name 3 simvoldan chox olmalidir");
        }
    }
}
