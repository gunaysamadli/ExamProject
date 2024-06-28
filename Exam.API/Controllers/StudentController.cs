using AutoMapper;
using Exam.BLL.Dtos;
using Exam.BLL.DTOs;
using Exam.BLL.Services.Contracts;
using Exam.DAL.Entities;
using Exam.DAL.Repositories.Contracts;
using ExamApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Student> _StudentRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IStudentService _StudentService;


        public StudentController(IMapper mapper, IRepository<Student> StudentRepository, IWebHostEnvironment webHostEnvironment, IStudentService StudentService)
        {
            _mapper = mapper;
            _StudentRepository = StudentRepository;
            _webHostEnvironment = webHostEnvironment;
            _StudentService = StudentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Student = await _StudentRepository.GetAllAsync();

            if (Student.Count == 0)
                return NotFound("Hele hec bir Student yaradilmayib");

            var StudentDtos = _mapper.Map<List<StudentDTO>>(Student);


            return Ok(StudentDtos);
        }


        [HttpGet("{id?}")]
        public async Task<IActionResult> Get([FromRoute] int? id)
        {
            var Students = await _StudentRepository.GetAllAsync();

            if (Students.Count == 0)
                return NotFound("Hele hec bir Student yaradilmayib");

            if (id is null)
                return NotFound();

            var Student = await _StudentRepository.GetAsync(id);

            if (Student is null)
                return NotFound("Bele Student movcud deyil");

            var StudentDto = _mapper.Map<StudentDTO>(Student);



            return Ok(StudentDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] StudentCreateDTO StudentCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var Student = _mapper.Map<Student>(StudentCreateDto);

            await _StudentRepository.AddAsync(Student);

            return Created(HttpContext.Request.Path, Student.Id);
        }

        [HttpPut("{id?}")]
        public async Task<IActionResult> Put([FromRoute] int? id, [FromForm] StudentUpdateDTO StudentUpdateDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Students = await _StudentRepository.GetAllAsync();

            if (Students.Count == 0)
                return NotFound("Hele hec bir brand yaradilmayib");

            await _StudentService.UpdateById(id, StudentUpdateDto);

            return Ok();
        }

        [HttpDelete("completelyDelete/{id?}")]
        public async Task<IActionResult> CompletelyDelete([FromRoute] int? id)
        {
            await _StudentService.CompletelyDeleteAsync(id);

            return Ok();
        }
    }
}
