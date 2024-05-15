using System.ComponentModel.DataAnnotations;

namespace SchoolFeeSystem.Server.Entities
{
    public class FeesCollectionPeriod
    {
        [Key]
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
