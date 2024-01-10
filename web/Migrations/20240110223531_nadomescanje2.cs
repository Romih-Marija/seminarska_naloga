using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web.Migrations
{
    /// <inheritdoc />
    public partial class nadomescanje2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IscemNadomescanje",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Priimek = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lokacija = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OdDatuma = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoDatuma = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvtorObjave = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IscemNadomescanje", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NudimNadomescanje",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Priimek = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lokacija = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OdDatuma = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoDatuma = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvtorObjave = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NudimNadomescanje", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IscemNadomescanje");

            migrationBuilder.DropTable(
                name: "NudimNadomescanje");
        }
    }
}
