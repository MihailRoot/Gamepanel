using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace panel.Migrations
{
    public partial class InitServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Server",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ftpuser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ftppassword = table.Column<int>(type: "int", nullable: true),
                    ContainerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Port = table.Column<int>(type: "int", nullable: false),
                    Setup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cpu = table.Column<float>(type: "real", nullable: false),
                    memory = table.Column<double>(type: "float", nullable: false),
                    Disk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Server", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Server");
        }
    }
}
