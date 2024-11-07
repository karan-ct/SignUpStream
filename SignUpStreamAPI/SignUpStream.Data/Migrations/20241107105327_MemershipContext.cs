using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignUpStream.Data.Migrations
{
    /// <inheritdoc />
    public partial class MemershipContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MembeshipPlanType",
                table: "PricePlan",
                newName: "MembershipPlanType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MembershipPlanType",
                table: "PricePlan",
                newName: "MembeshipPlanType");
        }
    }
}
