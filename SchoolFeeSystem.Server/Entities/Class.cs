using System.ComponentModel.DataAnnotations;

namespace SchoolFeeSystem.Server.Entities
{
    public class Class
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public TimeOnly ClassTiming { get; set; }
        public bool IsActive { get; set; }
        public int FeeAmount { get; set; }
    }
}