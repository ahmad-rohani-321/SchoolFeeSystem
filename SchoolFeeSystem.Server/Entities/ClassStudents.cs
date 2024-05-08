using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SchoolFeeSystem.Server.Entities
{
    public class ClassStudents
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set;}
        public int ClassId { get; set;}
        public int StudentFee { get; set; }
        public bool IdDeleted { get; set; } = false;
        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }
        [ForeignKey(nameof(ClassId))]
        public Class Class { get; set; }
        public DateTime EntranceDate { get; set; } = DateTime.Now;
    }
}