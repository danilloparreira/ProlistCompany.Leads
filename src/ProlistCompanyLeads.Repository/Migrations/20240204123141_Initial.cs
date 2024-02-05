using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProlistCompany.Leads.Infra.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataDeInclusao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identificador = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    Suburbio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Leads",
                columns: new[] { "Id", "Categoria", "DataDeInclusao", "Descricao", "Email", "Identificador", "Nome", "Preco", "Sobrenome", "Status", "Suburbio", "Telefone" },
                values: new object[,]
                {
                    { new Guid("7219fa73-fe35-4bc6-ba8d-1e92cd356409"), "Tester", new DateTimeOffset(new DateTime(2024, 2, 4, 9, 31, 40, 103, DateTimeKind.Unspecified).AddTicks(6466), new TimeSpan(0, -3, 0, 0, 0)), "", "soaresale@bol.com.br", 835, "Yuri", 51356.457399999999, "Marçal", 0, "Av Pres. Vargas", "+5578915257395" },
                    { new Guid("7d968401-c2b0-4ee5-b9d7-1b1adbb23ebd"), "Tester", new DateTimeOffset(new DateTime(2024, 2, 4, 9, 31, 40, 103, DateTimeKind.Unspecified).AddTicks(6415), new TimeSpan(0, -3, 0, 0, 0)), null, "soaresale@bol.com.br", 312, "Macário", 512.0, "Costa", 0, "Av Pres. Vargas", "+5578915257395" },
                    { new Guid("cd34fe98-1961-471b-a0d7-08ff11d0b622"), "Tester", new DateTimeOffset(new DateTime(2024, 2, 4, 9, 31, 40, 103, DateTimeKind.Unspecified).AddTicks(6468), new TimeSpan(0, -3, 0, 0, 0)), "Em negociação", "soaresale@bol.com.br", 780, "Ada", 134211211888766.0, "Byron", 0, "Av Pres. Vargas", "+5578915257395" },
                    { new Guid("f5a79530-9126-4152-8840-e2fadb24d044"), "Tester", new DateTimeOffset(new DateTime(2024, 2, 4, 9, 31, 40, 103, DateTimeKind.Unspecified).AddTicks(6380), new TimeSpan(0, -3, 0, 0, 0)), "Cliente assíduo", "soaresale@bol.com.br", 123, "Alexandre", 79.140000000000001, "Soares", 0, "Av Pres. Vargas", "+5578915257395" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leads");
        }
    }
}
