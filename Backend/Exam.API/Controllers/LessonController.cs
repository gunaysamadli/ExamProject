using AutoMapper;
using Exam.BLL.Dtos;
using Exam.BLL.DTOs;
using Exam.BLL.Services.Contracts;
using Exam.DAL.DataContext;
using Exam.DAL.Repositories.Contracts;
using ExamApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Lesson> _LessonRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILessonService _lessonService;


        public LessonController(IMapper mapper, IRepository<Lesson> LessonRepository, IWebHostEnvironment webHostEnvironment, ILessonService lessonService)
        {
            _mapper = mapper;
            _LessonRepository = LessonRepository;
            _webHostEnvironment = webHostEnvironment;
            _lessonService = lessonService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Lesson = await _LessonRepository.GetAllAsync();

            if (Lesson.Count == 0)
                return NotFound("Hele hec bir Lesson yaradilmayib");

            var LessonDtos = _mapper.Map<List<LessonDTO>>(Lesson);
            

            return Ok(LessonDtos);
        }

      
        [HttpGet("{id?}")]
        public async Task<IActionResult> Get([FromRoute] int? id)
        {
            var Lessons = await _LessonRepository.GetAllAsync();

            if (Lessons.Count == 0)
                return NotFound("Hele hec bir Lesson yaradilmayib");

            if (id is null)
                return NotFound();

            var Lesson = await _LessonRepository.GetAsync(id);

            if (Lesson is null)
                return NotFound("Bele Lesson movcud deyil");

            var LessonDto = _mapper.Map<LessonDTO>(Lesson);

            

            return Ok(LessonDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] LessonCreateDTO LessonCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var Lesson = _mapper.Map<Lesson>(LessonCreateDto);

            await _LessonRepository.AddAsync(Lesson);

            return Created(HttpContext.Request.Path, Lesson.Id);
        }

        [HttpPut("{id?}")]
        public async Task<IActionResult> Put([FromRoute] int? id, [FromForm] LessonUpdateDTO LessonUpdateDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var lessons = await _LessonRepository.GetAllAsync();

            if (lessons.Count == 0)
                return NotFound("Hele hec bir brand yaradilmayib");

            await _lessonService.UpdateById(id, LessonUpdateDto);

            return Ok();
        }

        [HttpDelete("completelyDelete/{id?}")]
        public async Task<IActionResult> CompletelyDelete([FromRoute] int? id)
        {
            await _lessonService.CompletelyDeleteAsync(id);

            return Ok();
        }
    }
}
