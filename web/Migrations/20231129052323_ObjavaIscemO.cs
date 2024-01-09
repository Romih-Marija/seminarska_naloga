using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web.Migrations
{
    /// <inheritdoc />
    public partial class ObjavaIscemO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvtorObjave",
                table: "ObjavaIscemOa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumObjave",
                table: "ObjavaIscemOa",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvtorObjave",
                table: "ObjavaIscemOa");

            migrationBuilder.DropColumn(
                name: "DatumObjave",
                table: "ObjavaIscemOa");
        }
    }
}
