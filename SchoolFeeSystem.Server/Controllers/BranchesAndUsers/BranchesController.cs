using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolFeeSystem.Server.Entities;
using SchoolFeeSystem.Shared;

namespace SchoolFeeSystem.Server.Controllers.BranchesAndUsers
{
    [Route("api/branch")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly MainDbContext _context;
        public BranchesController(MainDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> AddBranch(Branch branch)
        {
            await _context.Branches.AddAsync(branch);
            await _context.SaveChangesAsync();
            var response = new Response<Branch>()
            {
                Data = branch,
                IsSuccess = true,
                Message = "عملیه تکمیل سوه"
            };
            return Ok(response);
        }
        [HttpGet]
        public async Task<List<Branch>> GetBranches()
        {
            return await _context.Branches.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Branch>> GetSingleBranch(int id)
        {
            var branch = await _context.Branches.SingleOrDefaultAsync(branch => branch.Id == id);
            if (branch == null)
            {
                return NotFound();
            }
            return Ok(branch);
        }
        [HttpPut]
        public async Task<ActionResult<Branch>> UpdateBranch(Branch branch)
        {
            var b = await _context.Branches.SingleOrDefaultAsync(x => x.Id == branch.Id);
            if (b == null)
            {
                return NotFound();
            }
            b.Name = branch.Name;
            b.Address = branch.Address;
            await _context.SaveChangesAsync();
            return Ok(b);
        }
    }
}