using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthAPI.Data.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    patientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.patientId);
                });

            migrationBuilder.CreateTable(
                name: "Ailments",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    patientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ailments", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Ailments_Patients_patientId",
                        column: x => x.patientId,
                        principalTable: "Patients",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Doses = table.Column<string>(nullable: true),
                    patientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Medications_Patients_patientId",
                        column: x => x.patientId,
                        principalTable: "Patients",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ailments_patientId",
                table: "Ailments",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_Medications_patientId",
                table: "Medications",
                column: "patientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ailments");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
