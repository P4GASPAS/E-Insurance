using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace home_insurance.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_user_agent_id",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_agent_id",
                table: "user");

            migrationBuilder.DropColumn(
                name: "agent_id",
                table: "user");

            migrationBuilder.CreateIndex(
                name: "IX_user_AgentId",
                table: "user",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_user_AgentId",
                table: "user",
                column: "AgentId",
                principalTable: "user",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_user_AgentId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_AgentId",
                table: "user");

            migrationBuilder.AddColumn<int>(
                name: "agent_id",
                table: "user",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_agent_id",
                table: "user",
                column: "agent_id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_user_agent_id",
                table: "user",
                column: "agent_id",
                principalTable: "user",
                principalColumn: "UserId");
        }
    }
}
