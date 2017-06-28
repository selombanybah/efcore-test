using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using pocoinheritance.Data;

namespace pocoinheritance.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20170628073502_InitialModel")]
    partial class InitialModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("pocoinheritance.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int?>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("pocoinheritance.Models.Student", b =>
                {
                    b.HasBaseType("pocoinheritance.Models.Person");

                    b.Property<int>("StudentAge");

                    b.ToTable("Student");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("pocoinheritance.Models.Worker", b =>
                {
                    b.HasBaseType("pocoinheritance.Models.Person");

                    b.Property<decimal>("WorkerSalary");

                    b.ToTable("Worker");

                    b.HasDiscriminator().HasValue("Worker");
                });

            modelBuilder.Entity("pocoinheritance.Models.Person", b =>
                {
                    b.HasOne("pocoinheritance.Models.Student")
                        .WithMany("Friends")
                        .HasForeignKey("StudentId");
                });
        }
    }
}
