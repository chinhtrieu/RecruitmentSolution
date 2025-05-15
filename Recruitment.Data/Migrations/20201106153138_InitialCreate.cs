using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    IdQrCode = table.Column<byte[]>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTimeOffset>(nullable: true),
                    Gender = table.Column<bool>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    UrlAvatar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Job_Jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Position = table.Column<string>(maxLength: 255, nullable: false),
                    Slug = table.Column<string>(nullable: true),
                    ApplicationEmail = table.Column<string>(nullable: true),
                    JobImage = table.Column<string>(nullable: true),
                    JobDetail = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Experience = table.Column<string>(nullable: true),
                    SalaryMin = table.Column<decimal>(nullable: false),
                    SalaryMax = table.Column<decimal>(nullable: false),
                    SalaryUnit = table.Column<string>(nullable: true),
                    WorkTime = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    DealineForSubmission = table.Column<DateTimeOffset>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRoleClaims_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserClaims_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AppUserLogins_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AppUserRoles_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUserRoles_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AppUserTokens_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Introduction = table.Column<string>(nullable: true),
                    Resume = table.Column<string>(nullable: true),
                    CandicateId = table.Column<Guid>(nullable: false),
                    JobId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidates_AppUsers_CandicateId",
                        column: x => x.CandicateId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidates_Job_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Job_Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            var adminGuid = Guid.NewGuid().ToString();
            var recruimentGuid = Guid.NewGuid().ToString();
            var candiateGuid = Guid.NewGuid().ToString();
            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    {adminGuid, Guid.NewGuid().ToString(), "Administrator role", "Admin", "ADMIN" },
                    { recruimentGuid, Guid.NewGuid().ToString(), "Recruitment role", "Recruitment", "RECRUITMENT" },
                    { candiateGuid, Guid.NewGuid().ToString(), "Recruitment role", "Candidate", "Candidate" }
                });
            var chinhtcGuid = Guid.NewGuid().ToString();
            var duynk006Guid = Guid.NewGuid().ToString();
            var hiepdt004Guid = Guid.NewGuid().ToString();
            var dungpm003Guid = Guid.NewGuid().ToString();
            var linhpp002Guid = Guid.NewGuid().ToString();
            var quanghm004Guid = Guid.NewGuid().ToString();
            var tienlv005Guid = Guid.NewGuid().ToString();
            var anhnd026Guid = Guid.NewGuid().ToString();
            var anhntl028Guid = Guid.NewGuid().ToString();
            var anhntl029Guid = Guid.NewGuid().ToString();

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Comment", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "FullName", "Gender", "IdQrCode", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UrlAvatar", "UserName" },
                values: new object[,]
                {
                    { chinhtcGuid , 0, null, null, Guid.NewGuid().ToString(), null, "chinhtc@gmail.com",     true, "Chính",  "Triệu Công Chính", null, null,     "Triệu Công",   false, null, "CHINHTC@GMAIL.COM", "CHINHTC@GMAIL.COM", "AQAAAAEAACcQAAAAEGtJMAJDVg4TayMQ5nKGyvQZ2Z4RzfhDbJFJQUB5P3nLpjPOxHPOyYGRg7QLLANa1Q==", null, false, "", false, "client/assets/img/avt1.jpg", "chinhtc@gmail.com" },
                    { duynk006Guid, 0, null, null, Guid.NewGuid().ToString(), null, "duynk006@gmail.com",    true, "Duy",    "Nguyễn Khánh Duy",     null, null, "Nguyễn Khánh", false, null, "DUNGPM003@GMAIL.COM", "DUNGPM003@GMAIL.COM", "AQAAAAEAACcQAAAAEFDU/sWiW4YEnZZOd7ZCfput+Js7gft94vhhKJs24TOQ3fm+jJhc2U8dkMhvGU2itw==", null, false, "", false, "client/assets/img/avt2.jpg", "duynk006@gmail.com" },
                    { hiepdt004Guid , 0, null, null, Guid.NewGuid().ToString(), null, "hiepdt004@gmail.com",   true, "Hiệp",   "Đinh Trung Hiệp",  null, null,     "Đinh Trung",   false, null, "DUYNK006@GMAIL.COM", "DUYNK006@GMAIL.COM", "AQAAAAEAACcQAAAAECWRVipKuYhGdi9bfDjX5B/jeTzpsolVIM24LUlTDmuIYUjc/OmRh5wefe8fQkq5Ww==", null, false, "", false, "client/assets/img/avt3.jpg", "hiepdt004@gmail.com" },
                    { dungpm003Guid , 0, null, null, Guid.NewGuid().ToString(), null, "dungpm003@gmail.com",   true, "Dũng",   "Phan Majnh Dũng",  null, null,     "Phan Majnh",  false, null, "HIEPDT004@GMAIL.COM", "HIEPDT004@GMAIL.COM", "AQAAAAEAACcQAAAAEEqOJpNhlemJNQsZjoqd6f4Ok8PFu9CCtflJVxQNGpMxab5vQDGCg0rgPGbkHmFfuA==", null, false, "", false, "client/assets/img/avt4.jpg", "dungpm003@gmail.com" },
                    { linhpp002Guid , 0, null, null, Guid.NewGuid().ToString(), null, "linhpp002@gmail.com",   true, "Linh",   "Phạm Phương Linh",     null, null, "Phạm Phương", false, null, "LINHPP002@GMAIL.COM", "LINHPP002@GMAIL.COM", "AQAAAAEAACcQAAAAEI1tcf8JUegR2jLLIVO182+FQLL9oGmi22kxN88iOvaDjoCtzf9ubo1AUo3lDIYFRQ==", null, false, "", false, "client/assets/img/avt5.jpg", "linhpp002@gmail.com" },
                    { quanghm004Guid, 0, null, null, Guid.NewGuid().ToString(), null, "quanghm004@gmail.com",  true, "Quang",  "Hà Minh Quang",    null, null,     "Hà Minh",     false, null, "QUANGHM004@GMAIL.COM", "QUANGHM004@GMAIL.COM", "AQAAAAEAACcQAAAAEK5ufmVYv2CsuZ2MVbA2HfcAoAZ5hOtaDkOV+QuKQ5Gy9Pnqu8D32QTuhROGsbnunA==", null, false, "", false, "client/assets/img/avt6.jpg", "QUANGHM004@gmail.com" },
                    { tienlv005Guid , 0, null, null, Guid.NewGuid().ToString(), null, "tienlv005@gmail.com",   true, "Tiến",   "Lê Văn Tiến",      null, null,     "Lê Văn",       false, null, "TIENLV005@GMAIL.COM", "TIENLV005@GMAIL.COM", "AQAAAAEAACcQAAAAEK5ufmVYv2CsuZ2MVbA2HfcAoAZ5hOtaDkOV+QuKQ5Gy9Pnqu8D32QTuhROGsbnunA==", null, false, "", false, "client/assets/img/avt6.jpg", "tienlv005@gmail.com" },
                    { anhnd026Guid, 0, null, null, Guid.NewGuid().ToString(), null, "anhnd026@gmail.com",    true, "DucAnh", "Nguyễn Đức Anh",   null, null,     "Nguyễn Đức",    false, null, "ANHND026@GMAIL.COM", "ANHND026@GMAIL.COM", "AQAAAAEAACcQAAAAEK5ufmVYv2CsuZ2MVbA2HfcAoAZ5hOtaDkOV+QuKQ5Gy9Pnqu8D32QTuhROGsbnunA==", null, false, "", false, "client/assets/img/avt6.jpg", "anhnd026@gmail.com" },
                    { anhntl028Guid , 0, null, null, Guid.NewGuid().ToString(), null, "anhntl028@gmail.com",   true, "LanAnh1","Nguyễn Thị Lan Anh",   null, null, "Nguyễn Thị", false, null, "ANHNTL028@GMAIL.COM", "ANHNTL028@GMAIL.COM", "AQAAAAEAACcQAAAAEK5ufmVYv2CsuZ2MVbA2HfcAoAZ5hOtaDkOV+QuKQ5Gy9Pnqu8D32QTuhROGsbnunA==", null, false, "", false, "client/assets/img/avt6.jpg", "anhntl028@gmail.com" }  ,
                    { anhntl029Guid , 0, null, null, Guid.NewGuid().ToString(), null, "anhntl029@gmail.com",   true, "LanAnh2","Nguyễn Thị Lan Anh",   null, null, "Nguyễn Thị", false, null, "ANHNTL029@GMAIL.COM", "ANHNTL029@GMAIL.COM", "AQAAAAEAACcQAAAAEK5ufmVYv2CsuZ2MVbA2HfcAoAZ5hOtaDkOV+QuKQ5Gy9Pnqu8D32QTuhROGsbnunA==", null, false, "", false, "client/assets/img/avt6.jpg", "anhntl029@gmail.com" }

                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { chinhtcGuid,  adminGuid },
                    { duynk006Guid,  adminGuid },
                    { hiepdt004Guid, adminGuid },
                    { dungpm003Guid, adminGuid },
                    { linhpp002Guid, adminGuid },
                    { quanghm004Guid, adminGuid },
                    { tienlv005Guid, adminGuid },
                    { anhnd026Guid, adminGuid },
                    { anhntl028Guid, adminGuid },
                    { anhntl029Guid, adminGuid },
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleClaims_RoleId",
                table: "AppRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AppRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserClaims_UserId",
                table: "AppUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_RoleId",
                table: "AppUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AppUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AppUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_CandicateId",
                table: "Candidates",
                column: "CandicateId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_JobId",
                table: "Candidates",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Job_Jobs");
        }
    }
}
