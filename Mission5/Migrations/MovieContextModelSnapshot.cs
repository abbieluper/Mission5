﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mission5.Models;

namespace Mission5.Migrations
{
    [DbContext(typeof(MovieContext))]
    partial class MovieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22");

            modelBuilder.Entity("Mission5.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Comedy"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Romantic Comedy"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Drama"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Family"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Action/Adventure"
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryName = "Horror/Suspense"
                        },
                        new
                        {
                            CategoryId = 7,
                            CategoryName = "Television"
                        });
                });

            modelBuilder.Entity("Mission5.Models.MovieModel", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Edited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lent")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT")
                        .HasMaxLength(25);

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MovieId");

                    b.HasIndex("CategoryId");

                    b.ToTable("responses");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            CategoryId = 2,
                            Director = "Anne Fletcher",
                            Edited = false,
                            Lent = "",
                            Notes = "This movie is very good and always makes me laugh!",
                            Rating = "PG-13",
                            Title = "The Proposal",
                            Year = "2009"
                        },
                        new
                        {
                            MovieId = 2,
                            CategoryId = 1,
                            Director = "Dennis Dugan",
                            Edited = false,
                            Lent = "",
                            Notes = "This movie is a classic feel good!",
                            Rating = "PG-13",
                            Title = "Just Go With It",
                            Year = "2011"
                        },
                        new
                        {
                            MovieId = 3,
                            CategoryId = 1,
                            Director = "Dennis Dugan",
                            Edited = false,
                            Lent = "Teddy Bear",
                            Notes = "",
                            Rating = "PG-13",
                            Title = "Grownups",
                            Year = "2010"
                        });
                });

            modelBuilder.Entity("Mission5.Models.MovieModel", b =>
                {
                    b.HasOne("Mission5.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}