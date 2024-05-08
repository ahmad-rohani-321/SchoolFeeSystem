using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolFeeSystem.Server.Entities;
using SchoolFeeSystem.Shared;

namespace SchoolFeeSystem.Server.Controllers.ClassAndStudent
{
    [Route("api/class")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly MainDbContext _context;
        public ClassController(MainDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<Class>> GetClassesAsync()
        {
            using (_context)
            {
                return await _context.Class.Include("Branch").ToListAsync();
            }
        }
        [HttpGet("{id}")]
        public async Task<Class> GetSingleClass(int id)
        {
            using (_context)
            {
                return await _context.Class.SingleOrDefaultAsync(x => x.Id == id);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Response<Class>>> AddClass(Class clas)
        {
            using (_context)
            {
                clas.CreationDate = DateTime.Now;
                await _context.Class.AddAsync(clas);
                await _context.SaveChangesAsync();
                var response = new Response<Class>();
                response.IsSuccess = true;
                response.Message = "ټولګۍ اضافه سو";
                response.Data = clas;
                return Ok(response);
            }
        }
        [HttpPut]
        public async Task<ActionResult<Class>> UpdateClass(Class clas)
        {
            using (_context)
            {
                var c = await _context.Class.SingleOrDefaultAsync(x => x.Id ==  clas.Id);
                c.Branch = clas.Branch;
                c.ClassTiming = clas.ClassTiming;
                c.Description = clas.Description;
                c.FeeAmount = clas.FeeAmount;
                c.Name = clas.Name;
                await _context.SaveChangesAsync();
                return Ok(clas);
            }
        }
    }
}
