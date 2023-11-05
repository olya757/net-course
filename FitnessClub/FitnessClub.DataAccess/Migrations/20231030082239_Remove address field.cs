using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessClub.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Removeaddressfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "clubs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "clubs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
