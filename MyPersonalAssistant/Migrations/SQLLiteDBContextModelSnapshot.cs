﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyPersonalAssistant.Code.Data;

namespace MyPersonalAssistant.Migrations
{
    [DbContext(typeof(SQLServerDBContext))]
    partial class SQLLiteDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyPersonalAssistant.Code.Data.Models.WorkItem", b =>
                {
                    b.Property<int?>("WorkItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeletionDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModificationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkItemId");

                    b.ToTable("WorkItems");

                    b.HasData(
                        new
                        {
                            WorkItemId = 1,
                            CreationDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletionDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Nothing much here",
                            ModificationDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "A Sample WorkItem"
                        },
                        new
                        {
                            WorkItemId = 2,
                            CreationDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletionDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Blah, blah blah",
                            ModificationDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Second WorkItem"
                        });
                });

            modelBuilder.Entity("MyPersonalAssistant.Code.Data.Models.WorkItemStatus", b =>
                {
                    b.Property<int>("WorkItemStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IsConsideredActive")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("IsDefault")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("StatusLabel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkItemStatusId");

                    b.ToTable("WorkItemStatus");

                    b.HasData(
                        new
                        {
                            WorkItemStatusId = 1,
                            IsConsideredActive = "Y",
                            IsDefault = "Y",
                            StatusLabel = "Active"
                        },
                        new
                        {
                            WorkItemStatusId = 2,
                            IsConsideredActive = "Y",
                            IsDefault = "N",
                            StatusLabel = "Awaiting Feedback"
                        },
                        new
                        {
                            WorkItemStatusId = 3,
                            IsConsideredActive = "N",
                            IsDefault = "Y",
                            StatusLabel = "Completed"
                        },
                        new
                        {
                            WorkItemStatusId = 4,
                            IsConsideredActive = "N",
                            IsDefault = "N",
                            StatusLabel = "Cancelled"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
