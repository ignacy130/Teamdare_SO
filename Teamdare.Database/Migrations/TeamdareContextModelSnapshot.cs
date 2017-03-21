﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Teamdare.Database.Migrations
{
    [DbContext(typeof(TeamdareContext))]
    partial class TeamdareContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("Teamdare.Database.Entities.Adventure", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("FinishedImageUrl");

                    b.Property<string>("FinishedText");

                    b.Property<Guid?>("GameMasterId");

                    b.Property<int>("Order");

                    b.Property<Guid>("PlayerId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("GameMasterId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Adventures");
                });

            modelBuilder.Entity("Teamdare.Database.Entities.Challenge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AdventureId");

                    b.Property<int>("Order");

                    b.Property<Guid>("PlayerId");

                    b.Property<DateTime?>("StartDate");

                    b.Property<int>("Status");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AdventureId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Challenges");
                });

            modelBuilder.Entity("Teamdare.Database.Entities.GameMaster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("GameMasters");
                });

            modelBuilder.Entity("Teamdare.Database.Entities.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConversationId");

                    b.Property<Guid>("GameMasterId");

                    b.Property<int>("Level");

                    b.Property<string>("Nick");

                    b.Property<string>("ServiceUrl");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GameMasterId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Teamdare.Database.Entities.Reward", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AdventureId");

                    b.Property<Guid>("PlayerId");

                    b.Property<string>("Title");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("AdventureId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Rewards");
                });

            modelBuilder.Entity("Teamdare.Database.Entities.Adventure", b =>
                {
                    b.HasOne("Teamdare.Database.Entities.GameMaster")
                        .WithMany("Adventures")
                        .HasForeignKey("GameMasterId");

                    b.HasOne("Teamdare.Database.Entities.Player", "Player")
                        .WithMany("Adventures")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Teamdare.Database.Entities.Challenge", b =>
                {
                    b.HasOne("Teamdare.Database.Entities.Adventure", "Adventure")
                        .WithMany("Challenges")
                        .HasForeignKey("AdventureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Teamdare.Database.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Teamdare.Database.Entities.Player", b =>
                {
                    b.HasOne("Teamdare.Database.Entities.GameMaster", "GameMaster")
                        .WithMany("Players")
                        .HasForeignKey("GameMasterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Teamdare.Database.Entities.Reward", b =>
                {
                    b.HasOne("Teamdare.Database.Entities.Adventure", "Adventure")
                        .WithMany()
                        .HasForeignKey("AdventureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Teamdare.Database.Entities.Player", "Player")
                        .WithMany("Rewards")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
