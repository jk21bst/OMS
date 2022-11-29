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
    [Migration("20221123105901_DatabaseMigration2")]
    partial class DatabaseMigration2
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

                    b.Property<string>("custaddress");

                    b.Property<string>("custname");

                    b.Property<string>("gender");

                    b.Property<int>("mobileno");

                    b.HasKey("custid");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("omscase.Data.Models.Order", b =>
                {
                    b.Property<int>("orderid")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("customerid");

                    b.Property<string>("deliveryaddress");

                    b.Property<string>("orderstatus");

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

                    b.Property<string>("order_status");

                    b.Property<int>("price");

                    b.Property<int>("quantity");

                    b.HasKey("specific_id");

                    b.HasIndex("order_id");

                    b.ToTable("Orderitems");
                });

            modelBuilder.Entity("omscase.Data.Models.Product", b =>
                {
                    b.Property<int>("productid")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("image");

                    b.Property<int>("price");

                    b.Property<string>("product_description");

                    b.Property<string>("title");

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
                });
#pragma warning restore 612, 618
        }
    }
}