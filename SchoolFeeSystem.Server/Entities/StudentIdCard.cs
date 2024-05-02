using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolFeeSystem.Server.Entities
{
    public class StudentIdCard
    {
        [Key]
        public int Id { get; set; }
        public int SerialNo { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly ExpireDate { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }
        [ForeignKey(nameof(ClassId))]
        public Class Class { get; set; }
    }
}