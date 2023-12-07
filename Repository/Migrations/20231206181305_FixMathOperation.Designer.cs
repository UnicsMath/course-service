﻿// <auto-generated />

#nullable disable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Service;

namespace Repository.Migrations
{
    [DbContext(typeof(CourseDbContext))]
    [Migration("20231206181305_FixMathOperation")]
    partial class FixMathOperation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ChapterModelOperationModel", b =>
                {
                    b.Property<int>("ChapterModelChapterId")
                        .HasColumnType("integer");

                    b.Property<byte>("OperationsMathOperationId")
                        .HasColumnType("smallint");

                    b.HasKey("ChapterModelChapterId", "OperationsMathOperationId");

                    b.HasIndex("OperationsMathOperationId");

                    b.ToTable("ChapterModelOperationModel");
                });

            modelBuilder.Entity("Model.AuthorModel", b =>
                {
                    b.Property<byte>("AuthorId")
                        .HasColumnType("smallint");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Model.ChapterModel", b =>
                {
                    b.Property<int>("ChapterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ChapterId"));

                    b.Property<int>("ChapterNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte>("CourseId")
                        .HasColumnType("smallint");

                    b.Property<int>("MaximumConstantValue")
                        .HasColumnType("integer");

                    b.Property<int>("MaximumLength")
                        .HasColumnType("integer");

                    b.Property<int>("MinimumConstantValue")
                        .HasColumnType("integer");

                    b.Property<int>("MinimumLength")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ChapterId");

                    b.HasIndex("CourseId");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("Model.CourseModel", b =>
                {
                    b.Property<byte>("CourseId")
                        .HasColumnType("smallint");

                    b.Property<byte>("AuthorId")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<DateTime>("Updated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("CourseId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Model.OperationModel", b =>
                {
                    b.Property<byte>("MathOperationId")
                        .HasColumnType("smallint");

                    b.Property<string>("MathOperation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MathOperationId");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("ChapterModelOperationModel", b =>
                {
                    b.HasOne("Model.ChapterModel", null)
                        .WithMany()
                        .HasForeignKey("ChapterModelChapterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.OperationModel", null)
                        .WithMany()
                        .HasForeignKey("OperationsMathOperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.ChapterModel", b =>
                {
                    b.HasOne("Model.CourseModel", "Course")
                        .WithMany("Chapters")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Model.CourseModel", b =>
                {
                    b.HasOne("Model.AuthorModel", "Author")
                        .WithMany("Courses")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Model.AuthorModel", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Model.CourseModel", b =>
                {
                    b.Navigation("Chapters");
                });
#pragma warning restore 612, 618
        }
    }
}
