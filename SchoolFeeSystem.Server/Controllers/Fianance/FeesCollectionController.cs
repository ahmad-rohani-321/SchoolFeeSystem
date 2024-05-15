using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolFeeSystem.Server.Entities;
using SchoolFeeSystem.Shared;

namespace SchoolFeeSystem.Server.Controllers.Fianance
{
    [Route("api/feescollection")]
    [ApiController]
    public class FeesCollectionController(MainDbContext context) : ControllerBase
    {
        private readonly MainDbContext _context = context;

        #region monthly fees collection 
        [HttpPost("monthlyfees")]
        public async Task<Response<List<FeesCollection>>> CollectMonthlyFee(List<FeesCollection> feesCollection)
        {
            using (_context)
            {
                foreach (var item in feesCollection)
                {
                    _context.Entry(item).State = EntityState.Modified;
                }
                await _context.SaveChangesAsync();
                return new Response<List<FeesCollection>> { Data = feesCollection, IsSuccess = true };
            }
        }

        [HttpGet("monthlyfees/{classId}")]
        public async Task<List<FeesCollection>> GetClassStudentsForMonthlyFee(int classId)
        {
            using (_context)
            {
                return await _context.FeesCollection
                    .Include(c => c.ClassStudent)
                    .Include(p => p.FeesCollectionPeriod)
                    .Where(x => x.ClassStudent.ClassId == classId)
                    .ToListAsync();
            }
        }
        #endregion

        #region monthly transport fees collection
        [HttpPost("transportfee")]
        public async Task<Response<List<TransportFeesCollection>>> CollectTransportonthlyFee(List<TransportFeesCollection> feesCollection)
        {
            using (_context)
            {
                foreach (var item in feesCollection)
                {
                    _context.Entry(item).State = EntityState.Modified;
                }
                await _context.SaveChangesAsync();
                return new Response<List<TransportFeesCollection>> { Data = feesCollection, IsSuccess = true };
            }
        }

        [HttpGet("transportfee/{classId}")]
        public async Task<List<TransportFeesCollection>> GetClassStudentsForMonthlyTransportFee(int classId)
        {
            using (_context)
            {
                return await _context.TransportFeesCollection
                    .Include(c => c.ClassStudent)
                    .Include(p => p.FeesCollectionPeriod)
                    .Where(x => x.ClassStudent.ClassId == classId)
                    .ToListAsync();
            }
        }
        #endregion

        #region monthly transport fees collection
        [HttpPost("activityfee")]
        public async Task<Response<List<ActivityFeesCollection>>> CollectTransportonthlyFee(List<ActivityFeesCollection> feesCollection)
        {
            using (_context)
            {
                foreach (var item in feesCollection)
                {
                    _context.Entry(item).State = EntityState.Modified;
                }
                await _context.SaveChangesAsync();
                return new Response<List<ActivityFeesCollection>> { Data = feesCollection, IsSuccess = true };
            }
        }

        [HttpGet("activityfee/{classId}")]
        public async Task<List<ActivityFeesCollection>> GetClassStudentsActivityFee(int classId)
        {
            using (_context)
            {
                return await _context.ActivityFeesCollection
                    .Include(c => c.ClassStudent)
                    .Where(x => x.ClassStudent.ClassId == classId)
                    .ToListAsync();
            }
        }
        #endregion

    }
}
