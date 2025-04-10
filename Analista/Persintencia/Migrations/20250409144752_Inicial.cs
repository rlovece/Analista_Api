using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    Nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
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
                    Nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
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
                    Nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
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
                    Nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Orden = table.Column<int>(type: "integer", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposRequisito", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActoresPorCasosDeUso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCasoDeUso = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCondicion = table.Column<Guid>(type: "uuid", nullable: false),
                    ActorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActoresPorCasosDeUso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActoresPorCasosDeUso_Actores_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActoresPorCasosDeUso_CasosDeUso_IdCasoDeUso",
                        column: x => x.IdCasoDeUso,
                        principalTable: "CasosDeUso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CondicionesPorCasosDeUso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCasoDeUso = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCondicion = table.Column<Guid>(type: "uuid", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false)
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
                name: "CriteriodDeAceptacionPorCasoDeUso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCasoDeUso = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCriterioDeAceptacion = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriteriodDeAceptacionPorCasoDeUso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CriteriodDeAceptacionPorCasoDeUso_CasosDeUso_IdCasoDeUso",
                        column: x => x.IdCasoDeUso,
                        principalTable: "CasosDeUso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CriteriodDeAceptacionPorCasoDeUso_CriteriosDeAceptacion_IdC~",
                        column: x => x.IdCriterioDeAceptacion,
                        principalTable: "CriteriosDeAceptacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiciosPorCasosDeUso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCasoDeUso = table.Column<Guid>(type: "uuid", nullable: false),
                    IdServicio = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosPorCasosDeUso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiciosPorCasosDeUso_CasosDeUso_IdCasoDeUso",
                        column: x => x.IdCasoDeUso,
                        principalTable: "CasosDeUso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiciosPorCasosDeUso_Servicios_IdServicio",
                        column: x => x.IdServicio,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubTiposRequisito",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Orden = table.Column<int>(type: "integer", nullable: false),
                    IdTipoRequisito = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
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
                    Nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Orden = table.Column<int>(type: "integer", nullable: false),
                    IdSubTipoRequisito = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    subTipoRequisitoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisitos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requisitos_SubTiposRequisito_subTipoRequisitoId",
                        column: x => x.subTipoRequisitoId,
                        principalTable: "SubTiposRequisito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitosPorCasosDeUso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCasodeUso = table.Column<Guid>(type: "uuid", nullable: false),
                    IdRequisito = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitosPorCasosDeUso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequisitosPorCasosDeUso_CasosDeUso_IdCasodeUso",
                        column: x => x.IdCasodeUso,
                        principalTable: "CasosDeUso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequisitosPorCasosDeUso_Requisitos_IdRequisito",
                        column: x => x.IdRequisito,
                        principalTable: "Requisitos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActoresPorCasosDeUso_ActorId",
                table: "ActoresPorCasosDeUso",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_ActoresPorCasosDeUso_IdCasoDeUso",
                table: "ActoresPorCasosDeUso",
                column: "IdCasoDeUso");

            migrationBuilder.CreateIndex(
                name: "IX_CondicionesPorCasosDeUso_IdCasoDeUso",
                table: "CondicionesPorCasosDeUso",
                column: "IdCasoDeUso");

            migrationBuilder.CreateIndex(
                name: "IX_CondicionesPorCasosDeUso_IdCondicion",
                table: "CondicionesPorCasosDeUso",
                column: "IdCondicion");

            migrationBuilder.CreateIndex(
                name: "IX_CriteriodDeAceptacionPorCasoDeUso_IdCasoDeUso",
                table: "CriteriodDeAceptacionPorCasoDeUso",
                column: "IdCasoDeUso");

            migrationBuilder.CreateIndex(
                name: "IX_CriteriodDeAceptacionPorCasoDeUso_IdCriterioDeAceptacion",
                table: "CriteriodDeAceptacionPorCasoDeUso",
                column: "IdCriterioDeAceptacion");

            migrationBuilder.CreateIndex(
                name: "IX_Requisitos_subTipoRequisitoId",
                table: "Requisitos",
                column: "subTipoRequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitosPorCasosDeUso_IdCasodeUso",
                table: "RequisitosPorCasosDeUso",
                column: "IdCasodeUso");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitosPorCasosDeUso_IdRequisito",
                table: "RequisitosPorCasosDeUso",
                column: "IdRequisito");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosPorCasosDeUso_IdCasoDeUso",
                table: "ServiciosPorCasosDeUso",
                column: "IdCasoDeUso");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosPorCasosDeUso_IdServicio",
                table: "ServiciosPorCasosDeUso",
                column: "IdServicio");

            migrationBuilder.CreateIndex(
                name: "IX_SubTiposRequisito_IdTipoRequisito",
                table: "SubTiposRequisito",
                column: "IdTipoRequisito");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActoresPorCasosDeUso");

            migrationBuilder.DropTable(
                name: "CondicionesPorCasosDeUso");

            migrationBuilder.DropTable(
                name: "CriteriodDeAceptacionPorCasoDeUso");

            migrationBuilder.DropTable(
                name: "RequisitosPorCasosDeUso");

            migrationBuilder.DropTable(
                name: "ServiciosPorCasosDeUso");

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
