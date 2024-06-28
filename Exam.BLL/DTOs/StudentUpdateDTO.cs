using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.BLL.DTOs
{
    public class StudentUpdateDTO
    {
        public decimal Number { get; set; }

        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        [Range(0, 99)]
        public decimal ClassName { get; set; }
        public int Id { get; set; }
    }
}
