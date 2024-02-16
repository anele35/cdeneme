using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cdeneme.Migrations
{
    /// <inheritdoc />
    public partial class cuzdantable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cuzdan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "123579, 163"),
                    cuzdanadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bakiye = table.Column<decimal>(type: "decimal(18,2)", nullable: false)

                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuzdan", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cuzdan");
        }
    }
}
