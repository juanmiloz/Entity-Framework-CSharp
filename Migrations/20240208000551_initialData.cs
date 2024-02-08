using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fundamentos_de_Entity_Framework.Migrations
{
    /// <inheritdoc />
    public partial class initialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_task",
                table: "task");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "catagory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_task",
                table: "task",
                column: "TaskId");

            migrationBuilder.InsertData(
                table: "catagory",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("0350254e-bf94-47ae-af12-66f0c349958a"), null, "Actividades pendientes", 20 },
                    { new Guid("a1c0ea94-091e-48b1-bb43-2a7ef79070ce"), null, "Actividades familiares", 10 },
                    { new Guid("c23a570b-97aa-414d-8f22-93d4ba804805"), null, "Actividades deportivas", 10 },
                    { new Guid("edb30390-0964-4d2b-88d3-524798688bc0"), null, "Actividades personales", 50 }
                });

            migrationBuilder.InsertData(
                table: "task",
                columns: new[] { "TaskId", "CategoryId", "CreationDate", "Description", "Priority", "Title" },
                values: new object[,]
                {
                    { new Guid("719166a3-46cc-4fb8-a24b-44d810dd2f13"), new Guid("0350254e-bf94-47ae-af12-66f0c349958a"), new DateTime(2024, 2, 7, 19, 5, 51, 161, DateTimeKind.Local).AddTicks(9688), null, 1, "Pago servicios" },
                    { new Guid("76377816-924a-4dd7-9b36-73f2f0152e13"), new Guid("edb30390-0964-4d2b-88d3-524798688bc0"), new DateTime(2024, 2, 7, 19, 5, 51, 161, DateTimeKind.Local).AddTicks(9705), null, 0, "Terminar de ver la pelicula de Netflix" },
                    { new Guid("f39d1a18-5851-41cf-94ff-f3219056d971"), new Guid("c23a570b-97aa-414d-8f22-93d4ba804805"), new DateTime(2024, 2, 7, 19, 5, 51, 161, DateTimeKind.Local).AddTicks(9709), null, 2, "Partido vs papa Karen" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_task_CategoryId",
                table: "task",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_task",
                table: "task");

            migrationBuilder.DropIndex(
                name: "IX_task_CategoryId",
                table: "task");

            migrationBuilder.DeleteData(
                table: "catagory",
                keyColumn: "CategoryId",
                keyValue: new Guid("a1c0ea94-091e-48b1-bb43-2a7ef79070ce"));

            migrationBuilder.DeleteData(
                table: "task",
                keyColumn: "TaskId",
                keyValue: new Guid("719166a3-46cc-4fb8-a24b-44d810dd2f13"));

            migrationBuilder.DeleteData(
                table: "task",
                keyColumn: "TaskId",
                keyValue: new Guid("76377816-924a-4dd7-9b36-73f2f0152e13"));

            migrationBuilder.DeleteData(
                table: "task",
                keyColumn: "TaskId",
                keyValue: new Guid("f39d1a18-5851-41cf-94ff-f3219056d971"));

            migrationBuilder.DeleteData(
                table: "catagory",
                keyColumn: "CategoryId",
                keyValue: new Guid("0350254e-bf94-47ae-af12-66f0c349958a"));

            migrationBuilder.DeleteData(
                table: "catagory",
                keyColumn: "CategoryId",
                keyValue: new Guid("c23a570b-97aa-414d-8f22-93d4ba804805"));

            migrationBuilder.DeleteData(
                table: "catagory",
                keyColumn: "CategoryId",
                keyValue: new Guid("edb30390-0964-4d2b-88d3-524798688bc0"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "catagory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_task",
                table: "task",
                column: "CategoryId");
        }
    }
}
