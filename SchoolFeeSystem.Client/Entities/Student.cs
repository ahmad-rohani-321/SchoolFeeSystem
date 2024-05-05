namespace SchoolFeeSystem.Client.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string UnitqueKey { get; set; } = shortid.ShortId.Generate();
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
        public bool IsActive { get; set; } = true;
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
