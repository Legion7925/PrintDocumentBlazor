using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintDocument.Core.Migrations
{
    /// <inheritdoc />
    public partial class addeduserfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Keywords");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Keywords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keywords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Keywords_Keywords_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Keywords",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Keywords_ParentId",
                table: "Keywords",
                column: "ParentId");
        }
    }
}
