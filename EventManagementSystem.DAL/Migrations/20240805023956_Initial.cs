using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagementSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ERS");

            migrationBuilder.CreateTable(
                name: "Attendee",
                schema: "ERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                schema: "ERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Location = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Organizer = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                schema: "ERS",
                columns: table => new
                {
                    RegistrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    AttendeeId = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.RegistrationId);
                    table.ForeignKey(
                        name: "FK_Registration_Attendee",
                        column: x => x.AttendeeId,
                        principalSchema: "ERS",
                        principalTable: "Attendee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Registration_Event",
                        column: x => x.EventId,
                        principalSchema: "ERS",
                        principalTable: "Event",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "UQ_Attendee_Email",
                schema: "ERS",
                table: "Attendee",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registration_AttendeeId",
                schema: "ERS",
                table: "Registration",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "UQ_Registration_Event_Attendee",
                schema: "ERS",
                table: "Registration",
                columns: new[] { "EventId", "AttendeeId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registration",
                schema: "ERS");

            migrationBuilder.DropTable(
                name: "Attendee",
                schema: "ERS");

            migrationBuilder.DropTable(
                name: "Event",
                schema: "ERS");
        }
    }
}
