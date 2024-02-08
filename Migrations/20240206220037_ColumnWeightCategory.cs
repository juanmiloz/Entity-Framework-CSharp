using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fundamentos_de_Entity_Framework.Migrations
{
    /// <inheritdoc />
    public partial class ColumnWeightCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "catagory",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "catagory");
        }
    }
}
