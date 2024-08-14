using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFKTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CustomerModelId",
                table: "Tickets",
                column: "CustomerModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventModelId",
                table: "Tickets",
                column: "EventModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Customers_CustomerModelId",
                table: "Tickets",
                column: "CustomerModelId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Events_EventModelId",
                table: "Tickets",
                column: "EventModelId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Customers_CustomerModelId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Events_EventModelId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_CustomerModelId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_EventModelId",
                table: "Tickets");
        }
    }
}
