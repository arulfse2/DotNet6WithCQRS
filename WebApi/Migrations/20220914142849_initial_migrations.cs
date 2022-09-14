using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class initial_migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    EstablishedYear = table.Column<string>(type: "text", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: false),
                    AddedBy = table.Column<string>(type: "text", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    JoiningYear = table.Column<string>(type: "text", nullable: false),
                    Designation = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: false),
                    AddedBy = table.Column<string>(type: "text", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_Employee",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "AddedBy", "AddedDate", "EstablishedYear", "Name", "Status", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("7cf02d2b-0190-41b9-a8f0-66df080337cc"), "ADMIN", new DateTime(2022, 9, 14, 14, 28, 48, 577, DateTimeKind.Utc).AddTicks(900), "1994", "Cognizant Technology Solutions", 1, "ADMIN", new DateTime(2022, 9, 14, 14, 28, 48, 577, DateTimeKind.Utc).AddTicks(895) },
                    { new Guid("83bb4320-0d51-4c77-ba50-e30c4b287d4a"), "ADMIN", new DateTime(2022, 9, 14, 14, 28, 48, 577, DateTimeKind.Utc).AddTicks(909), "1945", "Wipro Ltd", 1, "ADMIN", new DateTime(2022, 9, 14, 14, 28, 48, 577, DateTimeKind.Utc).AddTicks(908) }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AddedBy", "AddedDate", "CompanyId", "Designation", "EmployeeId", "JoiningYear", "Name", "Status", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("31847449-3d22-4997-a08c-58de55c45370"), "ADMIN", new DateTime(2022, 9, 14, 14, 28, 48, 577, DateTimeKind.Utc).AddTicks(1138), new Guid("7cf02d2b-0190-41b9-a8f0-66df080337cc"), "Senior Software Engineer", "CTS2", "2016", "Saravanan", 1, "ADMIN", new DateTime(2022, 9, 14, 14, 28, 48, 577, DateTimeKind.Utc).AddTicks(1137) },
                    { new Guid("64a85cc8-59ee-4161-aec4-4fdc8e709bab"), "ADMIN", new DateTime(2022, 9, 14, 14, 28, 48, 577, DateTimeKind.Utc).AddTicks(1142), new Guid("83bb4320-0d51-4c77-ba50-e30c4b287d4a"), "Manager", "WIP1", "2016", "Suresh", 1, "ADMIN", new DateTime(2022, 9, 14, 14, 28, 48, 577, DateTimeKind.Utc).AddTicks(1141) },
                    { new Guid("c93d8b8e-1dc0-4290-982b-ed83893dca37"), "ADMIN", new DateTime(2022, 9, 14, 14, 28, 48, 577, DateTimeKind.Utc).AddTicks(1132), new Guid("7cf02d2b-0190-41b9-a8f0-66df080337cc"), "Senior Software Engineer", "CTS1", "2016", "Arulprakash Subramanian", 1, "ADMIN", new DateTime(2022, 9, 14, 14, 28, 48, 577, DateTimeKind.Utc).AddTicks(1132) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
