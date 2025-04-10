using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Analista.Migrations
{
    /// <inheritdoc />
    public partial class addSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TiposRequisito",
                columns: new[] { "Id", "Nombre","Orden" ,"FechaCreacion","Activo"},
                values: new object[,]
                {
            { new Guid("00000000-0000-0000-0000-000000000001"), "Requisito No Funcional",1, new DateTime(2024, 4, 10, 14, 30, 0, 0, DateTimeKind.Utc), true },
            { new Guid("00000000-0000-0000-0000-000000000002"), "Requisito Funcional",2, new DateTime(2024, 4, 10, 14, 30, 0, 0, DateTimeKind.Utc), true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TiposRequisito",
                keyColumn: "Id",
                keyValues: new object[]
                {
            new Guid("00000000-0000-0000-0000-000000000001"),
            new Guid("00000000-0000-0000-0000-000000000002")
                });
        }

    }
}
