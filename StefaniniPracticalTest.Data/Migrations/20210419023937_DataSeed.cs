using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StefaniniPracticalTest.Data.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Classifications",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "VIP" },
                    { 2, "Regular" },
                    { 3, "Sporadic" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Masculine" },
                    { 2, "Feminine" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Rio Grande do Sul" },
                    { 2, "São Paulo" },
                    { 3, "Curitiba" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "IsAdmin", "Name" },
                values: new object[,]
                {
                    { 1, true, "Administrator" },
                    { 2, false, "Seller " }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "RegionId" },
                values: new object[] { 1, "Porto Alegre", 1 });

            migrationBuilder.InsertData(
                table: "UserSys",
                columns: new[] { "Id", "Email", "Login", "Password", "UserRoleId" },
                values: new object[,]
                {
                    { 1, "admin@app.com", "Administrator", "e6e061838856bf47e1de730719fb2609", 1 },
                    { 2, "seller1@app.com", "Seller1", "15a0185323e401148285d087185cb6c8", 2 },
                    { 3, "seller2@app.com", "Seller2", "cfd6fa9b293a147327cc92af0ce3eeb0", 2 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CityId", "ClassificationId", "GenderId", "LastPurchase", "Name", "Phone", "RegionId", "UserId" },
                values: new object[,]
                {
                    { 2, 1, 1, 2, new DateTime(2015, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carla", "(53) 94569999", 1, 2 },
                    { 3, 1, 3, 2, new DateTime(2013, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maria", "(64) 94518888", 1, 2 },
                    { 4, 1, 2, 1, new DateTime(2016, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Douglas", "(51) 12455555", 1, 2 },
                    { 1, 1, 1, 1, new DateTime(2016, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maurício", "(11) 95429999", 1, 3 },
                    { 5, 1, 2, 2, new DateTime(2016, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marta", "(51) 45788888", 1, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserSys",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserSys",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserSys",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
