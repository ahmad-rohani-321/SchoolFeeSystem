using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolFeeSystem.Shared.Entities
{
    public class Users
    {
        public int ID { get; set; }
        public EducationTypes EducationType { get; set; }
        public string UserName { get; set; } = default!;
        public byte[] PasswordHash { get; set; } = default!;
        public byte[] PasswordSalt { get; set; } = default!;
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
