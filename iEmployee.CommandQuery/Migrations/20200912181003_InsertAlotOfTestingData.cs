using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iEmployee.CommandQuery.Migrations
{
    public partial class InsertAlotOfTestingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("04b260df-ea43-491d-ba68-b0d5b775d7cf"), "D", "Developer" },
                    { new Guid("91d2269c-8a61-4356-a1b3-9460d86108de"), "F", "Fullstack" },
                    { new Guid("6d485caa-67c7-45e6-a4b4-3652bfa09151"), "P", "Patron" },
                    { new Guid("c8804910-7246-4896-a22b-db8789763cd4"), "I", "Inspector" },
                    { new Guid("041c6e60-0495-47e0-a4d5-997e46847901"), "A", "Architect" },
                    { new Guid("8f799fea-9d7a-4245-8461-1c8dacd334fd"), "T", "Tester" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("bd990d9e-e835-4fdc-acfc-84cbd0abb9a4"), ".NET CRUD" },
                    { new Guid("36b27ef9-33f6-499e-9f08-96614b055c55"), "Java Mastering Classes" },
                    { new Guid("4021e9a4-1c5e-454d-b272-c0fafe29c8cd"), "DRINKING COFFER" },
                    { new Guid("cb0817cc-399e-459b-924c-f77d6e2d5a66"), "Mobile app" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("041c6e60-0495-47e0-a4d5-997e46847901"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("04b260df-ea43-491d-ba68-b0d5b775d7cf"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("6d485caa-67c7-45e6-a4b4-3652bfa09151"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("8f799fea-9d7a-4245-8461-1c8dacd334fd"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("91d2269c-8a61-4356-a1b3-9460d86108de"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("c8804910-7246-4896-a22b-db8789763cd4"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("36b27ef9-33f6-499e-9f08-96614b055c55"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("4021e9a4-1c5e-454d-b272-c0fafe29c8cd"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("bd990d9e-e835-4fdc-acfc-84cbd0abb9a4"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("cb0817cc-399e-459b-924c-f77d6e2d5a66"));
        }
    }
}
