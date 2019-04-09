using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datalayer.Migrations
{
    public partial class Init : Migration
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
                    Brand = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    size = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ClothingID", x => x.ClothingID);
                });

            migrationBuilder.CreateTable(
                name: "Shopbasket",
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
                    fullname = table.Column<string>(maxLength: 50, nullable: false),
                    dateofbirth = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    gender = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    CountryCode = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    paymentO = table.Column<string>(nullable: false)
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
                columns: new[] { "ClothingID", "Brand", "Color", "Description", "name", "price", "size", "status" },
                values: new object[,]
                {
                    { 1, "Adidas", "Black", "Running Shoe with special Gel", "Adiddas A1 Running", 300, null, "Instock" },
                    { 2, "Ecco", "Black", "Leather shoe with antistatic know ", "Ecco Leather Shoe", 800, null, "Instock" },
                    { 3, "Adidas", "Blue", "Running Shoe with special Gel and antiShock Absorber", "Adiddas A2 Running", 1000, null, "NotInstock" },
                    { 4, "Adidas", "Black", "Running Shoe with special Gel", "Asics - new Sensation", 2000, null, "Instock" }
                });

            migrationBuilder.InsertData(
                table: "Shopbasket",
                columns: new[] { "Checkout_id", "ClothingID", "Name", "OrderLines", "Product_id", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "Adiddas A1 Running", "3", 1, 3 },
                    { 2, 2, "Adiddas A1 Running", "3", 2, 3 },
                    { 3, 3, "Ecco", "3", 3, 3 },
                    { 4, 4, "Adiddas A1 Running", "3", 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "userinformation",
                columns: new[] { "id", "Address", "CountryCode", "city", "dateofbirth", "email", "fullname", "gender", "paymentO" },
                values: new object[,]
                {
                    { 1, "petersvej 1", 7600, "petersborg", new DateTime(2019, 4, 8, 13, 51, 53, 535, DateTimeKind.Local).AddTicks(9180), "Peter@gmail.com", "peter petersen", null, "MasterCard" },
                    { 2, "AndersVej  1", 7600, "Andersborg", new DateTime(2019, 4, 8, 13, 51, 53, 538, DateTimeKind.Local).AddTicks(6909), "anders@gmail.com", "Anders Andersen", null, "MasterCard" },
                    { 3, "kathrinevej  1", 7600, "kathrinebjerg", new DateTime(2019, 4, 8, 13, 51, 53, 538, DateTimeKind.Local).AddTicks(8578), "Kathrine@gmail.com", "Kathrine Kristiansen", null, "MasterCard" }
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
                name: "Shopbasket");

            migrationBuilder.DropTable(
                name: "userinformation");
        }
    }
}
