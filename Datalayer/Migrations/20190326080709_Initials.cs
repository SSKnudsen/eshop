using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datalayer.Migrations
{
    public partial class Initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    dateoforder = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("OrderId", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Po",
                columns: table => new
                {
                    ClothingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    price = table.Column<int>(nullable: false),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ClothingID", x => x.ClothingID);
                });

            migrationBuilder.CreateTable(
                name: "Prodinfo",
                columns: table => new
                {
                    productinfoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<int>(nullable: false),
                    Color = table.Column<bool>(nullable: false),
                    size = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("productinfoID", x => x.productinfoID);
                });

            migrationBuilder.CreateTable(
                name: "shopbaskets",
                columns: table => new
                {
                    Checkout_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClothingID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OrderLines = table.Column<string>(nullable: true),
                    Product_id = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Checkout_id", x => x.Checkout_id);
                });

            migrationBuilder.CreateTable(
                name: "userinf",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fullname = table.Column<int>(nullable: false),
                    dateofbirth = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    CountryCode = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    paymentO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Po");

            migrationBuilder.DropTable(
                name: "Prodinfo");

            migrationBuilder.DropTable(
                name: "shopbaskets");

            migrationBuilder.DropTable(
                name: "userinf");
        }
    }
}
