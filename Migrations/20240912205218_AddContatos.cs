using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallengeLocaweb.Migrations
{
    /// <inheritdoc />
    public partial class AddContatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioID",
                table: "Preferencias",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    IdContato = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeCont = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NumeroCont = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EmailCont = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.IdContato);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Preferencias_UsuarioID",
                table: "Preferencias",
                column: "UsuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Preferencias_Usuarios_UsuarioID",
                table: "Preferencias",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Preferencias_Usuarios_UsuarioID",
                table: "Preferencias");

            migrationBuilder.DropTable(
                name: "Contato");

            migrationBuilder.DropIndex(
                name: "IX_Preferencias_UsuarioID",
                table: "Preferencias");

            migrationBuilder.DropColumn(
                name: "UsuarioID",
                table: "Preferencias");
        }
    }
}
