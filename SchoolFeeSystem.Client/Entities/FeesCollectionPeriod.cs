namespace SchoolFeeSystem.Client.Entities
{
    public class FeesCollectionPeriod
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
