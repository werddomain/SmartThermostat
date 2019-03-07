﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ST.Web.API.Data;

namespace ST.Web.API.Data.Migrations.Devices
{
    [DbContext(typeof(DeviceDataContext))]
    partial class DeviceDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ST.SmartDevices.Devices.Device", b =>
                {
                    b.Property<Guid>("DeviceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ArduinoId")
                        .IsRequired();

                    b.Property<string>("DeviceTypeId");

                    b.Property<Guid>("HubId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid>("PieceId");

                    b.Property<Guid?>("RelayId");

                    b.Property<string>("UserId");

                    b.HasKey("DeviceId");

                    b.HasIndex("DeviceTypeId");

                    b.HasIndex("HubId");

                    b.HasIndex("PieceId");

                    b.HasIndex("RelayId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("ST.SmartDevices.Devices.DeviceNickName", b =>
                {
                    b.Property<Guid>("DeviceNickNameId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("DeviceId");

                    b.Property<string>("NickName");

                    b.HasKey("DeviceNickNameId");

                    b.HasIndex("DeviceId");

                    b.ToTable("DeviceNickName");
                });

            modelBuilder.Entity("ST.SmartDevices.Devices.Google.DeviceTrait", b =>
                {
                    b.Property<string>("DeviceTraitId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid?>("DeviceId");

                    b.Property<string>("DeviceTypeId");

                    b.Property<string>("DisplayName");

                    b.HasKey("DeviceTraitId");

                    b.HasIndex("DeviceId");

                    b.HasIndex("DeviceTypeId");

                    b.ToTable("DeviceTraits");
                });

            modelBuilder.Entity("ST.SmartDevices.Devices.Google.DeviceType", b =>
                {
                    b.Property<string>("DeviceTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("DisplayName");

                    b.HasKey("DeviceTypeId");

                    b.ToTable("DeviceTypes");
                });

            modelBuilder.Entity("ST.SmartDevices.Devices.GoogleUser", b =>
                {
                    b.Property<Guid>("GoogleUserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ActivationDate");

                    b.Property<bool>("Active");

                    b.Property<string>("UserId");

                    b.HasKey("GoogleUserId");

                    b.ToTable("GoogleUsers");
                });

            modelBuilder.Entity("ST.SmartDevices.Devices.Home", b =>
                {
                    b.Property<Guid?>("HomeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("FullAddress")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasKey("HomeId");

                    b.ToTable("Homes");
                });

            modelBuilder.Entity("ST.SmartDevices.Devices.Hub", b =>
                {
                    b.Property<Guid>("HubId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Hardware");

                    b.Property<Guid>("HomeId");

                    b.Property<Guid>("PieceId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("HubId");

                    b.HasIndex("HomeId");

                    b.HasIndex("PieceId");

                    b.ToTable("Hubs");
                });

            modelBuilder.Entity("ST.SmartDevices.Devices.Piece", b =>
                {
                    b.Property<Guid?>("PieceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Floor");

                    b.Property<Guid>("HomeId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Type");

                    b.Property<string>("UserId");

                    b.HasKey("PieceId");

                    b.HasIndex("HomeId");

                    b.ToTable("Pieces");
                });

            modelBuilder.Entity("ST.SmartDevices.Devices.Relay", b =>
                {
                    b.Property<Guid>("RelayId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConnectionType");

                    b.Property<string>("HardWare");

                    b.Property<Guid>("HubId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("RelayId");

                    b.HasIndex("HubId");

                    b.ToTable("Relays");
                });

            modelBuilder.Entity("ST.SmartDevices.Devices.Device", b =>
                {
                    b.HasOne("ST.SmartDevices.Devices.Google.DeviceType", "DeviceType")
                        .WithMany()
                        .HasForeignKey("DeviceTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ST.SmartDevices.Devices.Hub", "Hub")
                        .WithMany("Devices")
                        .HasForeignKey("HubId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ST.SmartDevices.Devices.Piece", "Piece")
                        .WithMany()
                        .HasForeignKey("PieceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ST.SmartDevices.Devices.Relay", "Relay")
                        .WithMany()
                        .HasForeignKey("RelayId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ST.SmartDevices.Devices.DeviceNickName", b =>
                {
                    b.HasOne("ST.SmartDevices.Devices.Device")
                        .WithMany("NickNames")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ST.SmartDevices.Devices.Google.DeviceTrait", b =>
                {
                    b.HasOne("ST.SmartDevices.Devices.Device")
                        .WithMany("Traits")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ST.SmartDevices.Devices.Google.DeviceType")
                        .WithMany("RecommendedTraits")
                        .HasForeignKey("DeviceTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ST.SmartDevices.Devices.Hub", b =>
                {
                    b.HasOne("ST.SmartDevices.Devices.Home")
                        .WithMany("Hubs")
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ST.SmartDevices.Devices.Piece", "Piece")
                        .WithMany()
                        .HasForeignKey("PieceId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ST.SmartDevices.Devices.Piece", b =>
                {
                    b.HasOne("ST.SmartDevices.Devices.Home", "Home")
                        .WithMany("Pieces")
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ST.SmartDevices.Devices.Relay", b =>
                {
                    b.HasOne("ST.SmartDevices.Devices.Hub", "Hub")
                        .WithMany("Relays")
                        .HasForeignKey("HubId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
