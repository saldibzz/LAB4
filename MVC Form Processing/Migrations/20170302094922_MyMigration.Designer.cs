using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MVC_Form_Processing.Models;

namespace MVCFormProcessing.Migrations
{
    [DbContext(typeof(PersonContext))]
    [Migration("20170302094922_MyMigration")]
    partial class MyMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVC_Form_Processing.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("age");

                    b.Property<DateTime>("birthDate");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("PersonId");

                    b.ToTable("PersonDetails");
                });
        }
    }
}
