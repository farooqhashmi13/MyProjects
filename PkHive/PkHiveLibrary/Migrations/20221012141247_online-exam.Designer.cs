﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PkHiveLibrary.DataAccess;

#nullable disable

namespace PkHiveLibrary.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221012141247_online-exam")]
    partial class onlineexam
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PkHiveLibrary.Models.ContactUs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("SubmitDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ContactUs");
                });

            modelBuilder.Entity("PkHiveLibrary.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ApplyLink")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Experience")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("LastDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PayScale")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("PostedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Qualification")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("SubTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<int>("Vacancies")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubTypeId");

                    b.HasIndex("TypeId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("PkHiveLibrary.Models.JobType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("JobTypes");
                });

            modelBuilder.Entity("PkHiveLibrary.Models.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsAnswer")
                        .HasColumnType("bit");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("PkHiveLibrary.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("PkHiveLibrary.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("PkHiveLibrary.Models.SubType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("JobTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("JobTypeId");

                    b.ToTable("SubTypes");
                });

            modelBuilder.Entity("PkHiveLibrary.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GainedMarkes")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TimeTaken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalMarks")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("PkHiveLibrary.Models.TestQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsRight")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("SelectedOptionId")
                        .HasColumnType("int");

                    b.Property<int?>("TestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SelectedOptionId");

                    b.HasIndex("TestId");

                    b.ToTable("TestQuestions");
                });

            modelBuilder.Entity("PkHiveLibrary.Models.Job", b =>
                {
                    b.HasOne("PkHiveLibrary.Models.SubType", "SubType")
                        .WithMany("Jobs")
                        .HasForeignKey("SubTypeId");

                    b.HasOne("PkHiveLibrary.Models.JobType", "Type")
                        .WithMany("Jobs")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubType");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("PkHiveLibrary.Models.Option", b =>
                {
                    b.HasOne("PkHiveLibrary.Models.Question", null)
                        .WithMany("Options")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("PkHiveLibrary.Models.Question", b =>
                {
                    b.HasOne("PkHiveLibrary.Models.Subject", null)
                        .WithMany("Questions")
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("PkHiveLibrary.Models.SubType", b =>
                {
                    b.HasOne("PkHiveLibrary.Models.JobType", null)
                        .WithMany("SubTypes")
                        .HasForeignKey("JobTypeId");
                });

            modelBuilder.Entity("PkHiveLibrary.Models.Test", b =>
                {
                    b.HasOne("PkHiveLibrary.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("PkHiveLibrary.Models.TestQuestion", b =>
                {
                    b.HasOne("PkHiveLibrary.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PkHiveLibrary.Models.Option", "SelectedOption")
                        .WithMany()
                        .HasForeignKey("SelectedOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PkHiveLibrary.Models.Test", null)
                        .WithMany("TestQuestions")
                        .HasForeignKey("TestId");

                    b.Navigation("Question");

                    b.Navigation("SelectedOption");
                });

            modelBuilder.Entity("PkHiveLibrary.Models.JobType", b =>
                {
                    b.Navigation("Jobs");

                    b.Navigation("SubTypes");
                });

            modelBuilder.Entity("PkHiveLibrary.Models.Question", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("PkHiveLibrary.Models.Subject", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("PkHiveLibrary.Models.SubType", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("PkHiveLibrary.Models.Test", b =>
                {
                    b.Navigation("TestQuestions");
                });
#pragma warning restore 612, 618
        }
    }
}