namespace SchoolFeeSystem.Client.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string ClassTiming { get; set; }
        public bool IsActive { get; set; }
        public int FeeAmount { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
