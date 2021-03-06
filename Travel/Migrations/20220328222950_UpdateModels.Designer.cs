// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Travel.Models;

namespace Travel.Migrations
{
    [DbContext(typeof(TravelContext))]
    [Migration("20220328222950_UpdateModels")]
    partial class UpdateModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Travel.Models.Place", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("State")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("PlaceId");

                    b.ToTable("Places");

                    b.HasData(
                        new
                        {
                            PlaceId = 1,
                            City = "Seattle",
                            Country = "U.S.",
                            Review = "AOK",
                            State = "Washington"
                        },
                        new
                        {
                            PlaceId = 2,
                            City = "Portland",
                            Country = "U.S.",
                            Review = "Awesome",
                            State = "Oregon"
                        },
                        new
                        {
                            PlaceId = 3,
                            City = "San Francisco",
                            Country = "U.S.",
                            Review = "Shaky",
                            State = "California"
                        },
                        new
                        {
                            PlaceId = 4,
                            City = "Vancouver",
                            Country = "Canada",
                            Review = "All right",
                            State = "British Columbia"
                        },
                        new
                        {
                            PlaceId = 5,
                            City = "Bejing",
                            Country = "China",
                            Review = "Neato"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
