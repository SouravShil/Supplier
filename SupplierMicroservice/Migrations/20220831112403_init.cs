using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplierMicroservice.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    PID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PQuantity = table.Column<int>(type: "int", nullable: false),
                    PDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.PID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SEmail = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SMobile = table.Column<long>(type: "bigint", nullable: false),
                    SAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Feedback = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SID);
                });

            migrationBuilder.CreateTable(
                name: "SupplierParts",
                columns: table => new
                {
                    SID = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    PID = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierParts", x => new { x.SID, x.PID });
                    table.ForeignKey(
                        name: "FK_SupplierParts_Parts_PID",
                        column: x => x.PID,
                        principalTable: "Parts",
                        principalColumn: "PID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierParts_Suppliers_SID",
                        column: x => x.SID,
                        principalTable: "Suppliers",
                        principalColumn: "SID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupplierParts_PID",
                table: "SupplierParts",
                column: "PID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupplierParts");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
