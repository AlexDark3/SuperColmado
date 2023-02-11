using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SUPERCOLMADO.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermisosParaCrear = table.Column<bool>(type: "bit", nullable: false),
                    PermisosParaBorrar = table.Column<bool>(type: "bit", nullable: false),
                    PermisosParaEditar = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioRolId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioRoles_UsuarioRoles_UsuarioRolId",
                        column: x => x.UsuarioRolId,
                        principalTable: "UsuarioRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioRolId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_UsuarioRoles_UsuarioRolId",
                        column: x => x.UsuarioRolId,
                        principalTable: "UsuarioRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRoles_UsuarioRolId",
                table: "UsuarioRoles",
                column: "UsuarioRolId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioRolId",
                table: "Usuarios",
                column: "UsuarioRolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "UsuarioRoles");
        }
    }
}
