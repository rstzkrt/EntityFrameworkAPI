using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstEFcoreAPI.Migrations
{
    public partial class ADD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    IdCar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionYear = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.IdCar);
                });

            migrationBuilder.CreateTable(
                name: "mechanics",
                columns: table => new
                {
                    IdMechanic = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mechanics", x => x.IdMechanic);
                });

            migrationBuilder.CreateTable(
                name: "serviceTypeDicts",
                columns: table => new
                {
                    IdServiceType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceTypeDicts", x => x.IdServiceType);
                });

            migrationBuilder.CreateTable(
                name: "insceptions",
                columns: table => new
                {
                    IdInsception = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    InsceptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCar = table.Column<int>(type: "int", nullable: false),
                    IdMechanic = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insceptions", x => x.IdInsception);
                    table.ForeignKey(
                        name: "FK_insceptions_cars_IdCar",
                        column: x => x.IdCar,
                        principalTable: "cars",
                        principalColumn: "IdCar",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_insceptions_mechanics_IdMechanic",
                        column: x => x.IdMechanic,
                        principalTable: "mechanics",
                        principalColumn: "IdMechanic",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "serviceTypeDictInsceptions",
                columns: table => new
                {
                    IdServiceType = table.Column<int>(type: "int", nullable: false),
                    IdInsception = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceTypeDictInsceptions", x => new { x.IdInsception, x.IdServiceType });
                    table.ForeignKey(
                        name: "FK_serviceTypeDictInsceptions_insceptions_IdInsception",
                        column: x => x.IdInsception,
                        principalTable: "insceptions",
                        principalColumn: "IdInsception",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_serviceTypeDictInsceptions_serviceTypeDicts_IdServiceType",
                        column: x => x.IdServiceType,
                        principalTable: "serviceTypeDicts",
                        principalColumn: "IdServiceType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "cars",
                columns: new[] { "IdCar", "ProductionYear", "name" },
                values: new object[,]
                {
                    { 1, 11, "car" },
                    { 2, 12, "car2" }
                });

            migrationBuilder.InsertData(
                table: "mechanics",
                columns: new[] { "IdMechanic", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Name1", "LastName1" },
                    { 2, "Name2", "LastName2" }
                });

            migrationBuilder.InsertData(
                table: "serviceTypeDicts",
                columns: new[] { "IdServiceType", "Price", "ServiceType" },
                values: new object[,]
                {
                    { 1, 11f, "servicetype1" },
                    { 2, 22f, "servicetype2" }
                });

            migrationBuilder.InsertData(
                table: "insceptions",
                columns: new[] { "IdInsception", "Comment", "IdCar", "IdMechanic", "InsceptionDate" },
                values: new object[] { 1, "comment1", 1, 1, new DateTime(2021, 6, 22, 23, 17, 6, 718, DateTimeKind.Local).AddTicks(9786) });

            migrationBuilder.InsertData(
                table: "insceptions",
                columns: new[] { "IdInsception", "Comment", "IdCar", "IdMechanic", "InsceptionDate" },
                values: new object[] { 2, "comment2", 2, 2, new DateTime(2021, 6, 22, 23, 17, 6, 721, DateTimeKind.Local).AddTicks(1951) });

            migrationBuilder.InsertData(
                table: "serviceTypeDictInsceptions",
                columns: new[] { "IdInsception", "IdServiceType", "Comments" },
                values: new object[] { 1, 1, "Description1" });

            migrationBuilder.InsertData(
                table: "serviceTypeDictInsceptions",
                columns: new[] { "IdInsception", "IdServiceType", "Comments" },
                values: new object[] { 2, 2, "Description2" });

            migrationBuilder.CreateIndex(
                name: "IX_insceptions_IdCar",
                table: "insceptions",
                column: "IdCar");

            migrationBuilder.CreateIndex(
                name: "IX_insceptions_IdMechanic",
                table: "insceptions",
                column: "IdMechanic");

            migrationBuilder.CreateIndex(
                name: "IX_serviceTypeDictInsceptions_IdServiceType",
                table: "serviceTypeDictInsceptions",
                column: "IdServiceType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "serviceTypeDictInsceptions");

            migrationBuilder.DropTable(
                name: "insceptions");

            migrationBuilder.DropTable(
                name: "serviceTypeDicts");

            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "mechanics");
        }
    }
}
