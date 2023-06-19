using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WizardSoft.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dirs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dirs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dirs_Dirs_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Dirs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dirs_ParentId",
                table: "Dirs",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dirs");
        }
    }
}
