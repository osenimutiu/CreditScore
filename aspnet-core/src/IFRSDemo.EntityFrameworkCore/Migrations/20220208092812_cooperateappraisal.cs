using Microsoft.EntityFrameworkCore.Migrations;

namespace IFRSDemo.Migrations
{
    public partial class cooperateappraisal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CooperateAppraisals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    RCNumber = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false),
                    SetupQualitativeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CooperateAppraisals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CooperateAppraisals_SetupQualitatives_SetupQualitativeId",
                        column: x => x.SetupQualitativeId,
                        principalTable: "SetupQualitatives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CooperateAppraisals_SetupQualitativeId",
                table: "CooperateAppraisals",
                column: "SetupQualitativeId");

            migrationBuilder.CreateIndex(
                name: "IX_CooperateAppraisals_TenantId",
                table: "CooperateAppraisals",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CooperateAppraisals");
        }
    }
}
