﻿// <auto-generated />
using System;
using LMS.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LMS.Model.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LMS.Model.Model.Account", b =>
                {
                    b.Property<int>("TaiKhoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaiKhoanId"));

                    b.Property<string>("AnhDaiDien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SDT")
                        .HasColumnType("int");

                    b.Property<string>("TenDangNhap")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNguoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VaiTro")
                        .HasColumnType("int");

                    b.HasKey("TaiKhoanId");

                    b.ToTable("TaiKhoan", (string)null);
                });

            modelBuilder.Entity("LMS.Model.Model.ClassRoom", b =>
                {
                    b.Property<int>("ClassRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassRoomId"));

                    b.Property<string>("Describe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ClassRoomId");

                    b.ToTable("ClassRoom", (string)null);
                });

            modelBuilder.Entity("LMS.Model.Model.DetailsLesson", b =>
                {
                    b.Property<int>("DetailsLessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetailsLessonId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameAccount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DetailsLessonId");

                    b.HasIndex("LessonId");

                    b.ToTable("DetailsLesson");
                });

            modelBuilder.Entity("LMS.Model.Model.DetailsSubject", b =>
                {
                    b.Property<int>("DetailsSubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetailsSubjectId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DetailsSubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("DetailsSubject");
                });

            modelBuilder.Entity("LMS.Model.Model.Lesson", b =>
                {
                    b.Property<int>("LessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LessonId"));

                    b.Property<int>("ClassRoomId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Describe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TopicSubjectId")
                        .HasColumnType("int");

                    b.HasKey("LessonId");

                    b.HasIndex("ClassRoomId");

                    b.HasIndex("TopicSubjectId");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("LMS.Model.Model.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<string>("Describe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Document")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectId");

                    b.ToTable("Subject", (string)null);
                });

            modelBuilder.Entity("LMS.Model.Model.TeachingSubject", b =>
                {
                    b.Property<int>("TeachingSubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeachingSubjectId"));

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<int>("ClassRoomID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.HasKey("TeachingSubjectId");

                    b.HasIndex("AccountID");

                    b.HasIndex("ClassRoomID");

                    b.HasIndex("SubjectID");

                    b.ToTable("TeachingSubject", (string)null);
                });

            modelBuilder.Entity("LMS.Model.Model.TopicSubject", b =>
                {
                    b.Property<int>("TopicSubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TopicSubjectId"));

                    b.Property<string>("NameTopicSubject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("TopicSubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("TopicSubject");
                });

            modelBuilder.Entity("LMS.Model.Model.DetailsLesson", b =>
                {
                    b.HasOne("LMS.Model.Model.Lesson", "lesson")
                        .WithMany("DetailsLesson")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("lesson");
                });

            modelBuilder.Entity("LMS.Model.Model.DetailsSubject", b =>
                {
                    b.HasOne("LMS.Model.Model.Subject", "Subject")
                        .WithMany("DetailsSubject")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("LMS.Model.Model.Lesson", b =>
                {
                    b.HasOne("LMS.Model.Model.ClassRoom", "ClassRoom")
                        .WithMany()
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LMS.Model.Model.TopicSubject", "TopicSubject")
                        .WithMany("Lesson")
                        .HasForeignKey("TopicSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassRoom");

                    b.Navigation("TopicSubject");
                });

            modelBuilder.Entity("LMS.Model.Model.TeachingSubject", b =>
                {
                    b.HasOne("LMS.Model.Model.Account", "Account")
                        .WithMany("TeachingSubject")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LMS.Model.Model.ClassRoom", "ClassRoom")
                        .WithMany("TeachingSubject")
                        .HasForeignKey("ClassRoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LMS.Model.Model.Subject", "Subject")
                        .WithMany("TeachingSubject")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("ClassRoom");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("LMS.Model.Model.TopicSubject", b =>
                {
                    b.HasOne("LMS.Model.Model.Subject", "Subject")
                        .WithMany("TopicSubject")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("LMS.Model.Model.Account", b =>
                {
                    b.Navigation("TeachingSubject");
                });

            modelBuilder.Entity("LMS.Model.Model.ClassRoom", b =>
                {
                    b.Navigation("TeachingSubject");
                });

            modelBuilder.Entity("LMS.Model.Model.Lesson", b =>
                {
                    b.Navigation("DetailsLesson");
                });

            modelBuilder.Entity("LMS.Model.Model.Subject", b =>
                {
                    b.Navigation("DetailsSubject");

                    b.Navigation("TeachingSubject");

                    b.Navigation("TopicSubject");
                });

            modelBuilder.Entity("LMS.Model.Model.TopicSubject", b =>
                {
                    b.Navigation("Lesson");
                });
#pragma warning restore 612, 618
        }
    }
}
