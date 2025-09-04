using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeImageType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Products",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Id", "SecurityStamp" },
                values: new object[] { "54b4bae0-e64f-4039-9a40-754f9625e2ac", "778cf1e6-42ca-4587-9277-f1450aeb1155", "9f05a182-d981-4586-8533-6a65bd87cfb4" });

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Id", "SecurityStamp" },
                values: new object[] { "910fe69d-b617-45e2-9499-f78fb7d7e6ff", "9d04c578-42c5-4c07-a4dc-5831b3e5f5da", "99ec033f-e2f5-4272-99f1-f0a2e90db2a5" });

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Id", "SecurityStamp" },
                values: new object[] { "f5d98e89-0879-45e1-99a0-312536943faa", "514351fc-c267-4c79-9edb-357baa25e3e3", "53361b4c-bb07-4396-b7a6-5e1cf191b692" });

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "Id", "SecurityStamp" },
                values: new object[] { "307435ce-780b-4764-aad8-78cf80e1dbc2", "48eebbb4-5c85-4325-acbf-76c05ca23374", "e8ba192f-b9ef-404e-a563-c57d403f3669" });

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "Id", "SecurityStamp" },
                values: new object[] { "fb46f21a-ee6b-4bfa-b0ab-35574f3b22c4", "2b687354-95de-487b-8317-74ab26e0bfc3", "3b1fc4ee-fa74-49aa-ba99-f2610deade15" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Id", "SecurityStamp" },
                values: new object[] { "7f5acff3-66a2-4269-8365-6fa7934a3057", "af475d6a-607b-43d2-b820-3545ea766b2f", "1b59155e-bd84-4b84-ba76-3abfa6bcc1e0" });

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Id", "SecurityStamp" },
                values: new object[] { "a85c49fc-6f4a-49a3-8e23-f85f335ceb3b", "ae6b246e-e7d2-4ae4-84c3-ecda1bca4b91", "acf12de1-fd74-423b-ae9a-6d80b8dad069" });

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Id", "SecurityStamp" },
                values: new object[] { "b7579043-44b2-4284-80d1-e8521b9817e7", "5573320b-350d-45fc-b53a-36de9e21509c", "aac1d4fc-1366-45f9-8e3b-76963462f89a" });

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "Id", "SecurityStamp" },
                values: new object[] { "fa7531ff-772c-4311-ae8d-95735038da66", "8607d9ac-74f8-44a5-a774-a2b744a1dfe0", "4d83cddb-28d9-4273-87d3-40f01c597a68" });

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "Id", "SecurityStamp" },
                values: new object[] { "42a83499-d676-46c6-8c5c-4fbc98f7ec48", "1420db61-280b-4f3e-8815-f6c0204e16fc", "91505eb9-7c68-4ad6-8e37-7289342d3196" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImageUrl", "Price", "StockQuantity", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Gaming laptop", "laptop.jpg", 1000m, 10, "Laptop" },
                    { 2, 1, "Smartphone", "phone.jpg", 500m, 20, "Phone" },
                    { 3, 2, "Wireless headphones", "headphones.jpg", 150m, 50, "Headphones" },
                    { 4, 3, "Office chair", "chair.jpg", 200m, 30, "Chair" },
                    { 5, 3, "Wooden desk", "desk.jpg", 300m, 15, "Desk" }
                });
        }
    }
}
