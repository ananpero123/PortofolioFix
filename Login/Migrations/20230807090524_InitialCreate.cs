using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Login.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Portofolio",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deskripsi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pendidikan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    keahlian = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pengalaman = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    keahlian1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    keahlian2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    keahlian3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pengalaman2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pengalaman3 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portofolio", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Portol",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deskripsi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pendidikan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    keahlian = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pengalaman = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    foto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portol", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Portofolio");

            migrationBuilder.DropTable(
                name: "Portol");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
