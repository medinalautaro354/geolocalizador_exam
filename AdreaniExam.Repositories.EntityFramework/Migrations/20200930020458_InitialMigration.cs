using Microsoft.EntityFrameworkCore.Migrations;

namespace AdreaniExam.Repositories.EntityFramework.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressRequest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false),
                    Province = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddressResult",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<double>(nullable: true),
                    Longitude = table.Column<double>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    AddressRequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressResult_AddressRequest_AddressRequestId",
                        column: x => x.AddressRequestId,
                        principalTable: "AddressRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressResult_AddressRequestId",
                table: "AddressResult",
                column: "AddressRequestId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressResult");

            migrationBuilder.DropTable(
                name: "AddressRequest");
        }
    }
}
