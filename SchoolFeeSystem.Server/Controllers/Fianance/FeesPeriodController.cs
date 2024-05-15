using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolFeeSystem.Shared;

namespace SchoolFeeSystem.Server.Controllers.Fianance
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeesPeriodController : ControllerBase
    {
        private readonly MainDbContext _context;
        public FeesPeriodController(MainDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Entities.FeesCollectionPeriod>> GetCurrentPeriod()
        {
            using (_context)
            {
                return await _context.FeesCollectionPeriod.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
            }
        }
        [HttpPost]
        public async Task<ActionResult<Response<Entities.FeesCollectionPeriod>>> AddPerid(Entities.FeesCollectionPeriod period)
        {
            using (_context)
            {
                var per = await _context.FeesCollectionPeriod.AddAsync(period);
                await _context.SaveChangesAsync();
                return new Response<Entities.FeesCollectionPeriod>()
                {
                    Data = period,
                    IsSuccess = true,
                };
            }
        }
    }
}
