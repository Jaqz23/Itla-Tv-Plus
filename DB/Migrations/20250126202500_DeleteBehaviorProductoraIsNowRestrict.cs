using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class DeleteBehaviorProductoraIsNowRestrict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Series_Productoras_ProductoraId",
                table: "Series");

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Productoras_ProductoraId",
                table: "Series",
                column: "ProductoraId",
                principalTable: "Productoras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Series_Productoras_ProductoraId",
                table: "Series");

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Productoras_ProductoraId",
                table: "Series",
                column: "ProductoraId",
                principalTable: "Productoras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
