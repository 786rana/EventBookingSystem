using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class ebs25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarriageHallServices_Orders_OrderId",
                table: "MarriageHallServices");

            migrationBuilder.DropIndex(
                name: "IX_MarriageHallServices_OrderId",
                table: "MarriageHallServices");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "MarriageHallServices");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Servicess",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServicesId",
                table: "OrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "MarriageHalls",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servicess_OrderId",
                table: "Servicess",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_MarriageHallId",
                table: "OrderDetails",
                column: "MarriageHallId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ServicesId",
                table: "OrderDetails",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_MarriageHalls_OrderId",
                table: "MarriageHalls",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_MarriageHalls_Orders_OrderId",
                table: "MarriageHalls",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_MarriageHalls_MarriageHallId",
                table: "OrderDetails",
                column: "MarriageHallId",
                principalTable: "MarriageHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Servicess_ServicesId",
                table: "OrderDetails",
                column: "ServicesId",
                principalTable: "Servicess",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicess_Orders_OrderId",
                table: "Servicess",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarriageHalls_Orders_OrderId",
                table: "MarriageHalls");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_MarriageHalls_MarriageHallId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Servicess_ServicesId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicess_Orders_OrderId",
                table: "Servicess");

            migrationBuilder.DropIndex(
                name: "IX_Servicess_OrderId",
                table: "Servicess");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_MarriageHallId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ServicesId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_MarriageHalls_OrderId",
                table: "MarriageHalls");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Servicess");

            migrationBuilder.DropColumn(
                name: "ServicesId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "MarriageHalls");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "MarriageHallServices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MarriageHallServices_OrderId",
                table: "MarriageHallServices",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_MarriageHallServices_Orders_OrderId",
                table: "MarriageHallServices",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
