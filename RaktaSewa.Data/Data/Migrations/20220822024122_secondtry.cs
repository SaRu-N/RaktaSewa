using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaktaSewa.Data.Migrations
{
    public partial class secondtry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DonorName",
                table: "Citizens",
                newName: "Seeker_Amount");

            migrationBuilder.AddColumn<int>(
                name: "Address",
                table: "Organizations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "Organizations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Organizations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_At",
                table: "Organizations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Amount",
                table: "Citizens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "Citizens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Citizens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Citizens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HospitalId",
                table: "Citizens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Citizens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Patient_Address",
                table: "Citizens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Patient_Age",
                table: "Citizens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Patient_BloodGroup",
                table: "Citizens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Seeker_Created_At",
                table: "Citizens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Seeker_Updated_At",
                table: "Citizens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_At",
                table: "Citizens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isEligible",
                table: "Citizens",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "Bloods",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_At",
                table: "Bloods",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citizens_EventId",
                table: "Citizens",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Citizens_HospitalId",
                table: "Citizens",
                column: "HospitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citizens_Event_EventId",
                table: "Citizens",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Citizens_Hospitals_HospitalId",
                table: "Citizens",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citizens_Event_EventId",
                table: "Citizens");

            migrationBuilder.DropForeignKey(
                name: "FK_Citizens_Hospitals_HospitalId",
                table: "Citizens");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Citizens_EventId",
                table: "Citizens");

            migrationBuilder.DropIndex(
                name: "IX_Citizens_HospitalId",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Updated_At",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "Patient_Address",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "Patient_Age",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "Patient_BloodGroup",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "Seeker_Created_At",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "Seeker_Updated_At",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "Updated_At",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "isEligible",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "Bloods");

            migrationBuilder.DropColumn(
                name: "Updated_At",
                table: "Bloods");

            migrationBuilder.RenameColumn(
                name: "Seeker_Amount",
                table: "Citizens",
                newName: "DonorName");
        }
    }
}
