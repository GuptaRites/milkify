using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace milkify.Migrations.UserDB
{
    /// <inheritdoc />
    public partial class Product_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "char(64)", nullable: false),
                    Type = table.Column<string>(type: "char", nullable: false),
                    Title = table.Column<string>(type: "char", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Desc = table.Column<string>(type: "char", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
