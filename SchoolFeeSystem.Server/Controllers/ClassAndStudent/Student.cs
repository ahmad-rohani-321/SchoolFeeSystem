using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace SchoolFeeSystem.Server.Controllers.ClassAndStudent
{
    [ApiController]
    [Route("api/student")]
    public class Student : Controller
    {
        private readonly MainDbContext _context;
        public Student(MainDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(Entities.Student student)
        {
            await _context.Student.AddAsync(student);
            await _context.SaveChangesAsync();
            return Ok(student.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetFirstTenStudents()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ps-AF");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ps-AF");
            List<Entities.Student> list = await _context.Student.Take(10).ToListAsync();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            Entities.Student? student = await _context.Student.SingleOrDefaultAsync(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Entities.Student student)
        {
            using (_context)
            {
                Entities.Student getstudent = (await _context.Student.SingleOrDefaultAsync(x => x.Id == id))!;
                if (getstudent == null)
                {
                    return NotFound();
                }
                else if (id != student.Id)
                {
                    return BadRequest("Object not found");
                }
                else
                {
                    getstudent.FirstName = student.FirstName;
                    getstudent.FatherName = student.FatherName;
                    getstudent.GrandFatherName = student.GrandFatherName;
                    getstudent.Photo = student.Photo;
                    getstudent.Gender = student.Gender;
                    getstudent.BloodGroup = student.BloodGroup;
                    getstudent.DOB = student.DOB;
                    getstudent.TazkiraNo = student.TazkiraNo;
                    getstudent.HomeAddress = student.HomeAddress;
                    getstudent.ParentPhone = student.ParentPhone;
                    getstudent.PersonalPhone = student.PersonalPhone;
                    await _context.SaveChangesAsync();
                    return Ok(getstudent);
                }
            }
        }
        [HttpPut("{id}/{active}")]
        public async Task<IActionResult> ChangeActivation(int id, bool active)
        {
            Entities.Student getstudent = (await _context.Student.SingleOrDefaultAsync(x => x.Id == id))!;
            if (getstudent == null)
            {
                return NotFound();
            }
            else
            {
                getstudent.IsActive = active;
                await _context.SaveChangesAsync();
                return Ok(getstudent);
            }
        }
    }
}