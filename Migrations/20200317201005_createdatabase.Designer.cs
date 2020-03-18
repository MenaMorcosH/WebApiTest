﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiTest.Models;

namespace WebApiTest.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20200317201005_createdatabase")]
    partial class createdatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApiTest.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("ProductName")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("productPrice")
                        .HasColumnType("int")
                        .HasDefaultValue(10);

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "product 1 ",
                            Price = 15
                        },
                        new
                        {
                            Id = 2,
                            Name = "product 2 ",
                            Price = 20
                        });
                });
#pragma warning restore 612, 618
        }
    }
}