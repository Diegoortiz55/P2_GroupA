using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroStoreMVC.Migrations
{
    public partial class retroStoreDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
   

            migrationBuilder.CreateIndex(
                name: "IX_tbl_OrdersInfo_RegisteruserName",
                table: "tbl_OrdersInfo",
                column: "RegisteruserName");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ProductRanking_RankingproductId",
                table: "tbl_ProductRanking",
                column: "RankingproductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthenticateUser");

            migrationBuilder.DropTable(
                name: "tbl_ContactInfo");

            migrationBuilder.DropTable(
                name: "tbl_OrdersInfo");

            migrationBuilder.DropTable(
                name: "tbl_ProductInfo");

            migrationBuilder.DropTable(
                name: "tbl_ProductRanking");

            migrationBuilder.DropTable(
                name: "tbl_RegisterInfo");
        }
    }
}
