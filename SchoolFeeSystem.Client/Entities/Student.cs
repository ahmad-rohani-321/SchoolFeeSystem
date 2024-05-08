using System.ComponentModel.DataAnnotations;

namespace SchoolFeeSystem.Client.Entities
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "آیډي حتمي ده")]
        public string UnitqueKey { get; set; } = shortid.ShortId.Generate();
        public int RegNo { get; set; }
        [Required(ErrorMessage = "نوم حتمي دی")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "د پلار نوم حتمي دی")]
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string Photo { get; set; }
        public bool Gender { get; set; } = true;
        public string BloodGroup { get; set; }
        public DateOnly DOB { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddDays(-20));
        public string TazkiraNo { get; set; }
        public string HomeAddress { get; set; }
        public string PersonalPhone { get; set; }
        public string ParentPhone { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
