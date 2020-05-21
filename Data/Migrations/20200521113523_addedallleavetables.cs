using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leave_Management.Data.Migrations
{
    public partial class addedallleavetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Leave_Type",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Leave_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Leave_Allocation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfDays = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: true),
                    LeaveId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Leave_Allocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Leave_Allocation_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_Leave_Allocation_tbl_Leave_Type_LeaveId",
                        column: x => x.LeaveId,
                        principalTable: "tbl_Leave_Type",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_Leave_History",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestingEmployeeId = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    LeaveTypeId = table.Column<int>(nullable: false),
                    DateRequested = table.Column<DateTime>(nullable: false),
                    DateActioned = table.Column<DateTime>(nullable: false),
                    Approved = table.Column<bool>(nullable: true),
                    ApprovedById = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Leave_History", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Leave_History_AspNetUsers_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Leave_History_tbl_Leave_Type_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "tbl_Leave_Type",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_Leave_History_AspNetUsers_RequestingEmployeeId",
                        column: x => x.RequestingEmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Leave_Allocation_EmployeeId",
                table: "tbl_Leave_Allocation",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Leave_Allocation_LeaveId",
                table: "tbl_Leave_Allocation",
                column: "LeaveId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Leave_History_ApprovedById",
                table: "tbl_Leave_History",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Leave_History_LeaveTypeId",
                table: "tbl_Leave_History",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Leave_History_RequestingEmployeeId",
                table: "tbl_Leave_History",
                column: "RequestingEmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Leave_Allocation");

            migrationBuilder.DropTable(
                name: "tbl_Leave_History");

            migrationBuilder.DropTable(
                name: "tbl_Leave_Type");
        }
    }
}
