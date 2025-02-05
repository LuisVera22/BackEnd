﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using servicio.Data;

#nullable disable

namespace servicio.Migrations
{
    [DbContext(typeof(MyAppContext))]
    [Migration("20250205204017_First migration")]
    partial class Firstmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProyectoDSWI.Models.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("ProyectoDSWI.Models.LegalGuardian", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CellphoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityDocument")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LegalGuardians");
                });

            modelBuilder.Entity("ProyectoDSWI.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.Property<string>("OperationCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentStatusId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("PaymentStatusId");

                    b.HasIndex("PaymentTypeId");

                    b.HasIndex("StudentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("ProyectoDSWI.Models.PaymentStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("PaymentStatus");
                });

            modelBuilder.Entity("ProyectoDSWI.Models.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("ProyectoDSWI.Models.Quota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.Property<int?>("PaymentStatusId")
                        .HasColumnType("int");

                    b.Property<int>("QuotaStatus")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId");

                    b.HasIndex("PaymentStatusId");

                    b.HasIndex("StudentId");

                    b.ToTable("Quotas");
                });

            modelBuilder.Entity("ProyectoDSWI.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ProyectoDSWI.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LegalGuardianId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LegalGuardianId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ProyectoDSWI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TokenRecovery")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProyectoDSWI.Models.UserDetails", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("UserId");

                    b.ToTable("UsersDetails");
                });

            modelBuilder.Entity("ProyectoDSWI.Models.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId1");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("ProyectoDSWI.Models.Payment", b =>
                {
                    b.HasOne("ProyectoDSWI.Models.Bank", "Bank")
                        .WithMany("Payments")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoDSWI.Models.PaymentStatus", "PaymentStatus")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoDSWI.Models.PaymentType", "PaymentType")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoDSWI.Models.Student", null)
                        .WithMany("Payments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");

                    b.Navigation("PaymentStatus");

                    b.Navigation("PaymentType");
                });

            modelBuilder.Entity("ProyectoDSWI.Models.Quota", b =>
                {
                    b.HasOne("ProyectoDSWI.Models.Payment", "Payment")
                        .WithMany("Quotas")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoDSWI.Models.PaymentStatus", null)
                        .WithMany("Quotas")
                        .HasForeignKey("PaymentStatusId");

                    b.HasOne("ProyectoDSWI.Models.Student", null)
                        .WithMany("Quotas")
                        .HasForeignKey("StudentId");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("ProyectoDSWI.Models.Student", b =>
                {
                    b.HasOne("ProyectoDSWI.Models.LegalGuardian", "LegalGuardian")
                        .WithMany()
                        .HasForeignKey("LegalGuardianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LegalGuardian");
                });

            modelBuilder.Entity("ProyectoDSWI.Models.UserDetails", b =>
                {
                    b.HasOne("ProyectoDSWI.Models.User", "User")
                        .WithOne("UserDetails")
                        .HasForeignKey("ProyectoDSWI.Models.UserDetails", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProyectoDSWI.Models.UserRole", b =>
                {
                    b.HasOne("ProyectoDSWI.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoDSWI.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProyectoDSWI.Models.Bank", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("ProyectoDSWI.Models.Payment", b =>
                {
                    b.Navigation("Quotas");
                });

            modelBuilder.Entity("ProyectoDSWI.Models.PaymentStatus", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("Quotas");
                });

            modelBuilder.Entity("ProyectoDSWI.Models.PaymentType", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("ProyectoDSWI.Models.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("ProyectoDSWI.Models.Student", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("Quotas");
                });

            modelBuilder.Entity("ProyectoDSWI.Models.User", b =>
                {
                    b.Navigation("UserDetails")
                        .IsRequired();

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
