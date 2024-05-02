using System.ComponentModel.DataAnnotations;

namespace SchoolFeeSystem.Server.Entities
{
    public class StudentExtraIncomeCollection
    {
        [Key]
        public int Id { get; set; }
        public int MyProperty { get; set; }
    }
}
