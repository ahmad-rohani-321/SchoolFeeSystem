using System.ComponentModel.DataAnnotations;
namespace SchoolFeeSystem.Server.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string UnitqueKey { get; set; }
        public int RegNo { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string Photo { get; set; }
        public bool Gender { get; set; }
        public string BloodGroup { get; set; }
        public DateOnly DOB { get; set; }
        public string TazkiraNo { get; set; }
        public string HomeAddress { get; set; }
        public string PersonalPhone { get; set; }
        public string ParentPhone { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}