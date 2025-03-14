using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Transaction.Dal.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexTransactionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionId",
                table: "Transactions",
                column: "TransactionId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_TransactionId",
                table: "Transactions");
        }
    }
}
