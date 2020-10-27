﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PingDong.Newmoon.Venues.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    VenueName = table.Column<string>(maxLength: 200, nullable: false),
                    AddressNo = table.Column<string>(maxLength: 20, nullable: false),
                    AddressStreet = table.Column<string>(maxLength: 100, nullable: false),
                    AddressCity = table.Column<string>(maxLength: 40, nullable: false),
                    AddressState = table.Column<string>(maxLength: 40, nullable: false),
                    AddressCountry = table.Column<string>(maxLength: 40, nullable: false),
                    AddressZipCode = table.Column<string>(maxLength: 10, nullable: false),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Venues_Id_TenantId",
                schema: "dbo",
                table: "Venues",
                columns: new[] { "Id", "TenantId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Venues",
                schema: "dbo");
        }
    }
}