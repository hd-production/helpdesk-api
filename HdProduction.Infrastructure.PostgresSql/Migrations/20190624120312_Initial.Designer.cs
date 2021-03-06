﻿// <auto-generated />
using System;
using HdProduction.HelpDesk.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HdProduction.Infrastructure.PostgresSql.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20190624120312_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("HdProduction.HelpDesk.Domain.Entities.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<long?>("ReplyToCommentId");

                    b.Property<string>("Text")
                        .HasMaxLength(512);

                    b.Property<long>("TicketId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ReplyToCommentId");

                    b.HasIndex("TicketId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("HdProduction.HelpDesk.Domain.Entities.Project", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("DashboardId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("HdProduction.HelpDesk.Domain.Entities.Ticket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("AssigneeId");

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Details")
                        .IsRequired();

                    b.Property<string>("Issue")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("IssuerEmail");

                    b.Property<int?>("PriorityId");

                    b.Property<long?>("ProjectId");

                    b.Property<int?>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PriorityId");

                    b.HasIndex("StatusId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("HdProduction.HelpDesk.Domain.Entities.TicketAction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AttachmentKey");

                    b.Property<long?>("CommentId");

                    b.Property<long?>("NewAssigneeId");

                    b.Property<int?>("NewStatusId");

                    b.Property<long?>("OldAssigneeId");

                    b.Property<int?>("OldStatusId");

                    b.Property<long>("TicketId");

                    b.Property<DateTime>("Time");

                    b.Property<int>("Type");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.HasIndex("UserId");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("HdProduction.HelpDesk.Domain.Entities.TicketAttachment", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("TicketId");

                    b.Property<string>("Url")
                        .HasMaxLength(256);

                    b.HasKey("Key");

                    b.HasIndex("TicketId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("HdProduction.HelpDesk.Domain.Entities.TicketCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Default");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<long>("ProjectId");

                    b.HasKey("Id");

                    b.ToTable("TicketCategories");
                });

            modelBuilder.Entity("HdProduction.HelpDesk.Domain.Entities.TicketPriority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Default");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<long>("ProjectId");

                    b.HasKey("Id");

                    b.ToTable("TicketPriorities");
                });

            modelBuilder.Entity("HdProduction.HelpDesk.Domain.Entities.TicketStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Default");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<long>("ProjectId");

                    b.HasKey("Id");

                    b.ToTable("TicketStatuses");
                });

            modelBuilder.Entity("HdProduction.HelpDesk.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("PermissionsRaw");

                    b.Property<long>("ProjectId");

                    b.Property<string>("PwdHash")
                        .IsRequired();

                    b.Property<string>("PwdSalt")
                        .IsFixedLength(true)
                        .HasMaxLength(32);

                    b.Property<string>("RefreshToken")
                        .IsFixedLength(true)
                        .HasMaxLength(44);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HdProduction.HelpDesk.Domain.Entities.Comment", b =>
                {
                    b.HasOne("HdProduction.HelpDesk.Domain.Entities.Comment", "Parent")
                        .WithMany("Replies")
                        .HasForeignKey("ReplyToCommentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HdProduction.HelpDesk.Domain.Entities.Ticket", "Ticket")
                        .WithMany("Comments")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HdProduction.HelpDesk.Domain.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HdProduction.HelpDesk.Domain.Entities.Ticket", b =>
                {
                    b.HasOne("HdProduction.HelpDesk.Domain.Entities.User", "Assignee")
                        .WithMany("Tickets")
                        .HasForeignKey("AssigneeId");

                    b.HasOne("HdProduction.HelpDesk.Domain.Entities.TicketCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("HdProduction.HelpDesk.Domain.Entities.TicketPriority", "Priority")
                        .WithMany()
                        .HasForeignKey("PriorityId");

                    b.HasOne("HdProduction.HelpDesk.Domain.Entities.TicketStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("HdProduction.HelpDesk.Domain.Entities.TicketAction", b =>
                {
                    b.HasOne("HdProduction.HelpDesk.Domain.Entities.Ticket", "Ticket")
                        .WithMany("Actions")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HdProduction.HelpDesk.Domain.Entities.User", "User")
                        .WithMany("Actions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HdProduction.HelpDesk.Domain.Entities.TicketAttachment", b =>
                {
                    b.HasOne("HdProduction.HelpDesk.Domain.Entities.Ticket", "Ticket")
                        .WithMany("Attachments")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
