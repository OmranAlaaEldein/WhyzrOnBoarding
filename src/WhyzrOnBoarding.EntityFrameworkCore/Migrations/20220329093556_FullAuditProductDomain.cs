using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhyzrOnBoarding.Migrations
{
    public partial class FullAuditProductDomain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppVariants_AppProducts_ProductId1",
                table: "AppVariants");

            migrationBuilder.DropIndex(
                name: "IX_AppVariants_ProductId1",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "AppVariants");

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AppProducts",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AppProducts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "AppProducts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppProducts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "AppProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AppProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "AppProducts",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "AppProducts");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId1",
                table: "AppVariants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppVariants_ProductId1",
                table: "AppVariants",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AppVariants_AppProducts_ProductId1",
                table: "AppVariants",
                column: "ProductId1",
                principalTable: "AppProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
