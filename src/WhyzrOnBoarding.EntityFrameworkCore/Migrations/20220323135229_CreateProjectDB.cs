using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhyzrOnBoarding.Migrations
{
    public partial class CreateProjectDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    NameAR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameFR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionAR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionFR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppVariants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    SizeAR = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    SizeFR = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ColorAR = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ColorFR = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ModelAR = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ModelFR = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Matrial = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    MatrialAR = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    MatrialFR = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppVariants_AppProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "AppProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppProducts_Name",
                table: "AppProducts",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_AppVariants_ProductId",
                table: "AppVariants",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppVariants");

            migrationBuilder.DropTable(
                name: "AppProducts");
        }
    }
}
