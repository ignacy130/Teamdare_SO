using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Teamdare.Database;

namespace Teamdare.Database.Migrations
{
    [DbContext(typeof(TeamdareContext))]
    [Migration("20170218113724_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Teamdare.Database.Entities.Adventure", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("FinishedImageUrl");

                    b.Property<string>("FinishedText");

                    b.Property<Guid>("GameMasterId");

                    b.Property<Guid>("HeroId");

                    b.Property<int>("Order");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("GameMasterId");

                    b.HasIndex("HeroId");

                    b.ToTable("Adventures");
                });

            modelBuilder.Entity("Teamdare.Database.Entities.Challenge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AdventureId");

                    b.Property<Guid>("HeroId");

                    b.Property<bool>("IsCompleted");

                    b.Property<bool>("IsStarted");

                    b.Property<int>("Order");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AdventureId");

                    b.HasIndex("HeroId");

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

                    b.Property<string>("AppId");

                    b.Property<string>("AppNick");

                    b.Property<Guid?>("ChallengeId");

                    b.Property<string>("ConversationId");

                    b.Property<Guid>("GameMasterId");

                    b.Property<int>("Level");

                    b.Property<string>("Nick");

                    b.Property<string>("ServiceUrl");

                    b.HasKey("Id");

                    b.HasIndex("ChallengeId");

                    b.HasIndex("GameMasterId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Teamdare.Database.Entities.Reward", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdventureId");

                    b.Property<Guid?>("AdventureId1");

                    b.Property<int>("PlayerId");

                    b.Property<Guid?>("PlayerId1");

                    b.Property<string>("Title");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("AdventureId1");

                    b.HasIndex("PlayerId1");

                    b.ToTable("Rewards");
                });

            modelBuilder.Entity("Teamdare.Database.Entities.Adventure", b =>
                {
                    b.HasOne("Teamdare.Database.Entities.GameMaster", "GameMaster")
                        .WithMany("Adventures")
                        .HasForeignKey("GameMasterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Teamdare.Database.Entities.Player", "Hero")
                        .WithMany("Adventures")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Teamdare.Database.Entities.Challenge", b =>
                {
                    b.HasOne("Teamdare.Database.Entities.Adventure", "Adventure")
                        .WithMany("Challenges")
                        .HasForeignKey("AdventureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Teamdare.Database.Entities.Player", "Hero")
                        .WithMany()
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Teamdare.Database.Entities.Player", b =>
                {
                    b.HasOne("Teamdare.Database.Entities.Challenge")
                        .WithMany("Participants")
                        .HasForeignKey("ChallengeId");

                    b.HasOne("Teamdare.Database.Entities.GameMaster", "GameMaster")
                        .WithMany("Players")
                        .HasForeignKey("GameMasterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Teamdare.Database.Entities.Reward", b =>
                {
                    b.HasOne("Teamdare.Database.Entities.Adventure", "Adventure")
                        .WithMany()
                        .HasForeignKey("AdventureId1");

                    b.HasOne("Teamdare.Database.Entities.Player", "Player")
                        .WithMany("Rewards")
                        .HasForeignKey("PlayerId1");
                });
        }
    }
}
