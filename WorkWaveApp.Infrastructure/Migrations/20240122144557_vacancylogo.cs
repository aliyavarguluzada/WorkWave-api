using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkWaveApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class vacancylogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Vacancies");
        }
    }
}
