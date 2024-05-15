﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolFeeSystem.Server.Entities
{
    public class TransportFeesCollection
    {
        [Key]
        public int Id { get; set; }
        public int StudentClassId { get; set; }
        public int Amount { get; set; }
        public int Taken { get; set; }
        public int Remaining { get; set; }
        public int PeriodId { get; set; }
        [ForeignKey(nameof(PeriodId))]
        public FeesCollectionPeriod FeesCollectionPeriod { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [ForeignKey(nameof(StudentClassId))] 
        public ClassStudents ClassStudent { get; set; }
    }
}
