using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Tasks",
               columns: table => new
               {
                   Id = table.Column<Guid>(nullable: false),
                   Title = table.Column<string>(nullable: false),
                   Description = table.Column<string>(nullable: false),
                   IsCompleted = table.Column<bool>(nullable: false),
                   CreatedAt = table.Column<DateTime>(nullable: false),
                   CompletedAt = table.Column<DateTime>(nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Tasks", x => x.Id);
               });

                // Additional seed data or relationships can be added here if needed.
            }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
