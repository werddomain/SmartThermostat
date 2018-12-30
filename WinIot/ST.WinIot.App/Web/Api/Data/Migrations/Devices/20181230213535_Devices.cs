using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ST.Web.API.Data.Migrations.Devices
{
    public partial class Devices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceTypes",
                columns: table => new
                {
                    DeviceTypeId = table.Column<string>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTypes", x => x.DeviceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "GoogleUsers",
                columns: table => new
                {
                    GoogleUserId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    ActivationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoogleUsers", x => x.GoogleUserId);
                });

            migrationBuilder.CreateTable(
                name: "Homes",
                columns: table => new
                {
                    HomeId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    FullAddress = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homes", x => x.HomeId);
                });

            migrationBuilder.CreateTable(
                name: "Pieces",
                columns: table => new
                {
                    PieceId = table.Column<Guid>(nullable: false),
                    HomeId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Floor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pieces", x => x.PieceId);
                    table.ForeignKey(
                        name: "FK_Pieces_Homes_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Homes",
                        principalColumn: "HomeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hubs",
                columns: table => new
                {
                    HubId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    HomeId = table.Column<Guid>(nullable: false),
                    Hardware = table.Column<string>(nullable: true),
                    PieceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hubs", x => x.HubId);
                    table.ForeignKey(
                        name: "FK_Hubs_Homes_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Homes",
                        principalColumn: "HomeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hubs_Pieces_PieceId",
                        column: x => x.PieceId,
                        principalTable: "Pieces",
                        principalColumn: "PieceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Relays",
                columns: table => new
                {
                    RelayId = table.Column<Guid>(nullable: false),
                    HubId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    HardWare = table.Column<string>(nullable: true),
                    ConnectionType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relays", x => x.RelayId);
                    table.ForeignKey(
                        name: "FK_Relays_Hubs_HubId",
                        column: x => x.HubId,
                        principalTable: "Hubs",
                        principalColumn: "HubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    DeviceId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    RelayId = table.Column<Guid>(nullable: true),
                    HubId = table.Column<Guid>(nullable: false),
                    PieceId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ArduinoId = table.Column<int>(nullable: false),
                    DeviceTypeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.DeviceId);
                    table.ForeignKey(
                        name: "FK_Devices_DeviceTypes_DeviceTypeId",
                        column: x => x.DeviceTypeId,
                        principalTable: "DeviceTypes",
                        principalColumn: "DeviceTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Devices_Hubs_HubId",
                        column: x => x.HubId,
                        principalTable: "Hubs",
                        principalColumn: "HubId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Devices_Pieces_PieceId",
                        column: x => x.PieceId,
                        principalTable: "Pieces",
                        principalColumn: "PieceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Devices_Relays_RelayId",
                        column: x => x.RelayId,
                        principalTable: "Relays",
                        principalColumn: "RelayId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeviceNickName",
                columns: table => new
                {
                    DeviceNickNameId = table.Column<Guid>(nullable: false),
                    DeviceId = table.Column<Guid>(nullable: false),
                    NickName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceNickName", x => x.DeviceNickNameId);
                    table.ForeignKey(
                        name: "FK_DeviceNickName_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "DeviceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeviceTraits",
                columns: table => new
                {
                    DeviceTraitId = table.Column<string>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DeviceId = table.Column<Guid>(nullable: true),
                    DeviceTypeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTraits", x => x.DeviceTraitId);
                    table.ForeignKey(
                        name: "FK_DeviceTraits_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "DeviceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeviceTraits_DeviceTypes_DeviceTypeId",
                        column: x => x.DeviceTypeId,
                        principalTable: "DeviceTypes",
                        principalColumn: "DeviceTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceNickName_DeviceId",
                table: "DeviceNickName",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_DeviceTypeId",
                table: "Devices",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_HubId",
                table: "Devices",
                column: "HubId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_PieceId",
                table: "Devices",
                column: "PieceId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_RelayId",
                table: "Devices",
                column: "RelayId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTraits_DeviceId",
                table: "DeviceTraits",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTraits_DeviceTypeId",
                table: "DeviceTraits",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Hubs_HomeId",
                table: "Hubs",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Hubs_PieceId",
                table: "Hubs",
                column: "PieceId");

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_HomeId",
                table: "Pieces",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Relays_HubId",
                table: "Relays",
                column: "HubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceNickName");

            migrationBuilder.DropTable(
                name: "DeviceTraits");

            migrationBuilder.DropTable(
                name: "GoogleUsers");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "DeviceTypes");

            migrationBuilder.DropTable(
                name: "Relays");

            migrationBuilder.DropTable(
                name: "Hubs");

            migrationBuilder.DropTable(
                name: "Pieces");

            migrationBuilder.DropTable(
                name: "Homes");
        }
    }
}
