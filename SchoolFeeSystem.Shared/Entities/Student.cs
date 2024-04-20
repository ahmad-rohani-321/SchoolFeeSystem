using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolFeeSystem.Shared.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public int RollNo { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string FatherName { get; set; } = default!;
        public string GrandFatherName { get; set; } = default!;
        public string Photo { get; set; } = default!;
        public DateOnly AdmissionDate { get; set; }
    }
}
