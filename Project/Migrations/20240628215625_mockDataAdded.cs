using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class mockDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "IdClient", "Address", "Discriminator", "Email", "FirstName", "IsDeleted", "LastName", "Pesel", "PhoneNumber" },
                values: new object[] { 1, "TestAddress", "IndividualClient", "test@gmail.com", "TestFirstName", false, "TestLastName", "12345678901", "123456789" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "IdClient", "Address", "CompanyName", "Discriminator", "Email", "KrsNumber", "PhoneNumber" },
                values: new object[] { 2, "TestAddress", "TestCompanyName", "CompanyClient", "test@gmail.com", "1234567890", "123456789" });

            migrationBuilder.InsertData(
                table: "SoftwareSystems",
                columns: new[] { "Id", "Category", "Description", "Name", "Version", "YearlyPrice" },
                values: new object[,]
                {
                    { 1, "TestCategory", "TestDescription", "TestName", "1.0", 100.0 },
                    { 2, "TestCategory2", "TestDescription2", "TestName2", "2.0", 200.0 }
                });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "IdContract", "DurationInYears", "EndDate", "IdClient", "IdSoftwareSystem", "Paid", "PreviousClientDiscount", "Price", "SoftwareSystemVersion", "StartDate", "Updates" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 7, 8, 23, 56, 24, 397, DateTimeKind.Local).AddTicks(5830), 1, 1, 0.0, true, 100.0, "1.0", new DateTime(2024, 6, 28, 23, 56, 24, 397, DateTimeKind.Local).AddTicks(5490), "TestUpdates" },
                    { 2, 1, new DateTime(2024, 7, 8, 23, 56, 24, 397, DateTimeKind.Local).AddTicks(5850), 2, 2, 0.0, false, 200.0, "2.0", new DateTime(2024, 6, 28, 23, 56, 24, 397, DateTimeKind.Local).AddTicks(5850), "TestUpdates2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "IdContract",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "IdContract",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "IdClient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "IdClient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SoftwareSystems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SoftwareSystems",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
