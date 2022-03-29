using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhyzrOnBoarding.Migrations
{
    public partial class CorrectProjectDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "ColorAR",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "ColorFR",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "Matrial",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "MatrialAR",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "MatrialFR",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "ModelAR",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "ModelFR",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "SizeAR",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "SizeFR",
                table: "AppVariants");

            migrationBuilder.RenameColumn(
                name: "Sku",
                table: "AppProducts",
                newName: "OptionD2");

            migrationBuilder.RenameColumn(
                name: "NameFR",
                table: "AppProducts",
                newName: "OptionD1");

            migrationBuilder.RenameColumn(
                name: "NameAR",
                table: "AppProducts",
                newName: "OptionD");

            migrationBuilder.RenameColumn(
                name: "DescriptionFR",
                table: "AppProducts",
                newName: "OptionC2");

            migrationBuilder.RenameColumn(
                name: "DescriptionAR",
                table: "AppProducts",
                newName: "OptionC1");

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppVariants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppVariants",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppVariants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "AppVariants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId1",
                table: "AppVariants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sku",
                table: "AppVariants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValueOPtionA",
                table: "AppVariants",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValueOPtionA1",
                table: "AppVariants",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValueOPtionA2",
                table: "AppVariants",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValueOPtionB",
                table: "AppVariants",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValueOPtionB1",
                table: "AppVariants",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValueOPtionB2",
                table: "AppVariants",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValueOPtionC",
                table: "AppVariants",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValueOPtionC1",
                table: "AppVariants",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValueOPtionC2",
                table: "AppVariants",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValueOPtionD",
                table: "AppVariants",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValueOPtionD1",
                table: "AppVariants",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValueOPtionD2",
                table: "AppVariants",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AppProducts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Description1",
                table: "AppProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description2",
                table: "AppProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name1",
                table: "AppProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name2",
                table: "AppProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OptionA",
                table: "AppProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OptionA1",
                table: "AppProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OptionA2",
                table: "AppProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OptionB",
                table: "AppProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OptionB1",
                table: "AppProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OptionB2",
                table: "AppProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OptionC",
                table: "AppProducts",
                type: "nvarchar(max)",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppVariants_AppProducts_ProductId1",
                table: "AppVariants");

            migrationBuilder.DropIndex(
                name: "IX_AppVariants_ProductId1",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "Sku",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "ValueOPtionA",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "ValueOPtionA1",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "ValueOPtionA2",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "ValueOPtionB",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "ValueOPtionB1",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "ValueOPtionB2",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "ValueOPtionC",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "ValueOPtionC1",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "ValueOPtionC2",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "ValueOPtionD",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "ValueOPtionD1",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "ValueOPtionD2",
                table: "AppVariants");

            migrationBuilder.DropColumn(
                name: "Description1",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "Description2",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "Name1",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "Name2",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "OptionA",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "OptionA1",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "OptionA2",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "OptionB",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "OptionB1",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "OptionB2",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "OptionC",
                table: "AppProducts");

            migrationBuilder.RenameColumn(
                name: "OptionD2",
                table: "AppProducts",
                newName: "Sku");

            migrationBuilder.RenameColumn(
                name: "OptionD1",
                table: "AppProducts",
                newName: "NameFR");

            migrationBuilder.RenameColumn(
                name: "OptionD",
                table: "AppProducts",
                newName: "NameAR");

            migrationBuilder.RenameColumn(
                name: "OptionC2",
                table: "AppProducts",
                newName: "DescriptionFR");

            migrationBuilder.RenameColumn(
                name: "OptionC1",
                table: "AppProducts",
                newName: "DescriptionAR");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "AppVariants",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorAR",
                table: "AppVariants",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorFR",
                table: "AppVariants",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Matrial",
                table: "AppVariants",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MatrialAR",
                table: "AppVariants",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MatrialFR",
                table: "AppVariants",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "AppVariants",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModelAR",
                table: "AppVariants",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModelFR",
                table: "AppVariants",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "AppVariants",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeAR",
                table: "AppVariants",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeFR",
                table: "AppVariants",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AppProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
