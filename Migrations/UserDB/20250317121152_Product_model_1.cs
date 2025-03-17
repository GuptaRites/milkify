using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace milkify.Migrations.UserDB
{
    /// <inheritdoc />
    public partial class Product_model_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Products",
                type: "varchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Products",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Products",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char");

            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                table: "Products",
                type: "varchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Products",
                type: "char",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Products",
                type: "char",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Products",
                type: "char",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                table: "Products",
                type: "char",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)");
        }
    }
}
