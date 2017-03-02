using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MVC_Form_Processing.Models;

namespace MVCFormProcessing.Migrations
{
    [DbContext(typeof(PersonContext))]
    [Migration("20170302044724_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVC_Form_Processing.Models.Person", b =>
                {
                    b.Property<string>("firstName")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20);

                    b.Property<int>("age");

                    b.Property<DateTime>("birthDate");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("firstName");

                    b.ToTable("Persons");
                });
        }
    }
}
