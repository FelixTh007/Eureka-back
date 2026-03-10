using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eureka.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateApplicationConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_job_offers_JobOfferId1",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_JobOfferId1",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "JobOfferId1",
                table: "Applications");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "JobOfferId1",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobOfferId1",
                table: "Applications",
                column: "JobOfferId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_job_offers_JobOfferId1",
                table: "Applications",
                column: "JobOfferId1",
                principalTable: "job_offers",
                principalColumn: "Id");
        }
    }
}
