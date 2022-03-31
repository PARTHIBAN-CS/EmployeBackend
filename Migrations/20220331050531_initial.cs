using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.EnsureSchema(
            //     name: "dbo");

            // migrationBuilder.CreateSequence<int>(
            //     name: "rollno",
            //     schema: "dbo");

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "NEXT VALUE FOR dbo.Order_seq"),
                    firstname = table.Column<string>(type: "text", nullable: true),
                    attendance = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.id);
                });

            // migrationBuilder.CreateTable(
            //     name: "Employes",
            //     columns: table => new
            //     {
            //         rollno = table.Column<int>(type: "integer", nullable: false)
            //             .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //         firstname = table.Column<string>(type: "text", nullable: true),
            //         lastname = table.Column<string>(type: "text", nullable: true),
            //         gender = table.Column<string>(type: "text", nullable: true),
            //         phoneno = table.Column<string>(type: "text", nullable: true),
            //         mail = table.Column<string>(type: "text", nullable: true),
            //         password = table.Column<string>(type: "text", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Employes", x => x.rollno);
            //     });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "Employes");

            migrationBuilder.DropSequence(
                name: "rollno",
                schema: "dbo");
        }
    }
}
