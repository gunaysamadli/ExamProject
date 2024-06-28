using AutoMapper;
using Exam.BLL.DTOs;
using Exam.BLL.Services.Contracts;
using Exam.DAL.Entities;
using Exam.DAL.Repositories.Contracts;
using ExamApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Exam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ExamController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IRepository<Lesson> _lessonRepository;
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<LessonExam> _examRepository;
        private readonly IExamService _examService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ExamController(IMapper mapper, IWebHostEnvironment webHostEnvironment, IRepository<Lesson> lessonRepository, IRepository<Student> studentRepository, IRepository<LessonExam> examRepository, IExamService examService)
        {
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _lessonRepository = lessonRepository;
            _studentRepository = studentRepository;
            _examRepository = examRepository;
            _examService = examService;
        }

      

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Exam = await _examRepository.GetAllAsync();

            if (Exam.Count == 0)
                return NotFound("Hele hec bir Imtahan yaradilmayib");

            var ExamDtos = _mapper.Map<List<ExamDTO>>(Exam);


            var lessons = await _lessonRepository.GetAllAsync();
            ExamDtos.ForEach(x =>
            {
                var lesson = lessons.FirstOrDefault(y => y.Id == x.LessonId);
                if (lesson != null)
                {
                    x.LessonCode = lesson.Code;
                }
              
            });

            var students = await _studentRepository.GetAllAsync();
            ExamDtos.ForEach(x =>
            {
                var student = students.FirstOrDefault(y => y.Id == x.StudentId);
                if (student != null)
                {
                    x.StudentNumber = student.Number;
                }
            });





            return Ok(ExamDtos);
        }


        [HttpGet("{id?}")]
        public async Task<IActionResult> Get([FromRoute] int? id)
        {
            if (id is null)
                return NotFound();

            var Exams = await _examRepository.GetAllAsync();

            if (Exams.Count == 0)
                return NotFound("Hele hec bir Imtahan yaradilmayib");

            var Exam = await _examRepository.GetAsync(id);

            if (Exam is null)
                return NotFound("Bele Imtahan movcud deyil");

            var ExamDto = _mapper.Map<ExamDTO>(Exam);



            var lessons = await _lessonRepository.GetAllAsync();
            var lesson = lessons.FirstOrDefault(y => y.Id == ExamDto.LessonId);
            if (lesson != null)
            {
                ExamDto.LessonCode = lesson.Code; 
            }

            var students = await _studentRepository.GetAllAsync();
            var student = students.FirstOrDefault(y => y.Id == ExamDto.StudentId);
            if (student != null)
            {
                ExamDto.StudentNumber = student.Number;
            }




            return Ok(ExamDto);
        }

       

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ExamCreateDTO examCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Exam = _mapper.Map<LessonExam>(examCreateDto);

            await _examService.AddAsync(Exam);

            return Created(HttpContext.Request.Path, Exam.Id);
        }

        [HttpPut("{id?}")]
        public async Task<IActionResult> Put([FromRoute] int? id, [FromForm] ExamUpdateDTO examUpdateDto)
        {
            var Exam = await _examRepository.GetAllAsync();

            if (Exam.Count == 0)
                return NotFound("Hele hec bir Imtahan yaradilmayib");

            await _examService.UpdateById(id, examUpdateDto);

            return Ok();
        }

        [HttpDelete("completelyDelete/{id?}")]
        public async Task<IActionResult> CompletelyDelete([FromRoute] int? id)
        {
            await _examService.CompletelyDeleteAsync(id);

            return Ok();
        }

    }
}
