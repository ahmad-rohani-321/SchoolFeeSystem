using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolFeeSystem.Server.Entities
{
    public class FeesCollection
    {
        public int Id { get; set; }
        public int StudentClassId { get; set; }
        /// <summary>
        /// type true is Fees and type false if transport
        /// </summary>
        public bool FessType { get; set; }
        /// <summary>
        /// FeesAmount is general e.g Transport amount, Fees amount
        /// </summary>
        public int FeesAmount { get; set; }
        public int FeesDiscount { get; set; }
        public int FeesRemaining { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [ForeignKey(nameof(StudentClassId))]
        public ClassStudents ClassStudent { get; set; } = default!;
    }
}