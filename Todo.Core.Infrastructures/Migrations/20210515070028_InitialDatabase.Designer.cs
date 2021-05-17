﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Todo.Core.Infrastructures.Data;

namespace Todo.Core.Infrastructures.Migrations
{
    [DbContext(typeof(TodoProjectContext))]
    [Migration("20210515070028_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Todo.Core.Domain.Todo", b =>
                {
                    b.Property<int>("idTodo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isModif")
                        .HasColumnType("bit");

                    b.Property<DateTime>("todoDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("todoName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("todoStatus")
                        .HasColumnType("bit");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("idTodo");

                    b.ToTable("Todos");
                });
#pragma warning restore 612, 618
        }
    }
}
