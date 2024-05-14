using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SchoolFeeSystem.Server.Entities;
using SchoolFeeSystem.Shared;

namespace SchoolFeeSystem.Server.Controllers.ClassAndStudent
{
    [Route("api/classstudents")]
    [ApiController]
    public class ClassStudentsController : ControllerBase
    {
        private readonly MainDbContext _context;
        public ClassStudentsController(MainDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<Response<string>>> AddStudents(HashSet<ClassStudents> students)
        {
            using (_context)
            {
                foreach (var item in students)
                {
                    item.Student = null;
                }
                await _context.ClassStudents.AddRangeAsync(students);
                await _context.SaveChangesAsync();
                var response = new Response<string>()
                {
                    Data = "عملیه تکمیل سوه",
                    IsSuccess = true
                };
                return Ok(response);
            }
        }
        [HttpGet("{classId}")]
        public async Task<ActionResult<List<ClassStudents>>> GetClassStudents(int classId)
        {
            using (_context)
            {
                return await _context.ClassStudents.Include("Student").Where(x => x.ClassId == classId && !x.IdDeleted).ToListAsync();
            }
        }
        [HttpGet("/single/{classStudentId}")]
        public async Task<ActionResult<ClassStudents>> GetSingleClassStudent(int classStudentId)
        {
            using (_context)
            {
                return await _context.ClassStudents.Include("Student")
                    .SingleOrDefaultAsync(x => x.Id == classStudentId);
            }
        }
        [HttpGet("add/{classId}")]
        public async Task<ActionResult<List<ClassStudents>>> GetStudents(int classId)
        {
            using (_context)
            {
                var @class = await _context.Class.SingleOrDefaultAsync(x => x.Id == classId);
                return await _context.Student.Where(x => x.IsActive).Select(x => new ClassStudents()
                    {
                        EntranceDate = DateTime.Now,
                        IdDeleted = false,
                        StudentId = x.Id,
                        ClassId = classId,
                        StudentFee = @class.FeeAmount,
                        Student = x
                    }
                    )
                    .Take(10)
                    .ToListAsync();
            }
        }
        [HttpPut]
        public async Task<ActionResult<Response<ClassStudents>>> UpdateStatus(List<ClassStudents> student)
        {
            using (_context)
            {
                await _context.ClassStudents.Where(x => student.Select(x => x.Id).Contains(x.Id))
                    .ExecuteUpdateAsync(x => x.SetProperty(z => z.IdDeleted, true));
                await _context.SaveChangesAsync();
                return new Response<ClassStudents>() { Data = null, IsSuccess = true, Message = "عملیه تکمیل سوه" };

            }
        }
        [HttpPut("{id}/{feeAmount}")]
        public async Task<ActionResult<Response<ClassStudents>>> UpdateFee(int id, int feeAmount)
        {
            using (_context)
            {
                var s = await _context.ClassStudents.SingleOrDefaultAsync(x => x.Id == id);
                s.StudentFee = feeAmount;
                await _context.SaveChangesAsync();
                return new Response<ClassStudents>() { Data = s, IsSuccess = true, Message = "عملیه تکمیل سوه" };
            }
        }

        [HttpPost("add")]
        public async Task<ActionResult<Response<ClassStudents>>> MoveToClass(HashSet<ClassStudents> students)
        {
            using (_context)
            {
                foreach (var item in students)
                {
                    item.Student = null;
                    item.IdDeleted = true;
                }
                _context.UpdateRange(students);
                _context.ClassStudents.AddRange(students);
                await _context.SaveChangesAsync();
                return new Response<ClassStudents>() { Data = null, IsSuccess = true, Message = "عملیه تکمیل سوه" };
            }
        }
    }
}
