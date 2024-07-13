﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvionesBackNet.Migrations
{
    /// <inheritdoc />
    public partial class addCodigoBoleto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Boletos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Boletos");
        }
    }
}
