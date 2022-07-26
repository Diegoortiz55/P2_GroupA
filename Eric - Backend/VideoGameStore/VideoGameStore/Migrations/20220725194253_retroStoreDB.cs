using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGameStore.Migrations
{
    public partial class retroStoreDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthenticateUser",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticateUser", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ContactInfo",
                columns: table => new
                {
                    userName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    emailAddress = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    contactNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_userName2", x => x.userName);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ProductInfo",
                columns: table => new
                {
                    productId = table.Column<int>(type: "int", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    productGenre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    productPlatform = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    productManufacturer = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    productReleaseDate = table.Column<int>(type: "int", nullable: true),
                    productCost = table.Column<decimal>(type: "money", nullable: true),
                    productQty = table.Column<int>(type: "int", nullable: true),
                    productIsInStock = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productId", x => x.productId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_RegisterInfo",
                columns: table => new
                {
                    userName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    userPassword = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    firstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    stAddress = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    city = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    customerState = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    AddressZip = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_userName", x => x.userName);
                });

            migrationBuilder.CreateTable(
                name: "tbl_OrdersInfo",
                columns: table => new
                {
                    orderNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderName = table.Column<int>(type: "int", unicode: false, maxLength: 30, nullable: false),
                    orderPrice = table.Column<decimal>(type: "money", nullable: true),
                    paymentType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    orderDate = table.Column<DateTime>(type: "date", nullable: true),
                    pointsEarned = table.Column<int>(type: "int", nullable: true),
                    RegisteruserName = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orderNo", x => x.orderNo);
                    table.ForeignKey(
                        name: "FK_tbl_OrdersInfo_tbl_RegisterInfo_RegisteruserName",
                        column: x => x.RegisteruserName,
                        principalTable: "tbl_RegisterInfo",
                        principalColumn: "userName");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_OrdersInfo_RegisteruserName",
                table: "tbl_OrdersInfo",
                column: "RegisteruserName");
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
                name: "tbl_RegisterInfo");
        }
    }
}
