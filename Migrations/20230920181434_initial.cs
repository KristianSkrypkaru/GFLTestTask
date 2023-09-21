using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GFLTestTask.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    FolderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FolderName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ParentFolderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.FolderID);
                    table.ForeignKey(
                        name: "FK_Folders_Folders_ParentFolderID",
                        column: x => x.ParentFolderID,
                        principalTable: "Folders",
                        principalColumn: "FolderID");
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "FolderID", "FolderName", "ParentFolderID" },
                values: new object[,]
                {
                    { 1, "Creating Digital Images", null },
                    { 2, "Resources", 1 },
                    { 3, "Evidence", 1 },
                    { 4, "Graphic Products", 1 },
                    { 5, "Primary Sources", 2 },
                    { 6, "Secondary Sources", 2 },
                    { 7, "Process", 4 },
                    { 8, "Final Product", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Folders_ParentFolderID",
                table: "Folders",
                column: "ParentFolderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folders");
        }
    }
}
