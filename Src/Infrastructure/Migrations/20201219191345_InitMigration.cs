using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpheliaLab.Infrastructure.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIES",
                columns: table => new
                {
                    category_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIES", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMERS",
                columns: table => new
                {
                    customer_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_type = table.Column<string>(maxLength: 10, nullable: false),
                    ID_number = table.Column<string>(maxLength: 20, nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    surname = table.Column<string>(maxLength: 50, nullable: false),
                    birthdate = table.Column<DateTime>(nullable: false),
                    phone_number = table.Column<string>(maxLength: 15, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERS", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    product_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(maxLength: 50, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    description = table.Column<string>(maxLength: 500, nullable: true),
                    unit_price = table.Column<decimal>(type: "decimal(12, 2)", nullable: false),
                    quantity = table.Column<int>(maxLength: 10, nullable: false),
                    category_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_CATEGORIES_category_id",
                        column: x => x.category_id,
                        principalTable: "CATEGORIES",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INVOICES",
                columns: table => new
                {
                    invoice_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<string>(maxLength: 20, nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    customer_id = table.Column<int>(nullable: false),
                    tax = table.Column<decimal>(type: "decimal(4, 2)", nullable: false),
                    amount_total = table.Column<decimal>(type: "decimal(12, 2)", nullable: false),
                    notes = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVOICES", x => x.invoice_id);
                    table.ForeignKey(
                        name: "FK_INVOICES_CUSTOMERS_customer_id",
                        column: x => x.customer_id,
                        principalTable: "CUSTOMERS",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRICE_LIST",
                columns: table => new
                {
                    price_list_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(maxLength: 100, nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    price = table.Column<decimal>(type: "decimal(12, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRICE_LIST", x => x.price_list_id);
                    table.ForeignKey(
                        name: "FK_PRICE_LIST_PRODUCTS_product_id",
                        column: x => x.product_id,
                        principalTable: "PRODUCTS",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INVOICES_LINE",
                columns: table => new
                {
                    invoice_line_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoice_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(maxLength: 10, nullable: false),
                    unit_price = table.Column<decimal>(type: "decimal(12, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVOICES_LINE", x => x.invoice_line_id);
                    table.ForeignKey(
                        name: "FK_INVOICES_LINE_INVOICES_invoice_id",
                        column: x => x.invoice_id,
                        principalTable: "INVOICES",
                        principalColumn: "invoice_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INVOICES_LINE_PRODUCTS_product_id",
                        column: x => x.product_id,
                        principalTable: "PRODUCTS",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_INVOICES_customer_id",
                table: "INVOICES",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_INVOICES_LINE_invoice_id",
                table: "INVOICES_LINE",
                column: "invoice_id");

            migrationBuilder.CreateIndex(
                name: "IX_INVOICES_LINE_product_id",
                table: "INVOICES_LINE",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_PRICE_LIST_product_id",
                table: "PRICE_LIST",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_category_id",
                table: "PRODUCTS",
                column: "category_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "INVOICES_LINE");

            migrationBuilder.DropTable(
                name: "PRICE_LIST");

            migrationBuilder.DropTable(
                name: "INVOICES");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "CUSTOMERS");

            migrationBuilder.DropTable(
                name: "CATEGORIES");
        }
    }
}
