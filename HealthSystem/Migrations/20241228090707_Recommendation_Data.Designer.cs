﻿// <auto-generated />
using System;
using HealthSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241228090707_Recommendation_Data")]
    partial class Recommendation_Data
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("HealthSystem.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date_of_birth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Height")
                        .HasColumnType("REAL");

                    b.Property<string>("Intervals_API")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("HealthSystem.Data.InformationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("InformationType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Waist Size"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Blood Pressure"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Weight"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Resting Heart Rate"
                        },
                        new
                        {
                            Id = 5,
                            Description = "CGM"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Insulin"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Triglyceride"
                        },
                        new
                        {
                            Id = 8,
                            Description = "HDL Cholesterol"
                        },
                        new
                        {
                            Id = 9,
                            Description = "LDL Cholesterol"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Metabolic Health"
                        });
                });

            modelBuilder.Entity("HealthSystem.Data.MedicalInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Entry_Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("InformationTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<float?>("SecondaryValue")
                        .HasColumnType("REAL");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("InformationTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("MedicalInformation");
                });

            modelBuilder.Entity("HealthSystem.Data.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PreviousMessageId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ReadDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReceiverId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SenderId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("HealthSystem.Data.Recommendation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Study_Link")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Recommendations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Metabolic syndrome is a clustering of at least three of the following five medical conditions: abdominal obesity, high blood pressure, high blood sugar, high serum triglycerides, and low serum high-density lipoprotein (HDL). Metabolic syndrome is associated with the risk of developing cardiovascular disease and type 2 diabetes. In the U.S., about 25% of the adult population has metabolic syndrome, a proportion increasing with age, particularly among racial and ethnic minorities.",
                            Study_Link = "https://en.wikipedia.org/wiki/Metabolic_syndrome"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Excess body weight and adiposity cause insulin resistance, inflammation, and numerous other alterations in metabolic and hormonal factors that promote atherosclerosis, tumorigenesis, neurodegeneration, and aging. Studies in both animals and humans have demonstrated a beneficial role of dietary restriction and leanness in promoting health and longevity.",
                            Study_Link = "https://pmc.ncbi.nlm.nih.gov/articles/PMC4032609/"
                        },
                        new
                        {
                            Id = 3,
                            Description = "There are two categories of normal blood pressure: Normal blood pressure is usually considered to be between 90/60 mmHg and 120/80 mmHg. For over-80s, because it's normal for arteries to get stiffer as we get older, the ideal blood pressure is under 150/90 mmHg (or 145/85 mmHg at home).",
                            Study_Link = "https://academic.oup.com/eurheartj/article/45/38/3912/7741010?login=false"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Overweight and obesity may increase your risk for many health problems—especially if you carry extra fat around your waist. Reaching and staying at a healthy weight can help prevent these problems, stop them from getting worse, or even make them go away.",
                            Study_Link = "https://www.niddk.nih.gov/health-information/weight-management/adult-overweight-obesity/health-risks?dkrd=/health-information/weight-management/health-risks-overweight"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Resting heart rate (RHR), a known cardiovascular risk factor, changes with age.",
                            Study_Link = "https://openheart.bmj.com/content/6/1/e000856"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Regularly having high blood sugar levels for long periods of time (over months or years) can result in permanent damage to parts of the body such as the eyes, nerves, kidneys and blood vessels.",
                            Study_Link = "https://www.nhsinform.scot/illnesses-and-conditions/blood-and-lymph/hyperglycaemia-high-blood-sugar/"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Hyperinsulinemia happens when you have a higher amount of insulin in your blood than what's considered normal due to insulin resistance. Your pancreas has to work harder to manage your blood sugar levels by releasing extra insulin.",
                            Study_Link = "https://my.clevelandclinic.org/health/diseases/24178-hyperinsulinemia"
                        },
                        new
                        {
                            Id = 8,
                            Description = "HDL is called \"good\" cholesterol because it helps prevent low-density lipoprotein (LDL) \"bad\" cholesterol and triglycerides from building up in the arteries. HDL picks up LDL in the blood and carries it to the liver. The liver breaks down LDL cholesterol, and it is passed from the body as waste.",
                            Study_Link = "https://www.mountsinai.org/health-library/tests/hdl-test"
                        },
                        new
                        {
                            Id = 9,
                            Description = "LDL is called \"bad\" cholesterol because it can build up and form fatty deposits (plaques) in the walls of your arteries.",
                            Study_Link = "https://www.mountsinai.org/health-library/tests/ldl-test"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Having a high level of triglycerides in your blood can increase your risk of heart disease. But the same lifestyle choices that promote overall health can help lower your triglycerides, too.",
                            Study_Link = "https://www.mayoclinic.org/diseases-conditions/high-blood-cholesterol/in-depth/triglycerides/art-20048186"
                        });
                });

            modelBuilder.Entity("HealthSystem.Data.TriggerParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DynamicsScore")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InformationTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecommendationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("InformationTypeId");

                    b.HasIndex("RecommendationId");

                    b.ToTable("TriggerParameters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DynamicsScore = 0,
                            InformationTypeId = 10,
                            RecommendationId = 1
                        },
                        new
                        {
                            Id = 2,
                            DynamicsScore = -1,
                            InformationTypeId = 10,
                            RecommendationId = 1
                        },
                        new
                        {
                            Id = 3,
                            DynamicsScore = 1,
                            InformationTypeId = 10,
                            RecommendationId = 1
                        },
                        new
                        {
                            Id = 4,
                            DynamicsScore = 2,
                            InformationTypeId = 10,
                            RecommendationId = 1
                        },
                        new
                        {
                            Id = 5,
                            DynamicsScore = 0,
                            InformationTypeId = 1,
                            RecommendationId = 2
                        },
                        new
                        {
                            Id = 6,
                            DynamicsScore = -1,
                            InformationTypeId = 1,
                            RecommendationId = 2
                        },
                        new
                        {
                            Id = 7,
                            DynamicsScore = 1,
                            InformationTypeId = 1,
                            RecommendationId = 2
                        },
                        new
                        {
                            Id = 8,
                            DynamicsScore = 2,
                            InformationTypeId = 1,
                            RecommendationId = 2
                        },
                        new
                        {
                            Id = 9,
                            DynamicsScore = 0,
                            InformationTypeId = 2,
                            RecommendationId = 3
                        },
                        new
                        {
                            Id = 10,
                            DynamicsScore = -1,
                            InformationTypeId = 2,
                            RecommendationId = 3
                        },
                        new
                        {
                            Id = 11,
                            DynamicsScore = 1,
                            InformationTypeId = 2,
                            RecommendationId = 3
                        },
                        new
                        {
                            Id = 12,
                            DynamicsScore = 2,
                            InformationTypeId = 2,
                            RecommendationId = 3
                        },
                        new
                        {
                            Id = 13,
                            DynamicsScore = 0,
                            InformationTypeId = 3,
                            RecommendationId = 4
                        },
                        new
                        {
                            Id = 14,
                            DynamicsScore = -1,
                            InformationTypeId = 3,
                            RecommendationId = 4
                        },
                        new
                        {
                            Id = 15,
                            DynamicsScore = 1,
                            InformationTypeId = 3,
                            RecommendationId = 4
                        },
                        new
                        {
                            Id = 16,
                            DynamicsScore = 2,
                            InformationTypeId = 3,
                            RecommendationId = 4
                        },
                        new
                        {
                            Id = 17,
                            DynamicsScore = 0,
                            InformationTypeId = 4,
                            RecommendationId = 5
                        },
                        new
                        {
                            Id = 18,
                            DynamicsScore = -1,
                            InformationTypeId = 4,
                            RecommendationId = 5
                        },
                        new
                        {
                            Id = 19,
                            DynamicsScore = 1,
                            InformationTypeId = 4,
                            RecommendationId = 5
                        },
                        new
                        {
                            Id = 20,
                            DynamicsScore = 2,
                            InformationTypeId = 4,
                            RecommendationId = 5
                        },
                        new
                        {
                            Id = 21,
                            DynamicsScore = 0,
                            InformationTypeId = 5,
                            RecommendationId = 6
                        },
                        new
                        {
                            Id = 22,
                            DynamicsScore = -1,
                            InformationTypeId = 5,
                            RecommendationId = 6
                        },
                        new
                        {
                            Id = 23,
                            DynamicsScore = 1,
                            InformationTypeId = 5,
                            RecommendationId = 6
                        },
                        new
                        {
                            Id = 24,
                            DynamicsScore = 2,
                            InformationTypeId = 5,
                            RecommendationId = 6
                        },
                        new
                        {
                            Id = 25,
                            DynamicsScore = 0,
                            InformationTypeId = 6,
                            RecommendationId = 7
                        },
                        new
                        {
                            Id = 26,
                            DynamicsScore = -1,
                            InformationTypeId = 6,
                            RecommendationId = 7
                        },
                        new
                        {
                            Id = 27,
                            DynamicsScore = 1,
                            InformationTypeId = 6,
                            RecommendationId = 7
                        },
                        new
                        {
                            Id = 28,
                            DynamicsScore = 2,
                            InformationTypeId = 6,
                            RecommendationId = 7
                        },
                        new
                        {
                            Id = 29,
                            DynamicsScore = 0,
                            InformationTypeId = 8,
                            RecommendationId = 8
                        },
                        new
                        {
                            Id = 30,
                            DynamicsScore = -1,
                            InformationTypeId = 8,
                            RecommendationId = 8
                        },
                        new
                        {
                            Id = 31,
                            DynamicsScore = 1,
                            InformationTypeId = 8,
                            RecommendationId = 8
                        },
                        new
                        {
                            Id = 32,
                            DynamicsScore = 2,
                            InformationTypeId = 8,
                            RecommendationId = 8
                        },
                        new
                        {
                            Id = 33,
                            DynamicsScore = 0,
                            InformationTypeId = 9,
                            RecommendationId = 9
                        },
                        new
                        {
                            Id = 34,
                            DynamicsScore = -1,
                            InformationTypeId = 9,
                            RecommendationId = 9
                        },
                        new
                        {
                            Id = 35,
                            DynamicsScore = 1,
                            InformationTypeId = 9,
                            RecommendationId = 9
                        },
                        new
                        {
                            Id = 36,
                            DynamicsScore = 2,
                            InformationTypeId = 9,
                            RecommendationId = 9
                        },
                        new
                        {
                            Id = 37,
                            DynamicsScore = 0,
                            InformationTypeId = 7,
                            RecommendationId = 10
                        },
                        new
                        {
                            Id = 38,
                            DynamicsScore = -1,
                            InformationTypeId = 7,
                            RecommendationId = 10
                        },
                        new
                        {
                            Id = 39,
                            DynamicsScore = 1,
                            InformationTypeId = 7,
                            RecommendationId = 10
                        },
                        new
                        {
                            Id = 40,
                            DynamicsScore = 2,
                            InformationTypeId = 7,
                            RecommendationId = 10
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HealthSystem.Data.MedicalInformation", b =>
                {
                    b.HasOne("HealthSystem.Data.InformationType", "InformationType")
                        .WithMany()
                        .HasForeignKey("InformationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthSystem.Data.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InformationType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HealthSystem.Data.Message", b =>
                {
                    b.HasOne("HealthSystem.Data.ApplicationUser", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthSystem.Data.ApplicationUser", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("HealthSystem.Data.TriggerParameter", b =>
                {
                    b.HasOne("HealthSystem.Data.InformationType", "Type")
                        .WithMany()
                        .HasForeignKey("InformationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthSystem.Data.Recommendation", "Recommendation")
                        .WithMany()
                        .HasForeignKey("RecommendationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recommendation");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HealthSystem.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HealthSystem.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthSystem.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HealthSystem.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
