using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Analista.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CasosDeUso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Orden = table.Column<int>(type: "integer", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasosDeUso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Condiciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condiciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CriteriosDeAceptacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriteriosDeAceptacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposRequisito",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Orden = table.Column<int>(type: "integer", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposRequisito", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActoresPorCasoDeUso",
                columns: table => new
                {
                    ActorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CasoDeUsoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActoresPorCasoDeUso", x => new { x.ActorId, x.CasoDeUsoId });
                    table.ForeignKey(
                        name: "FK_ActoresPorCasoDeUso_Actores_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActoresPorCasoDeUso_CasosDeUso_CasoDeUsoId",
                        column: x => x.CasoDeUsoId,
                        principalTable: "CasosDeUso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CondicionesPorCasosDeUso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCondicion = table.Column<Guid>(type: "uuid", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    IdCasoDeUso = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondicionesPorCasosDeUso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CondicionesPorCasosDeUso_CasosDeUso_IdCasoDeUso",
                        column: x => x.IdCasoDeUso,
                        principalTable: "CasosDeUso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CondicionesPorCasosDeUso_Condiciones_IdCondicion",
                        column: x => x.IdCondicion,
                        principalTable: "Condiciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CriteriosDeAceptacionPorCasoDeUso",
                columns: table => new
                {
                    CasoDeUsoId = table.Column<Guid>(type: "uuid", nullable: false),
                    CriterioDeAceptacionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriteriosDeAceptacionPorCasoDeUso", x => new { x.CasoDeUsoId, x.CriterioDeAceptacionId });
                    table.ForeignKey(
                        name: "FK_CriteriosDeAceptacionPorCasoDeUso_CasosDeUso_CasoDeUsoId",
                        column: x => x.CasoDeUsoId,
                        principalTable: "CasosDeUso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CriteriosDeAceptacionPorCasoDeUso_CriteriosDeAceptacion_Cri~",
                        column: x => x.CriterioDeAceptacionId,
                        principalTable: "CriteriosDeAceptacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiciosPorCasoDeUso",
                columns: table => new
                {
                    CasoDeUsoId = table.Column<Guid>(type: "uuid", nullable: false),
                    ServicioId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosPorCasoDeUso", x => new { x.CasoDeUsoId, x.ServicioId });
                    table.ForeignKey(
                        name: "FK_ServiciosPorCasoDeUso_CasosDeUso_CasoDeUsoId",
                        column: x => x.CasoDeUsoId,
                        principalTable: "CasosDeUso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiciosPorCasoDeUso_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubTiposRequisito",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Orden = table.Column<int>(type: "integer", nullable: false),
                    IdTipoRequisito = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTiposRequisito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubTiposRequisito_TiposRequisito_IdTipoRequisito",
                        column: x => x.IdTipoRequisito,
                        principalTable: "TiposRequisito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requisitos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Orden = table.Column<int>(type: "integer", nullable: false),
                    IdSubTipoRequisito = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisitos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requisitos_SubTiposRequisito_IdSubTipoRequisito",
                        column: x => x.IdSubTipoRequisito,
                        principalTable: "SubTiposRequisito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitosPorCasoDeUso",
                columns: table => new
                {
                    CasoDeUsoId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequisitoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitosPorCasoDeUso", x => new { x.CasoDeUsoId, x.RequisitoId });
                    table.ForeignKey(
                        name: "FK_RequisitosPorCasoDeUso_CasosDeUso_CasoDeUsoId",
                        column: x => x.CasoDeUsoId,
                        principalTable: "CasosDeUso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequisitosPorCasoDeUso_Requisitos_RequisitoId",
                        column: x => x.RequisitoId,
                        principalTable: "Requisitos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TiposRequisito",
                columns: new[] { "Id", "Activo", "FechaCreacion", "FechaModificacion", "Nombre", "Orden" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), true, new DateTime(2024, 4, 10, 14, 30, 0, 0, DateTimeKind.Utc), null, "Requisito No Funcional", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), true, new DateTime(2024, 4, 10, 14, 30, 0, 0, DateTimeKind.Utc), null, "Requisito Funcional", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActoresPorCasoDeUso_CasoDeUsoId",
                table: "ActoresPorCasoDeUso",
                column: "CasoDeUsoId");

            migrationBuilder.CreateIndex(
                name: "IX_CondicionesPorCasosDeUso_IdCasoDeUso",
                table: "CondicionesPorCasosDeUso",
                column: "IdCasoDeUso");

            migrationBuilder.CreateIndex(
                name: "IX_CondicionesPorCasosDeUso_IdCondicion",
                table: "CondicionesPorCasosDeUso",
                column: "IdCondicion");

            migrationBuilder.CreateIndex(
                name: "IX_CriteriosDeAceptacionPorCasoDeUso_CriterioDeAceptacionId",
                table: "CriteriosDeAceptacionPorCasoDeUso",
                column: "CriterioDeAceptacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisitos_IdSubTipoRequisito",
                table: "Requisitos",
                column: "IdSubTipoRequisito");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitosPorCasoDeUso_RequisitoId",
                table: "RequisitosPorCasoDeUso",
                column: "RequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosPorCasoDeUso_ServicioId",
                table: "ServiciosPorCasoDeUso",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTiposRequisito_IdTipoRequisito",
                table: "SubTiposRequisito",
                column: "IdTipoRequisito");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActoresPorCasoDeUso");

            migrationBuilder.DropTable(
                name: "CondicionesPorCasosDeUso");

            migrationBuilder.DropTable(
                name: "CriteriosDeAceptacionPorCasoDeUso");

            migrationBuilder.DropTable(
                name: "RequisitosPorCasoDeUso");

            migrationBuilder.DropTable(
                name: "ServiciosPorCasoDeUso");

            migrationBuilder.DropTable(
                name: "Actores");

            migrationBuilder.DropTable(
                name: "Condiciones");

            migrationBuilder.DropTable(
                name: "CriteriosDeAceptacion");

            migrationBuilder.DropTable(
                name: "Requisitos");

            migrationBuilder.DropTable(
                name: "CasosDeUso");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "SubTiposRequisito");

            migrationBuilder.DropTable(
                name: "TiposRequisito");
        }
    }
}
