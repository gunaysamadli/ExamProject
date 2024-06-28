using Exam.BLL.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.BLL.Validators.Exam
{

    public class ExamCreateDtoValidation : AbstractValidator<ExamCreateDTO>
    {
        public ExamCreateDtoValidation()
        {
           
        }
    }
}
