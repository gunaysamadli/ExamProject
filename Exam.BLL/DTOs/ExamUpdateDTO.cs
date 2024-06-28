﻿using ExamApi.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.BLL.DTOs
{
    public class ExamUpdateDTO
    {
        [Required]
        public int LessonId { get; set; }

        [Required]
        public int StudentId { get; set; }

        public DateTime ExamSchedule { get; set; }

        public decimal Score { get; set; }

        public int Id { get; set; }
    }
}
