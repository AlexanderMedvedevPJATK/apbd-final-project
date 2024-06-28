using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class FieldsChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Client_ClientId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_SoftwareSystems_SoftwareSystemId",
                table: "Contracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Contracts");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.RenameColumn(
                name: "SoftwareSystemId",
                table: "Contracts",
                newName: "IdSoftwareSystem");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Contracts",
                newName: "IdClient");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_SoftwareSystemId",
                table: "Contracts",
                newName: "IX_Contracts_IdSoftwareSystem");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_ClientId",
                table: "Contracts",
                newName: "IX_Contracts_IdClient");

            migrationBuilder.AddColumn<double>(
                name: "Paid",
                table: "Contracts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "IdClient");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Clients_IdClient",
                table: "Contracts",
                column: "IdClient",
                principalTable: "Clients",
                principalColumn: "IdClient",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_SoftwareSystems_IdSoftwareSystem",
                table: "Contracts",
                column: "IdSoftwareSystem",
                principalTable: "SoftwareSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Clients_IdClient",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_SoftwareSystems_IdSoftwareSystem",
                table: "Contracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Contracts");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.RenameColumn(
                name: "IdSoftwareSystem",
                table: "Contracts",
                newName: "SoftwareSystemId");

            migrationBuilder.RenameColumn(
                name: "IdClient",
                table: "Contracts",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_IdSoftwareSystem",
                table: "Contracts",
                newName: "IX_Contracts_SoftwareSystemId");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_IdClient",
                table: "Contracts",
                newName: "IX_Contracts_ClientId");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Contracts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "IdClient");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Client_ClientId",
                table: "Contracts",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "IdClient",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_SoftwareSystems_SoftwareSystemId",
                table: "Contracts",
                column: "SoftwareSystemId",
                principalTable: "SoftwareSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
