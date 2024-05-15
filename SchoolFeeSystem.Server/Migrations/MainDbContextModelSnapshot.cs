﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolFeeSystem.Server;

#nullable disable

namespace SchoolFeeSystem.Server.Migrations
{
    [DbContext(typeof(MainDbContext))]
    partial class MainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SchoolFeeSystem.Server.Entities.ActivityFeesCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentClassId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentClassId");

                    b.ToTable("ActivityFeesCollection");
                });

            modelBuilder.Entity("SchoolFeeSystem.Server.Entities.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("SchoolFeeSystem.Server.Entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("ClassTiming")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FeeAmount")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("SchoolFeeSystem.Server.Entities.ClassStudents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EntranceDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IdDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("StudentFee")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId");

                    b.ToTable("ClassStudents");
                });

            modelBuilder.Entity("SchoolFeeSystem.Server.Entities.FeesCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PeriodId")
                        .HasColumnType("int");

                    b.Property<int>("Remaining")
                        .HasColumnType("int");

                    b.Property<int>("StudentClassId")
                        .HasColumnType("int");

                    b.Property<int>("Taken")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PeriodId");

                    b.HasIndex("StudentClassId");

                    b.ToTable("FeesCollection");
                });

            modelBuilder.Entity("SchoolFeeSystem.Server.Entities.FeesCollectionPeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FeesCollectionPeriod");
                });

            modelBuilder.Entity("SchoolFeeSystem.Server.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BloodGroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("DOB")
                        .HasColumnType("date");

                    b.Property<string>("FatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("GrandFatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ParentPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegNo")
                        .HasColumnType("int");

                    b.Property<string>("TazkiraNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransportationFees")
                        .HasColumnType("int");

                    b.Property<string>("UnitqueKey")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UnitqueKey")
                        .IsUnique()
                        .HasFilter("[UnitqueKey] IS NOT NULL");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("SchoolFeeSystem.Server.Entities.StudentIdCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("ExpireDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("IssueDate")
                        .HasColumnType("date");

                    b.Property<int>("SerialNo")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentIdCard");
                });

            modelBuilder.Entity("SchoolFeeSystem.Server.Entities.TransportFeesCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PeriodId")
                        .HasColumnType("int");

                    b.Property<int>("Remaining")
                        .HasColumnType("int");

                    b.Property<int>("StudentClassId")
                        .HasColumnType("int");

                    b.Property<int>("Taken")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PeriodId");

                    b.HasIndex("StudentClassId");

                    b.ToTable("TransportFeesCollection");
                });

            modelBuilder.Entity("SchoolFeeSystem.Server.Entities.ActivityFeesCollection", b =>
                {
                    b.HasOne("SchoolFeeSystem.Server.Entities.ClassStudents", "ClassStudent")
                        .WithMany()
                        .HasForeignKey("StudentClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassStudent");
                });

            modelBuilder.Entity("SchoolFeeSystem.Server.Entities.Class", b =>
                {
                    b.HasOne("SchoolFeeSystem.Server.Entities.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("SchoolFeeSystem.Server.Entities.ClassStudents", b =>
                {
                    b.HasOne("SchoolFeeSystem.Server.Entities.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolFeeSystem.Server.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolFeeSystem.Server.Entities.FeesCollection", b =>
                {
                    b.HasOne("SchoolFeeSystem.Server.Entities.FeesCollectionPeriod", "FeesCollectionPeriod")
                        .WithMany()
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolFeeSystem.Server.Entities.ClassStudents", "ClassStudent")
                        .WithMany()
                        .HasForeignKey("StudentClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassStudent");

                    b.Navigation("FeesCollectionPeriod");
                });

            modelBuilder.Entity("SchoolFeeSystem.Server.Entities.StudentIdCard", b =>
                {
                    b.HasOne("SchoolFeeSystem.Server.Entities.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolFeeSystem.Server.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolFeeSystem.Server.Entities.TransportFeesCollection", b =>
                {
                    b.HasOne("SchoolFeeSystem.Server.Entities.FeesCollectionPeriod", "FeesCollectionPeriod")
                        .WithMany()
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolFeeSystem.Server.Entities.ClassStudents", "ClassStudent")
                        .WithMany()
                        .HasForeignKey("StudentClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassStudent");

                    b.Navigation("FeesCollectionPeriod");
                });
#pragma warning restore 612, 618
        }
    }
}
