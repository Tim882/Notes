﻿// <auto-generated />
using System;
using DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBase.Migrations
{
    [DbContext(typeof(NotesContext))]
    partial class NotesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DataBase.Models.Note", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("DataBase.Models.NoteTag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("NoteId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("NoteId");

                    b.ToTable("NoteTags");
                });

            modelBuilder.Entity("DataBase.Models.Reminder", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("NotifyDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Reminders");
                });

            modelBuilder.Entity("DataBase.Models.ReminderTag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("ReminderId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ReminderId");

                    b.ToTable("ReminderTags");
                });

            modelBuilder.Entity("DataBase.Models.NoteTag", b =>
                {
                    b.HasOne("DataBase.Models.Note", "Note")
                        .WithMany("NoteTags")
                        .HasForeignKey("NoteId");

                    b.Navigation("Note");
                });

            modelBuilder.Entity("DataBase.Models.ReminderTag", b =>
                {
                    b.HasOne("DataBase.Models.Reminder", "Reminder")
                        .WithMany("ReminderTags")
                        .HasForeignKey("ReminderId");

                    b.Navigation("Reminder");
                });

            modelBuilder.Entity("DataBase.Models.Note", b =>
                {
                    b.Navigation("NoteTags");
                });

            modelBuilder.Entity("DataBase.Models.Reminder", b =>
                {
                    b.Navigation("ReminderTags");
                });
#pragma warning restore 612, 618
        }
    }
}
