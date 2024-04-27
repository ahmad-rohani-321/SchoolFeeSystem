using System.ComponentModel.DataAnnotations;
namespace SchoolFeeSystem.Server.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string UnitqueKey { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string FatherName { get; set; } = default!;
        public string GrandFatherName { get; set; } = default!;
        public string Photo { get; set; } = default!;
        public bool IsMale { get; set; }
        public string TazkiraNo { get; set; } = default!;
        public string HomeAddress { get; set; } = default!;
        public string PersonalPhone { get; set; } = default!;
        public string ParentPhone { get; set; } = default!;
    }
}
