using System.ComponentModel.DataAnnotations;

namespace SchoolFeeSystem.Server.Entities
{
    public class StudentExtraIncome
    {
        [Key]
        public int Id { get; set; }
        public string IncomeName { get; set; } = default!;
        public string Remarks { get; set; } = default!;

    }
}