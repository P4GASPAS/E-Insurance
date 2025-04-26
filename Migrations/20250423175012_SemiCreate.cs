using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace home_insurance.Migrations
{
    /// <inheritdoc />
    public partial class SemiCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_user_AgentId",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "users");

            migrationBuilder.RenameIndex(
                name: "IX_user_AgentId",
                table: "users",
                newName: "IX_users_AgentId");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "houses",
                columns: table => new
                {
                    HouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearBuild = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<double>(type: "float", nullable: false),
                    ConstructionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeOccupancy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentVerified = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_houses", x => x.HouseId);
                    table.ForeignKey(
                        name: "FK_houses_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "policies",
                columns: table => new
                {
                    PolicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuranceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthlyPayment = table.Column<double>(type: "float", nullable: false),
                    ActivationFee = table.Column<double>(type: "float", nullable: false),
                    DwellingCoverage = table.Column<double>(type: "float", nullable: false),
                    PersonalPropertyCoverage = table.Column<double>(type: "float", nullable: false),
                    LiabilityCoverage = table.Column<double>(type: "float", nullable: false),
                    AdditionalLivingExpenses = table.Column<double>(type: "float", nullable: false),
                    NaturalCalamities = table.Column<double>(type: "float", nullable: false),
                    ContractLengthMonths = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_policies", x => x.PolicyId);
                });

            migrationBuilder.CreateTable(
                name: "insurances",
                columns: table => new
                {
                    InsuranceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    DateTimeStarted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastPaymentDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuranceStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GracePeriod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insurances", x => x.InsuranceId);
                    table.ForeignKey(
                        name: "FK_insurances_houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "houses",
                        principalColumn: "HouseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_insurances_policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "policies",
                        principalColumn: "PolicyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_houses_UserId",
                table: "houses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_insurances_HouseId",
                table: "insurances",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_insurances_PolicyId",
                table: "insurances",
                column: "PolicyId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_users_AgentId",
                table: "users",
                column: "AgentId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_users_AgentId",
                table: "users");

            migrationBuilder.DropTable(
                name: "insurances");

            migrationBuilder.DropTable(
                name: "houses");

            migrationBuilder.DropTable(
                name: "policies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_Email",
                table: "users");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "user");

            migrationBuilder.RenameIndex(
                name: "IX_users_AgentId",
                table: "user",
                newName: "IX_user_AgentId");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_user_AgentId",
                table: "user",
                column: "AgentId",
                principalTable: "user",
                principalColumn: "UserId");
        }
    }
}
