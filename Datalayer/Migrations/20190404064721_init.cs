using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datalayer.Migrations
{
    public partial class init : Migration
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
                name: "Prodinfo",
                columns: table => new
                {
                    productinfoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    size = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("productinfoID", x => x.productinfoID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
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
                name: "userinformation",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fullname = table.Column<string>(nullable: true),
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

            migrationBuilder.InsertData(
                table: "Prodinfo",
                columns: new[] { "productinfoID", "Brand", "Color", "size" },
                values: new object[,]
                {
                    { 1, " Adiddas", "Black", "10" },
                    { 2, "Adiddas", "White", "11" },
                    { 3, "Ecco", "Brown", "12" },
                    { 4, "Adiddas", "Black", "10" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ClothingID", "Description", "name", "price", "status" },
                values: new object[,]
                {
                    { 1, "Running Shoe with special Gel", "Adiddas A1 Running", 300, "Instock" },
                    { 2, "Leather shoe with antistatic know ", "Ecco Leather Shoe", 800, "Instock" },
                    { 3, "Running Shoe with special Gel and antiShock Absorber", "Adiddas A2 Running", 1000, "NotInstock" },
                    { 4, "Running Shoe with special Gel", "Asics - new Sensation", 2000, "Instock" }
                });

            migrationBuilder.InsertData(
                table: "userinformation",
                columns: new[] { "id", "Address", "CountryCode", "city", "dateofbirth", "email", "fullname", "gender", "paymentO" },
                values: new object[,]
                {
                    { 1, "petersvej 1", 7600, "petersborg", new DateTime(2019, 4, 4, 8, 47, 20, 506, DateTimeKind.Local).AddTicks(9948), "Peter@gmail.com", "peter petersen", null, "MasterCard" },
                    { 2, "AndersVej  1", 7600, "Andersborg", new DateTime(2019, 4, 4, 8, 47, 20, 508, DateTimeKind.Local).AddTicks(9932), "anders@gmail.com", "Anders Andersen", null, "MasterCard" },
                    { 3, "kathrinevej  1", 7600, "kathrinebjerg", new DateTime(2019, 4, 4, 8, 47, 20, 509, DateTimeKind.Local).AddTicks(9921), "Kathrine@gmail.com", "Kathrine Kristiansen", null, "MasterCard" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Prodinfo");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "shopbaskets");

            migrationBuilder.DropTable(
                name: "userinformation");
        }
    }
}
