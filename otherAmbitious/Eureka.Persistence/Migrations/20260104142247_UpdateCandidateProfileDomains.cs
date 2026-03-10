using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eureka.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCandidateProfileDomains : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_application_documents_applications_ApplicationId",
                table: "application_documents");

            migrationBuilder.DropForeignKey(
                name: "FK_application_documents_candidate_documents_CandidateDocumentId",
                table: "application_documents");

            migrationBuilder.DropForeignKey(
                name: "FK_applications_job_offers_JobOfferId",
                table: "applications");

            migrationBuilder.DropForeignKey(
                name: "FK_applications_users_CandidateUserId",
                table: "applications");

            migrationBuilder.DropForeignKey(
                name: "FK_candidate_activity_domains_activity_domains_ActivityDomainId",
                table: "candidate_activity_domains");

            migrationBuilder.DropForeignKey(
                name: "FK_candidate_activity_domains_candidate_profiles_CandidateUserId",
                table: "candidate_activity_domains");

            migrationBuilder.DropForeignKey(
                name: "FK_candidate_documents_candidate_profiles_CandidateUserId",
                table: "candidate_documents");

            migrationBuilder.DropForeignKey(
                name: "FK_candidate_profiles_users_UserId",
                table: "candidate_profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_applications",
                table: "applications");

            migrationBuilder.DropIndex(
                name: "IX_applications_CandidateUserId_CreatedAt",
                table: "applications");

            migrationBuilder.DropIndex(
                name: "IX_applications_JobOfferId_Status_CreatedAt",
                table: "applications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_candidate_profiles",
                table: "candidate_profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_candidate_documents",
                table: "candidate_documents");

            migrationBuilder.DropIndex(
                name: "IX_candidate_documents_CandidateUserId",
                table: "candidate_documents");

            migrationBuilder.DropIndex(
                name: "IX_candidate_documents_CandidateUserId_IsDefault",
                table: "candidate_documents");

            migrationBuilder.DropIndex(
                name: "IX_candidate_documents_CandidateUserId_Type",
                table: "candidate_documents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_candidate_activity_domains",
                table: "candidate_activity_domains");

            migrationBuilder.DropPrimaryKey(
                name: "PK_application_documents",
                table: "application_documents");

            migrationBuilder.RenameTable(
                name: "applications",
                newName: "Applications");

            migrationBuilder.RenameTable(
                name: "candidate_profiles",
                newName: "CandidateProfiles");

            migrationBuilder.RenameTable(
                name: "candidate_documents",
                newName: "CandidateDocuments");

            migrationBuilder.RenameTable(
                name: "candidate_activity_domains",
                newName: "CandidateActivityDomains");

            migrationBuilder.RenameTable(
                name: "application_documents",
                newName: "ApplicationDocuments");

            migrationBuilder.RenameIndex(
                name: "IX_applications_JobOfferId_CandidateUserId",
                table: "Applications",
                newName: "IX_Applications_JobOfferId_CandidateUserId");

            migrationBuilder.RenameIndex(
                name: "IX_candidate_activity_domains_ActivityDomainId",
                table: "CandidateActivityDomains",
                newName: "IX_CandidateActivityDomains_ActivityDomainId");

            migrationBuilder.RenameIndex(
                name: "IX_application_documents_CandidateDocumentId",
                table: "ApplicationDocuments",
                newName: "IX_ApplicationDocuments_CandidateDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_application_documents_ApplicationId_CandidateDocumentId",
                table: "ApplicationDocuments",
                newName: "IX_ApplicationDocuments_ApplicationId_CandidateDocumentId");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Applications",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<Guid>(
                name: "JobOfferId1",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                table: "CandidateProfiles",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Commune",
                table: "CandidateProfiles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "CandidateDocuments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "CandidateDocuments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StorageUrl",
                table: "CandidateDocuments",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateProfiles",
                table: "CandidateProfiles",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateDocuments",
                table: "CandidateDocuments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateActivityDomains",
                table: "CandidateActivityDomains",
                columns: new[] { "CandidateUserId", "ActivityDomainId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationDocuments",
                table: "ApplicationDocuments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CandidateUserId",
                table: "Applications",
                column: "CandidateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobOfferId1",
                table: "Applications",
                column: "JobOfferId1");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserId",
                table: "Applications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateDocuments_CandidateUserId",
                table: "CandidateDocuments",
                column: "CandidateUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationDocuments_Applications_ApplicationId",
                table: "ApplicationDocuments",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationDocuments_CandidateDocuments_CandidateDocumentId",
                table: "ApplicationDocuments",
                column: "CandidateDocumentId",
                principalTable: "CandidateDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_CandidateProfiles_CandidateUserId",
                table: "Applications",
                column: "CandidateUserId",
                principalTable: "CandidateProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_job_offers_JobOfferId",
                table: "Applications",
                column: "JobOfferId",
                principalTable: "job_offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_job_offers_JobOfferId1",
                table: "Applications",
                column: "JobOfferId1",
                principalTable: "job_offers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_users_UserId",
                table: "Applications",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateActivityDomains_CandidateProfiles_CandidateUserId",
                table: "CandidateActivityDomains",
                column: "CandidateUserId",
                principalTable: "CandidateProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateActivityDomains_activity_domains_ActivityDomainId",
                table: "CandidateActivityDomains",
                column: "ActivityDomainId",
                principalTable: "activity_domains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateDocuments_CandidateProfiles_CandidateUserId",
                table: "CandidateDocuments",
                column: "CandidateUserId",
                principalTable: "CandidateProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateProfiles_users_UserId",
                table: "CandidateProfiles",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationDocuments_Applications_ApplicationId",
                table: "ApplicationDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationDocuments_CandidateDocuments_CandidateDocumentId",
                table: "ApplicationDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_CandidateProfiles_CandidateUserId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_job_offers_JobOfferId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_job_offers_JobOfferId1",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_users_UserId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateActivityDomains_CandidateProfiles_CandidateUserId",
                table: "CandidateActivityDomains");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateActivityDomains_activity_domains_ActivityDomainId",
                table: "CandidateActivityDomains");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateDocuments_CandidateProfiles_CandidateUserId",
                table: "CandidateDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateProfiles_users_UserId",
                table: "CandidateProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_CandidateUserId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_JobOfferId1",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_UserId",
                table: "Applications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateProfiles",
                table: "CandidateProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateDocuments",
                table: "CandidateDocuments");

            migrationBuilder.DropIndex(
                name: "IX_CandidateDocuments_CandidateUserId",
                table: "CandidateDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateActivityDomains",
                table: "CandidateActivityDomains");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationDocuments",
                table: "ApplicationDocuments");

            migrationBuilder.DropColumn(
                name: "JobOfferId1",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Applications");

            migrationBuilder.RenameTable(
                name: "Applications",
                newName: "applications");

            migrationBuilder.RenameTable(
                name: "CandidateProfiles",
                newName: "candidate_profiles");

            migrationBuilder.RenameTable(
                name: "CandidateDocuments",
                newName: "candidate_documents");

            migrationBuilder.RenameTable(
                name: "CandidateActivityDomains",
                newName: "candidate_activity_domains");

            migrationBuilder.RenameTable(
                name: "ApplicationDocuments",
                newName: "application_documents");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_JobOfferId_CandidateUserId",
                table: "applications",
                newName: "IX_applications_JobOfferId_CandidateUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateActivityDomains_ActivityDomainId",
                table: "candidate_activity_domains",
                newName: "IX_candidate_activity_domains_ActivityDomainId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationDocuments_CandidateDocumentId",
                table: "application_documents",
                newName: "IX_application_documents_CandidateDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationDocuments_ApplicationId_CandidateDocumentId",
                table: "application_documents",
                newName: "IX_application_documents_ApplicationId_CandidateDocumentId");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "applications",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                table: "candidate_profiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Commune",
                table: "candidate_profiles",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "candidate_documents",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "candidate_documents",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StorageUrl",
                table: "candidate_documents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AddPrimaryKey(
                name: "PK_applications",
                table: "applications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_candidate_profiles",
                table: "candidate_profiles",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_candidate_documents",
                table: "candidate_documents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_candidate_activity_domains",
                table: "candidate_activity_domains",
                columns: new[] { "CandidateUserId", "ActivityDomainId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_application_documents",
                table: "application_documents",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_applications_CandidateUserId_CreatedAt",
                table: "applications",
                columns: new[] { "CandidateUserId", "CreatedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_applications_JobOfferId_Status_CreatedAt",
                table: "applications",
                columns: new[] { "JobOfferId", "Status", "CreatedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_candidate_documents_CandidateUserId",
                table: "candidate_documents",
                column: "CandidateUserId",
                unique: true,
                filter: "[IsDefault] = 1 AND [Type] = 'CV'");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_documents_CandidateUserId_IsDefault",
                table: "candidate_documents",
                columns: new[] { "CandidateUserId", "IsDefault" });

            migrationBuilder.CreateIndex(
                name: "IX_candidate_documents_CandidateUserId_Type",
                table: "candidate_documents",
                columns: new[] { "CandidateUserId", "Type" });

            migrationBuilder.AddForeignKey(
                name: "FK_application_documents_applications_ApplicationId",
                table: "application_documents",
                column: "ApplicationId",
                principalTable: "applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_application_documents_candidate_documents_CandidateDocumentId",
                table: "application_documents",
                column: "CandidateDocumentId",
                principalTable: "candidate_documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_applications_job_offers_JobOfferId",
                table: "applications",
                column: "JobOfferId",
                principalTable: "job_offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_applications_users_CandidateUserId",
                table: "applications",
                column: "CandidateUserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_candidate_activity_domains_activity_domains_ActivityDomainId",
                table: "candidate_activity_domains",
                column: "ActivityDomainId",
                principalTable: "activity_domains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_candidate_activity_domains_candidate_profiles_CandidateUserId",
                table: "candidate_activity_domains",
                column: "CandidateUserId",
                principalTable: "candidate_profiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_candidate_documents_candidate_profiles_CandidateUserId",
                table: "candidate_documents",
                column: "CandidateUserId",
                principalTable: "candidate_profiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_candidate_profiles_users_UserId",
                table: "candidate_profiles",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
