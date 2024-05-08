using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolFeeSystem.Shared;
namespace SchoolFeeSystem.Server.Controllers.ClassAndStudent
{
    [ApiController]
    [Route("api/student")]
    public class StudentController : Controller
    {
        private readonly MainDbContext _context;
        public StudentController(MainDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(Entities.Student student)
        {
            using (_context)
            {
                await _context.Student.AddAsync(student);
                await _context.SaveChangesAsync();
                var response = new Response<Entities.Student>();
                response.IsSuccess = true;
                response.Data = student;
                response.Message = "عملیه تکمیل سوه";
                return Ok(response);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetFirstTenStudents()
        {
            using (_context)
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ps-AF");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ps-AF");
                List<Entities.Student> list = await _context.Student.Where(x => x.IsActive).ToListAsync();
                //List<Entities.Student> list = await _context
                //    .Student
                //    .OrderBy(b => b.Id)
                //    .Skip(skip)
                //    .Take(10)
                //    .ToListAsync();
                return Ok(list);
            }
        }
        [HttpGet("{id}/{keywords}")]
        public async Task<IActionResult> GetBySearchKeywords(int id, string keywords)
        {
            using (_context)
            {
                switch (id)
                {
                    case 0: return Ok(await _context.Student.Where(x => x.UnitqueKey == keywords).ToListAsync());
                    case 1: return Ok(await _context.Student.Where(x => x.FirstName == keywords).ToListAsync());
                    case 2: return Ok(await _context.Student.Where(x => x.FatherName == keywords).ToListAsync());
                    case 3: return Ok(await _context.Student.Where(x => x.GrandFatherName == keywords).ToListAsync());
                    case 4: return Ok(await _context.Student.Where(x => x.PersonalPhone == keywords).ToListAsync());
                    case 5: return Ok(await _context.Student.Where(x => x.TazkiraNo == keywords).ToListAsync());
                    case 6: return Ok(await _context.Student.Where(x => x.RegNo == int.Parse(keywords)).ToListAsync());
                    case 7: return Ok(await _context.Student.Where(x => x.ParentPhone == keywords).ToListAsync());
                    default: return Ok(await _context.Student.ToListAsync());
                }
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            using (_context)
            {
                Entities.Student student = await _context.Student.SingleOrDefaultAsync(x => x.Id == id);
                if (student == null)
                {
                    return NotFound();
                }
                var response = new Response<Entities.Student>()
                {
                    Data = student,
                    Message = "عملیه تکمیل سوه",
                    IsSuccess = true
                };
                return Ok(response);
            }
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
                Response<Entities.Student> response = new() 
                {
                    Data = getstudent,
                    IsSuccess = true,
                    Message = "عمیله تکمیل سوه"
                };
                return Ok(response);
            }
        }
        [HttpPut("{id}/{active}")]
        public async Task<ActionResult<bool>> ChangeActivation(int id, bool active)
        {
            using (_context)
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
                    return Ok(true);
                }
            }
        }
    }
}