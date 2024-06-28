using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.BLL.DTOs
{
    public class LessonUpdateDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }

        public string Name { get; set; }

        public decimal ClassName { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
    }
}
