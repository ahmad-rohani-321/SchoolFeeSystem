﻿using Microsoft.EntityFrameworkCore;
using SchoolFeeSystem.Server.Entities;

namespace SchoolFeeSystem.Server
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasIndex(x => x.UnitqueKey)
                .IsUnique();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<ClassStudents> ClassStudents { get; set; }
        public DbSet<StudentIdCard> StudentIdCard { get; set; }
        public DbSet<FeesCollectionPeriod> FeesCollectionPeriod { get; set; }
        public DbSet<FeesCollection> FeesCollection { get; set; }
        public DbSet<ActivityFeesCollection> ActivityFeesCollection { get; set; }
        public DbSet<TransportFeesCollection> TransportFeesCollection { get; set; }
    }
}
