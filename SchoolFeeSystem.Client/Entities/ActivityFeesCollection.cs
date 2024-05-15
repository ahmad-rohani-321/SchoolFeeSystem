using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolFeeSystem.Client.Entities
{
    public class ActivityFeesCollection
    {
        public int Id { get; set; }
        public int StudentClassId { get; set; }
        public int Amount { get; set; }


        public DateTime CreationDate { get; set; } = DateTime.Now;
        [ForeignKey(nameof(StudentClassId))]
        public ClassStudents ClassStudent { get; set; }
    }
}
