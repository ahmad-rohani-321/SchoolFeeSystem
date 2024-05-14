using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolFeeSystem.Client.Entities
{
    public class ClassStudents
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public int StudentFee { get; set; }
        public bool IdDeleted { get; set; } = false;
        public Student Student { get; set; }
        public Class Class { get; set; }
        public DateTime EntranceDate { get; set; }
    }
}
