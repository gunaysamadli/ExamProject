using Exams.DAL.Base;
using System.ComponentModel.DataAnnotations;

namespace Exam.DAL.Entities
{ 
    public class Student : IEntity
    {
        public decimal Number { get; set; }

        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        [Range(0, 99)]
        public decimal ClassName { get; set; }
        public int Id { get; set; }
        public virtual List<LessonExam> LessonExams { get; set; }
    }
}
