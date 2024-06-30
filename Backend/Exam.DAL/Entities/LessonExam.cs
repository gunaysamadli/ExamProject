using ExamApi.Data;
using Exams.DAL.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.DAL.Entities
{
    public class LessonExam : IEntity
    {
        [Required]
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        [Required]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public DateTime ExamSchedule { get; set; }

        public decimal Score { get; set; }

        public int Id { get; set; }

    }
}
