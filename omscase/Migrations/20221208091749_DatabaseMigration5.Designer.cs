﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using omscase;

namespace omscase.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221208091749_DatabaseMigration5")]
    partial class DatabaseMigration5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("omscase.Data.Models.Customer", b =>
                {
                    b.Property<int>("custid")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("custaddress")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("custname")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("gender")
                        .HasColumnType("varchar(50)");

                    b.Property<double>("mobileno");

                    b.Property<string>("password")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("username")
                        .HasColumnType("varchar(250)");

                    b.HasKey("custid");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("omscase.Data.Models.Order", b =>
                {
                    b.Property<int>("orderid")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("customerid");

                    b.Property<string>("deliveryaddress")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("orderstatus")
                        .HasColumnType("varchar(150)");

                    b.Property<int>("totalamount");

                    b.HasKey("orderid");

                    b.HasIndex("customerid");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("omscase.Data.Models.Orderitem", b =>
                {
                    b.Property<int>("specific_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("order_id");

                    b.Property<string>("order_status")
                        .HasColumnType("varchar(150)");

                    b.Property<int>("price");

                    b.Property<int>("prodid");

                    b.Property<int>("quantity");

                    b.HasKey("specific_id");

                    b.HasIndex("order_id");

                    b.HasIndex("prodid");

                    b.ToTable("Orderitems");
                });

            modelBuilder.Entity("omscase.Data.Models.Product", b =>
                {
                    b.Property<int>("productid")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("image")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("price");

                    b.Property<string>("product_description")
                        .HasColumnType("varchar(350)");

                    b.Property<string>("title")
                        .HasColumnType("varchar(250)");

                    b.HasKey("productid");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("omscase.Data.Models.Order", b =>
                {
                    b.HasOne("omscase.Data.Models.Customer", "custid")
                        .WithMany()
                        .HasForeignKey("customerid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("omscase.Data.Models.Orderitem", b =>
                {
                    b.HasOne("omscase.Data.Models.Order", "orderid")
                        .WithMany()
                        .HasForeignKey("order_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("omscase.Data.Models.Product", "productid")
                        .WithMany()
                        .HasForeignKey("prodid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
