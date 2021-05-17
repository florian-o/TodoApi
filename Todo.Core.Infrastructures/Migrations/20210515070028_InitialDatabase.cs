using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Todo.Core.Infrastructures.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    idTodo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    todoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    todoStatus = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isModif = table.Column<bool>(type: "bit", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    todoDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.idTodo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");
        }
    }
}
