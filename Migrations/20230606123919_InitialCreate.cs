using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace outrusive.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reflections",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Assumptions = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Evidence = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    EvidenceAgainst = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FactOrFeeling = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    HabitOrFact = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Exaggeration = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    BlackAndWhite = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    LikelyOrWorstCase = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    OnlyConsideringSupportingEvidence = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    OtherInterpretations = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Source = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Thought = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reflections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reflections");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
