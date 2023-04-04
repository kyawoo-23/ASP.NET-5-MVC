using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelBindingDemo.Migrations
{
    public partial class AddDeveloperSkillsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Developers",
                newName: "DeveloperId");

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperSkill",
                columns: table => new
                {
                    DevelopersDeveloperId = table.Column<int>(type: "int", nullable: false),
                    SkillsSkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperSkill", x => new { x.DevelopersDeveloperId, x.SkillsSkillId });
                    table.ForeignKey(
                        name: "FK_DeveloperSkill_Developers_DevelopersDeveloperId",
                        column: x => x.DevelopersDeveloperId,
                        principalTable: "Developers",
                        principalColumn: "DeveloperId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperSkill_Skills_SkillsSkillId",
                        column: x => x.SkillsSkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperSkills",
                columns: table => new
                {
                    DeveloperSkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeveloperId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    SkillLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperSkills", x => x.DeveloperSkillId);
                    table.ForeignKey(
                        name: "FK_DeveloperSkills_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "DeveloperId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperSkill_SkillsSkillId",
                table: "DeveloperSkill",
                column: "SkillsSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperSkills_DeveloperId",
                table: "DeveloperSkills",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperSkills_SkillId",
                table: "DeveloperSkills",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeveloperSkill");

            migrationBuilder.DropTable(
                name: "DeveloperSkills");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.RenameColumn(
                name: "DeveloperId",
                table: "Developers",
                newName: "Id");
        }
    }
}
