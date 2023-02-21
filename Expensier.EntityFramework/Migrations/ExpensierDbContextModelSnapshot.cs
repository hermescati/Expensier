﻿// <auto-generated />
using System;
using Expensier.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Expensier.EntityFramework.Migrations
{
    [DbContext(typeof(ExpensierDbContext))]
    partial class ExpensierDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Expensier.Domain.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Account_Holder_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Account_Holder_Id");

                    b.ToTable("Accounts", (string)null);
                });

            modelBuilder.Entity("Expensier.Domain.Models.CryptoAsset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Account_Id")
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<double>("Purchase_Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Account_Id");

                    b.ToTable("CryptoAssets", (string)null);
                });

            modelBuilder.Entity("Expensier.Domain.Models.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Account_Id")
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("Company_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Due_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subscription_Plan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subscription_Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Account_Id");

                    b.ToTable("Subscriptions", (string)null);
                });

            modelBuilder.Entity("Expensier.Domain.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Account_Id")
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<bool>("Is_Credit")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Process_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Transaction_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Transaction_Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Account_Id");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("Expensier.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date_Joined")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password_Hash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profile_Picture")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("/Styles/Images/default_profile_picture.png");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Expensier.Domain.Models.Account", b =>
                {
                    b.HasOne("Expensier.Domain.Models.User", "Account_Holder_")
                        .WithMany()
                        .HasForeignKey("Account_Holder_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account_Holder_");
                });

            modelBuilder.Entity("Expensier.Domain.Models.CryptoAsset", b =>
                {
                    b.HasOne("Expensier.Domain.Models.Account", "Account_")
                        .WithMany("CryptoAssetList")
                        .HasForeignKey("Account_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Expensier.Domain.Models.CryptoAsset.Crypto#Expensier.Domain.Models.Crypto", "Crypto", b1 =>
                        {
                            b1.Property<int>("CryptoAssetId")
                                .HasColumnType("int");

                            b1.Property<double?>("ChangesPercentage")
                                .HasColumnType("float");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<double?>("Price")
                                .HasColumnType("float");

                            b1.Property<string>("Symbol")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CryptoAssetId");

                            b1.ToTable("CryptoAssets", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("CryptoAssetId");
                        });

                    b.Navigation("Account_");

                    b.Navigation("Crypto")
                        .IsRequired();
                });

            modelBuilder.Entity("Expensier.Domain.Models.Subscription", b =>
                {
                    b.HasOne("Expensier.Domain.Models.Account", "Account_")
                        .WithMany("SubscriptionList")
                        .HasForeignKey("Account_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account_");
                });

            modelBuilder.Entity("Expensier.Domain.Models.Transaction", b =>
                {
                    b.HasOne("Expensier.Domain.Models.Account", "Account_")
                        .WithMany("TransactionList")
                        .HasForeignKey("Account_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account_");
                });

            modelBuilder.Entity("Expensier.Domain.Models.Account", b =>
                {
                    b.Navigation("CryptoAssetList");

                    b.Navigation("SubscriptionList");

                    b.Navigation("TransactionList");
                });
#pragma warning restore 612, 618
        }
    }
}
