using Exam.DAL.Entities;
using Exams.DAL.Base;
using System.ComponentModel.DataAnnotations;

namespace ExamApi.Data
{
    public class Lesson: IEntity
    {
        [StringLength(3)]
        public string Code { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [Range(0, 99)]
        public decimal ClassName { get; set; }

        [StringLength(20)]
        public string TeacherFirstName { get; set; }

        [StringLength(20)]
        public string TeacherLastName { get; set; }
        public int Id { get ; set; }

        public virtual List<LessonExam> LessonExams { get; set; }


    }
}
