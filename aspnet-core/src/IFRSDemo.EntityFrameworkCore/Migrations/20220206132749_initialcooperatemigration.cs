using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IFRSDemo.Migrations
{
    public partial class initialcooperatemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbpAuditLogs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    ServiceName = table.Column<string>(maxLength: 256, nullable: true),
                    MethodName = table.Column<string>(maxLength: 256, nullable: true),
                    Parameters = table.Column<string>(maxLength: 1024, nullable: true),
                    ReturnValue = table.Column<string>(nullable: true),
                    ExecutionTime = table.Column<DateTime>(nullable: false),
                    ExecutionDuration = table.Column<int>(nullable: false),
                    ClientIpAddress = table.Column<string>(maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(maxLength: 128, nullable: true),
                    BrowserInfo = table.Column<string>(maxLength: 512, nullable: true),
                    Exception = table.Column<string>(maxLength: 2000, nullable: true),
                    ImpersonatorUserId = table.Column<long>(nullable: true),
                    ImpersonatorTenantId = table.Column<int>(nullable: true),
                    CustomData = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpAuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpBackgroundJobs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    JobType = table.Column<string>(maxLength: 512, nullable: false),
                    JobArgs = table.Column<string>(maxLength: 1048576, nullable: false),
                    TryCount = table.Column<short>(nullable: false),
                    NextTryTime = table.Column<DateTime>(nullable: false),
                    LastTryTime = table.Column<DateTime>(nullable: true),
                    IsAbandoned = table.Column<bool>(nullable: false),
                    Priority = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpBackgroundJobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpDynamicProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyName = table.Column<string>(nullable: true),
                    InputType = table.Column<string>(nullable: true),
                    Permission = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpDynamicProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpEditions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 64, nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ExpiringEditionId = table.Column<int>(nullable: true),
                    DailyPrice = table.Column<decimal>(nullable: true),
                    WeeklyPrice = table.Column<decimal>(nullable: true),
                    MonthlyPrice = table.Column<decimal>(nullable: true),
                    AnnualPrice = table.Column<decimal>(nullable: true),
                    TrialDayCount = table.Column<int>(nullable: true),
                    WaitingDayAfterExpire = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpEntityChangeSets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrowserInfo = table.Column<string>(maxLength: 512, nullable: true),
                    ClientIpAddress = table.Column<string>(maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(maxLength: 128, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ExtensionData = table.Column<string>(nullable: true),
                    ImpersonatorTenantId = table.Column<int>(nullable: true),
                    ImpersonatorUserId = table.Column<long>(nullable: true),
                    Reason = table.Column<string>(maxLength: 256, nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityChangeSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 64, nullable: false),
                    Icon = table.Column<string>(maxLength: 128, nullable: true),
                    IsDisabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpLanguageTexts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    LanguageName = table.Column<string>(maxLength: 128, nullable: false),
                    Source = table.Column<string>(maxLength: 128, nullable: false),
                    Key = table.Column<string>(maxLength: 256, nullable: false),
                    Value = table.Column<string>(maxLength: 67108864, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpLanguageTexts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    NotificationName = table.Column<string>(maxLength: 96, nullable: false),
                    Data = table.Column<string>(maxLength: 1048576, nullable: true),
                    DataTypeName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityTypeName = table.Column<string>(maxLength: 250, nullable: true),
                    EntityTypeAssemblyQualifiedName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityId = table.Column<string>(maxLength: 96, nullable: true),
                    Severity = table.Column<byte>(nullable: false),
                    UserIds = table.Column<string>(maxLength: 131072, nullable: true),
                    ExcludedUserIds = table.Column<string>(maxLength: 131072, nullable: true),
                    TenantIds = table.Column<string>(maxLength: 131072, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpNotificationSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    NotificationName = table.Column<string>(maxLength: 96, nullable: true),
                    EntityTypeName = table.Column<string>(maxLength: 250, nullable: true),
                    EntityTypeAssemblyQualifiedName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityId = table.Column<string>(maxLength: 96, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpNotificationSubscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpOrganizationUnitRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    OrganizationUnitId = table.Column<long>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpOrganizationUnitRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpOrganizationUnits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    ParentId = table.Column<long>(nullable: true),
                    Code = table.Column<string>(maxLength: 95, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpOrganizationUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpOrganizationUnits_AbpOrganizationUnits_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AbpOrganizationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpPersistedGrants",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 200, nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpPersistedGrants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpTenantNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    NotificationName = table.Column<string>(maxLength: 96, nullable: false),
                    Data = table.Column<string>(maxLength: 1048576, nullable: true),
                    DataTypeName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityTypeName = table.Column<string>(maxLength: 250, nullable: true),
                    EntityTypeAssemblyQualifiedName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityId = table.Column<string>(maxLength: 96, nullable: true),
                    Severity = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpTenantNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    UserLinkId = table.Column<long>(nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserLoginAttempts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    TenancyName = table.Column<string>(maxLength: 64, nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    UserNameOrEmailAddress = table.Column<string>(maxLength: 256, nullable: true),
                    ClientIpAddress = table.Column<string>(maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(maxLength: 128, nullable: true),
                    BrowserInfo = table.Column<string>(maxLength: 512, nullable: true),
                    Result = table.Column<byte>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserLoginAttempts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    TenantNotificationId = table.Column<Guid>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpUsers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    AuthenticationSource = table.Column<string>(maxLength: 64, nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Surname = table.Column<string>(maxLength: 64, nullable: false),
                    Password = table.Column<string>(maxLength: 128, nullable: false),
                    EmailConfirmationCode = table.Column<string>(maxLength: 328, nullable: true),
                    PasswordResetCode = table.Column<string>(maxLength: 328, nullable: true),
                    LockoutEndDateUtc = table.Column<DateTime>(nullable: true),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    IsLockoutEnabled = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 32, nullable: true),
                    IsPhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(maxLength: 128, nullable: true),
                    IsTwoFactorEnabled = table.Column<bool>(nullable: false),
                    IsEmailConfirmed = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: false),
                    NormalizedEmailAddress = table.Column<string>(maxLength: 256, nullable: false),
                    ConcurrencyStamp = table.Column<string>(maxLength: 128, nullable: true),
                    ProfilePictureId = table.Column<Guid>(nullable: true),
                    ShouldChangePasswordOnNextLogin = table.Column<bool>(nullable: false),
                    SignInTokenExpireTimeUtc = table.Column<DateTime>(nullable: true),
                    SignInToken = table.Column<string>(nullable: true),
                    GoogleAuthenticatorKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpUsers_AbpUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpUsers_AbpUsers_DeleterUserId",
                        column: x => x.DeleterUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpUsers_AbpUsers_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpWebhookEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WebhookName = table.Column<string>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpWebhookEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpWebhookSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    WebhookUri = table.Column<string>(nullable: false),
                    Secret = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Webhooks = table.Column<string>(nullable: true),
                    Headers = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpWebhookSubscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "account_bal_data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(150)", nullable: true),
                    Age = table.Column<int>(nullable: true),
                    Income = table.Column<int>(nullable: true),
                    Rent_Range = table.Column<int>(nullable: true),
                    Rent_Income = table.Column<int>(nullable: true),
                    ROA = table.Column<int>(nullable: true),
                    Sector = table.Column<int>(nullable: true),
                    Location = table.Column<int>(nullable: true),
                    DTSR = table.Column<int>(nullable: true),
                    OutBal = table.Column<double>(nullable: true),
                    coverage = table.Column<double>(nullable: true),
                    bal_other_fi = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_bal_data", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgeGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    AgeGroup = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    NumberOfLoans = table.Column<double>(nullable: false),
                    NumberOfBadLoans = table.Column<double>(nullable: false),
                    NumberOfGoodLoans = table.Column<double>(nullable: false),
                    BadLoanPerc = table.Column<double>(nullable: false),
                    BinGroup = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    DB = table.Column<double>(nullable: false),
                    DG = table.Column<double>(nullable: false),
                    WOE = table.Column<double>(nullable: false),
                    DG_DB = table.Column<double>(nullable: false),
                    WoeDGBG = table.Column<double>(nullable: false),
                    ScoreAfterReg = table.Column<double>(nullable: false),
                    ScorePoint = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AllScores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ln = table.Column<long>(type: "bigint", nullable: true),
                    Group = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Pd = table.Column<double>(nullable: false),
                    Score = table.Column<double>(nullable: false),
                    Item = table.Column<int>(nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllScores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppBinaryObjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Bytes = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBinaryObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppChatMessages",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    TargetUserId = table.Column<long>(nullable: false),
                    TargetTenantId = table.Column<int>(nullable: true),
                    Message = table.Column<string>(maxLength: 4096, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Side = table.Column<int>(nullable: false),
                    ReadState = table.Column<int>(nullable: false),
                    ReceiverReadState = table.Column<int>(nullable: false),
                    SharedMessageId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppChatMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppFriendships",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    FriendUserId = table.Column<long>(nullable: false),
                    FriendTenantId = table.Column<int>(nullable: true),
                    FriendUserName = table.Column<string>(maxLength: 256, nullable: false),
                    FriendTenancyName = table.Column<string>(nullable: true),
                    FriendProfilePictureId = table.Column<Guid>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFriendships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNo = table.Column<string>(nullable: true),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    TenantLegalName = table.Column<string>(nullable: true),
                    TenantAddress = table.Column<string>(nullable: true),
                    TenantTaxNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppInvoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Applicant_with_Accno",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Applicant_With_Accno = table.Column<string>(type: "nvarchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicant_with_Accno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppSubscriptionPaymentsExtensionData",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionPaymentId = table.Column<long>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSubscriptionPaymentsExtensionData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ApplicanType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserDelegations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SourceUserId = table.Column<long>(nullable: false),
                    TargetUserId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserDelegations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "collectAttribute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attributes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collectAttribute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "credit_preprocessingb",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    num_null = table.Column<int>(nullable: false),
                    outl_ier = table.Column<double>(nullable: false),
                    components = table.Column<string>(nullable: true),
                    num = table.Column<int>(nullable: false),
                    combination = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_credit_preprocessingb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditScore_CutOff",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CutOff = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditScore_CutOff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditScore_DescriptiveStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Variable = table.Column<string>(type: "varchar(250)", nullable: true),
                    NumberOfdate = table.Column<double>(nullable: false),
                    Mean = table.Column<double>(nullable: false),
                    Median = table.Column<double>(nullable: false),
                    StdDeviation = table.Column<double>(nullable: false),
                    RootMeansSquare = table.Column<double>(nullable: false),
                    StdErrormean = table.Column<double>(nullable: false),
                    Minimium = table.Column<double>(nullable: false),
                    Maximium = table.Column<double>(nullable: false),
                    Skewnes = table.Column<double>(nullable: false),
                    Kurtosis = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditScore_DescriptiveStatistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditScore_FeatureSelection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Characteristic = table.Column<string>(type: "varchar(250)", nullable: true),
                    IV = table.Column<double>(nullable: false),
                    Inference = table.Column<string>(type: "varchar(250)", nullable: true),
                    SelectStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditScore_FeatureSelection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditScore_LogisticRegEquation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<double>(nullable: false),
                    Resident_Status = table.Column<double>(nullable: false),
                    Product = table.Column<double>(nullable: false),
                    Current_Account_Status = table.Column<double>(nullable: false),
                    Payment_Performance = table.Column<double>(nullable: false),
                    Age_bin = table.Column<double>(nullable: false),
                    Time_at_Job_bin = table.Column<double>(nullable: false),
                    Intercept = table.Column<double>(nullable: false),
                    Mean_Squared_Error = table.Column<double>(nullable: false),
                    Null_Deviance = table.Column<double>(nullable: false),
                    R_Square = table.Column<double>(nullable: false),
                    Residual_Defiance = table.Column<double>(nullable: false),
                    ROC_AUC = table.Column<double>(nullable: false),
                    P_Value = table.Column<double>(nullable: false),
                    Degree_of_Freedom = table.Column<double>(nullable: false),
                    DF_Predictors = table.Column<double>(nullable: false),
                    Degree_of_Freedomb = table.Column<double>(nullable: false),
                    Regression_Defiance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditScore_LogisticRegEquation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditScore_LogisticRegression",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    coefficients = table.Column<double>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditScore_LogisticRegression", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditScore_PointAllocation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attribute = table.Column<string>(nullable: true),
                    Binning = table.Column<string>(nullable: true),
                    WOE = table.Column<double>(nullable: false),
                    Score = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditScore_PointAllocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditScore_ScoreReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Characteristic = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Score = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditScore_ScoreReport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditScore_WOE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Characteristic = table.Column<string>(type: "varchar(250)", nullable: true),
                    Attribute = table.Column<string>(type: "varchar(100)", nullable: true),
                    WOE = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditScore_WOE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CRTD_Population_Stability_Report",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score_Bands = table.Column<string>(nullable: true),
                    Actual = table.Column<double>(nullable: false),
                    Expected = table.Column<double>(nullable: false),
                    Actual_Expected = table.Column<double>(nullable: false),
                    Ln_Actual_Expected = table.Column<double>(nullable: false),
                    INDEX = table.Column<double>(nullable: false),
                    PSI = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRTD_Population_Stability_Report", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CRTD_Roc_Data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuttOff = table.Column<double>(nullable: true),
                    true_positive = table.Column<double>(nullable: true),
                    false_positive = table.Column<double>(nullable: true),
                    Area = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRTD_Roc_Data", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CRTD_Score_Card_Scaling",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParameterGroup = table.Column<string>(nullable: true),
                    ParameterName = table.Column<string>(nullable: true),
                    Score_After_Regression = table.Column<double>(nullable: false),
                    Score_Card_Point = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRTD_Score_Card_Scaling", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "debt_service_ratio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    LB = table.Column<double>(nullable: true),
                    UP = table.Column<double>(nullable: true),
                    amount = table.Column<double>(nullable: true),
                    DTSR = table.Column<int>(nullable: true),
                    coverage = table.Column<string>(type: "varchar(50)", nullable: true),
                    grant_amt = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_debt_service_ratio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncomeAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IncomeRange = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Input_Data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unique_ID = table.Column<string>(type: "varchar(100)", nullable: true),
                    TrainingSample = table.Column<bool>(nullable: false),
                    Date_opened = table.Column<DateTime>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Income = table.Column<decimal>(nullable: false),
                    Location = table.Column<string>(type: "varchar(100)", nullable: true),
                    Resident_status = table.Column<string>(type: "varchar(100)", nullable: true),
                    Time_at_Job = table.Column<double>(nullable: false),
                    Time_at_residence = table.Column<double>(nullable: false),
                    Product = table.Column<string>(type: "varchar(100)", nullable: true),
                    Current_Account_Status = table.Column<string>(type: "varchar(100)", nullable: true),
                    Total_assets = table.Column<decimal>(nullable: false),
                    Rent = table.Column<decimal>(nullable: false),
                    Rent_to_Income = table.Column<double>(nullable: false),
                    Return_on_Assets = table.Column<double>(nullable: false),
                    Time_at_Bank = table.Column<double>(nullable: false),
                    Number_of_products = table.Column<int>(nullable: false),
                    Payment_performance = table.Column<string>(type: "varchar(100)", nullable: true),
                    Previous_claims = table.Column<int>(nullable: false),
                    Good_Bad = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Input_Data", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IV_Table",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Characteristic = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    IV = table.Column<double>(nullable: false),
                    Inference = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IV_Table", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    Customer = table.Column<string>(maxLength: 50, nullable: false),
                    LoanType = table.Column<string>(maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Tenor = table.Column<int>(nullable: false),
                    Statua = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    LocationGroup = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    NumberOfLoans = table.Column<double>(nullable: false),
                    NumberOfBadLoans = table.Column<double>(nullable: false),
                    NumberOfGoodLoans = table.Column<double>(nullable: false),
                    BadLoanPerc = table.Column<double>(nullable: false),
                    BinGroup = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    DB = table.Column<double>(nullable: false),
                    DG = table.Column<double>(nullable: false),
                    WOE = table.Column<double>(nullable: false),
                    DG_DB = table.Column<double>(nullable: false),
                    WoeDGBG = table.Column<double>(nullable: false),
                    ScoreAfterReg = table.Column<double>(nullable: false),
                    ScorePoint = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OperationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Output_table",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unique_ID = table.Column<string>(type: "varchar(100)", nullable: true),
                    TrainingSample = table.Column<bool>(nullable: false),
                    Date_opened = table.Column<DateTime>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Income = table.Column<decimal>(nullable: false),
                    Location = table.Column<string>(type: "varchar(100)", nullable: true),
                    Resident_status = table.Column<string>(type: "varchar(100)", nullable: true),
                    Time_at_Job = table.Column<double>(nullable: false),
                    Time_at_residence = table.Column<double>(nullable: false),
                    Product = table.Column<string>(type: "varchar(100)", nullable: true),
                    Current_Account_Status = table.Column<string>(nullable: true),
                    Total_assets = table.Column<decimal>(nullable: false),
                    Rent = table.Column<decimal>(nullable: false),
                    Rent_to_Income = table.Column<double>(nullable: false),
                    Return_on_Assets = table.Column<double>(nullable: false),
                    Time_at_Bank = table.Column<double>(nullable: false),
                    Number_of_products = table.Column<int>(nullable: false),
                    Payment_performance = table.Column<string>(type: "varchar(100)", nullable: true),
                    Previous_claims = table.Column<int>(nullable: false),
                    Good_Bad = table.Column<bool>(nullable: false),
                    Agebin = table.Column<string>(type: "varchar(50)", nullable: true),
                    Time_at_Jobbin = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Output_table", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypeAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ProductType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypeAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profit_Analysis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AverageLoan = table.Column<decimal>(nullable: true),
                    Profit = table.Column<decimal>(nullable: true),
                    Loss = table.Column<int>(nullable: true),
                    TotalGood = table.Column<int>(nullable: true),
                    TotalBad = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profit_Analysis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualitativeSetups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    Section = table.Column<string>(nullable: true),
                    SubHeading = table.Column<string>(nullable: true),
                    Qualitative = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualitativeSetups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rating_Prediction_Output",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    App_Type = table.Column<string>(nullable: true),
                    Score = table.Column<double>(nullable: true),
                    Risk_Level = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PD = table.Column<double>(nullable: true),
                    Good_Bad_Odd = table.Column<double>(nullable: true),
                    Debt_Income_Ratio = table.Column<double>(nullable: true),
                    Interest_Rate = table.Column<double>(nullable: true),
                    Recommendation = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating_Prediction_Output", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    RentGroup = table.Column<string>(nullable: true),
                    NumberOfLoans = table.Column<double>(nullable: false),
                    NumberOfBadLoans = table.Column<double>(nullable: false),
                    NumberOfGoodLoans = table.Column<double>(nullable: false),
                    BadLoanPerc = table.Column<double>(nullable: false),
                    BinGroup = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    DB = table.Column<double>(nullable: false),
                    DG = table.Column<double>(nullable: false),
                    WOE = table.Column<double>(nullable: false),
                    DG_DB = table.Column<double>(nullable: false),
                    WoeDGBG = table.Column<double>(nullable: false),
                    ScoreAfterReg = table.Column<double>(nullable: false),
                    ScorePoint = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentToIncomeGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    RentToIncomeGroup = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    NumberOfLoans = table.Column<double>(nullable: false),
                    NumberOfBadLoans = table.Column<double>(nullable: false),
                    NumberOfGoodLoans = table.Column<double>(nullable: false),
                    BadLoanPerc = table.Column<double>(nullable: false),
                    BinGroup = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    DB = table.Column<double>(nullable: false),
                    DG = table.Column<double>(nullable: false),
                    WOE = table.Column<double>(nullable: false),
                    DG_DB = table.Column<double>(nullable: false),
                    WoeDGBG = table.Column<double>(nullable: false),
                    ScoreAfterReg = table.Column<double>(nullable: false),
                    ScorePoint = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentToIncomeGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Retail_Attributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attributes = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retail_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReturnonAssetsAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ReturnonAssets = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnonAssetsAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Score_CDF_Table",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Score = table.Column<double>(nullable: false),
                    CDF = table.Column<double>(nullable: false),
                    CDF_Good = table.Column<double>(nullable: false),
                    CDF_Bad = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score_CDF_Table", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectionSetups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    Section = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionSetups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectorGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SectorGroup = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    NumberOfLoans = table.Column<double>(nullable: false),
                    NumberOfBadLoans = table.Column<double>(nullable: false),
                    NumberOfGoodLoans = table.Column<double>(nullable: false),
                    BadLoanPerc = table.Column<double>(nullable: false),
                    BinGroup = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    DB = table.Column<double>(nullable: false),
                    DG = table.Column<double>(nullable: false),
                    WOE = table.Column<double>(nullable: false),
                    DG_DB = table.Column<double>(nullable: false),
                    WoeDGBG = table.Column<double>(nullable: false),
                    ScoreAfterReg = table.Column<double>(nullable: false),
                    ScorePoint = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectorGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Selected_Attributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectedValues = table.Column<string>(type: "nvarchar(900)", nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selected_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SetUpItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Training = table.Column<int>(nullable: false),
                    Test = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    MethodId = table.Column<int>(nullable: false),
                    SplittingMethodId = table.Column<int>(nullable: false),
                    MinAge = table.Column<int>(nullable: false),
                    MaxAge = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetUpItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SME_Attributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attributes = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SME_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubSectorSetups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    Section = table.Column<string>(nullable: true),
                    SubHeading = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSectorSetups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_AccountAuthorize",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_AccountAuthorize", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_AgeDistribution",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgeBins = table.Column<string>(nullable: true),
                    Weight = table.Column<double>(nullable: false),
                    Score = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_AgeDistribution", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_AttributeCount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_AttributeCount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Attributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Attributes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Bank",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankNames = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Bank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_BankAccount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvgMonInflow = table.Column<decimal>(nullable: false),
                    InflowGrowthRate = table.Column<int>(nullable: false),
                    YearlyRepayments = table.Column<int>(nullable: false),
                    CreditLineAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_BankAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_BinRanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Range = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_BinRanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_BusRegNig",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_BusRegNig", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_CharacteristicsAnalysis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attributes = table.Column<string>(nullable: true),
                    Bins = table.Column<string>(nullable: true),
                    DevFrequency = table.Column<int>(nullable: false),
                    RecFrequency = table.Column<int>(nullable: false),
                    DevFrequencyPerc = table.Column<double>(nullable: false),
                    RecFrequencyPerc = table.Column<double>(nullable: false),
                    SCPoints = table.Column<int>(nullable: false),
                    Index = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_CharacteristicsAnalysis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Components",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Components", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_CreditLineCondition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanDuration = table.Column<int>(nullable: false),
                    CommitmentPeriod = table.Column<int>(nullable: false),
                    RepaymentFrequency = table.Column<int>(nullable: false),
                    Scoring = table.Column<int>(nullable: false),
                    CLAmount = table.Column<decimal>(nullable: false),
                    InterestRate = table.Column<int>(nullable: false),
                    Fee = table.Column<decimal>(nullable: false),
                    OverrideTerms = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_CreditLineCondition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_CurrentAccStatusDistribution",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgeBins = table.Column<string>(nullable: true),
                    Weight = table.Column<double>(nullable: false),
                    Score = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_CurrentAccStatusDistribution", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_DigSetUp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventBadCollPayment = table.Column<double>(nullable: false),
                    FraudEvent = table.Column<double>(nullable: false),
                    FreqAdvPayments = table.Column<double>(nullable: false),
                    NotEnoughBankAccforScoring = table.Column<double>(nullable: false),
                    MajorNewLendingObligationsIdentified = table.Column<double>(nullable: false),
                    NotEnoughInflowsGrantCreditLine = table.Column<double>(nullable: false),
                    HighPredModelDefProb = table.Column<double>(nullable: false),
                    NotEnoughSpaceCreditLine = table.Column<double>(nullable: false),
                    AffordableCreditLineAmount = table.Column<double>(nullable: false),
                    InsufficientBankAccountBuffer = table.Column<string>(nullable: true),
                    InsufficientLevelInflowVersusStatedRev = table.Column<double>(nullable: false),
                    NotEnoughOverdraftBufferAvailable = table.Column<double>(nullable: false),
                    SignificantReductionBankAccInflows = table.Column<double>(nullable: false),
                    HighLeverage = table.Column<double>(nullable: false),
                    NegativeInsufficientDebtServiceCovRatio = table.Column<double>(nullable: false),
                    InsufficientProfitMargin = table.Column<double>(nullable: false),
                    EmailAddIdentAutGen = table.Column<bool>(nullable: false),
                    EmailAddDisEmailServ = table.Column<bool>(nullable: false),
                    EmailAddBounces = table.Column<bool>(nullable: false),
                    NoMixRecordFoundDomainEmailAdd = table.Column<bool>(nullable: false),
                    ConnSMTP = table.Column<bool>(nullable: false),
                    CompYearBusiness = table.Column<double>(nullable: false),
                    ShareCapital = table.Column<double>(nullable: false),
                    UnableVerifyUserPayAcc = table.Column<double>(nullable: false),
                    CourtActions = table.Column<double>(nullable: false),
                    CourtWrits = table.Column<double>(nullable: false),
                    CreditEnquries = table.Column<double>(nullable: false),
                    DefaultStatus = table.Column<double>(nullable: false),
                    ExternalAdmin = table.Column<double>(nullable: false),
                    PaymentDefaults = table.Column<double>(nullable: false),
                    PetOccurrence = table.Column<double>(nullable: false),
                    CurrDirectorships = table.Column<double>(nullable: false),
                    DirecAge = table.Column<double>(nullable: false),
                    Bankruptcy = table.Column<double>(nullable: false),
                    CommercialDefaults = table.Column<double>(nullable: false),
                    ConsumerDefaults = table.Column<double>(nullable: false),
                    CourtActionsForCreditBureau = table.Column<double>(nullable: false),
                    DisqDirectorship = table.Column<double>(nullable: false),
                    ProbFutureAdverseEvent = table.Column<double>(nullable: false),
                    ProbFutureSeriousEvent = table.Column<double>(nullable: false),
                    LowCreditBureauScore = table.Column<double>(nullable: false),
                    PreviouDirectorships = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_DigSetUp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Feature_Selection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MethodName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Feature_Selection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_FinancialRatio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    RatioName = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    RatioDefinition = table.Column<string>(type: "nvarchar(900)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_FinancialRatio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_GenderType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_GenderType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_GiniCurve",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Good_Bad = table.Column<bool>(nullable: false),
                    Score = table.Column<double>(nullable: true),
                    Defaulters = table.Column<double>(nullable: true),
                    CustomersTotal = table.Column<int>(nullable: true),
                    Cumm_Perc_Defaulters = table.Column<double>(nullable: true),
                    Cumm_Perc_Customers = table.Column<double>(nullable: true),
                    AUC = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_GiniCurve", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_GiniInclusives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Good_Bad = table.Column<bool>(nullable: false),
                    Score = table.Column<double>(nullable: true),
                    CumNoDefaulters = table.Column<int>(nullable: true),
                    CumNoApplicants = table.Column<int>(nullable: true),
                    CumPercDefaulters = table.Column<double>(nullable: true),
                    CumPercApplicants = table.Column<double>(nullable: true),
                    AreaUnderCAP = table.Column<double>(nullable: true),
                    Y_fit = table.Column<double>(nullable: true),
                    Residual = table.Column<double>(nullable: true),
                    ResSquare = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_GiniInclusives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_GoodBad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Good = table.Column<int>(nullable: true),
                    Bad = table.Column<int>(nullable: true),
                    GoodLabel = table.Column<string>(nullable: true),
                    BadLabel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_GoodBad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_GoodBadInputs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Good = table.Column<int>(nullable: true),
                    Bad = table.Column<int>(nullable: true),
                    GoodLabel = table.Column<string>(nullable: true),
                    BadLabel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_GoodBadInputs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_GoodBadInputsRaw",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Good = table.Column<int>(nullable: true),
                    Bad = table.Column<int>(nullable: true),
                    GoodLabel = table.Column<string>(nullable: true),
                    BadLabel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_GoodBadInputsRaw", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_HaveBankAccount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_HaveBankAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_HaveNIN",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_HaveNIN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Histograms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    featurename = table.Column<string>(maxLength: 32, nullable: false),
                    lowerBound = table.Column<string>(maxLength: 32, nullable: false),
                    upperBound = table.Column<double>(maxLength: 32, nullable: false),
                    count = table.Column<double>(nullable: false),
                    percent = table.Column<double>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Histograms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_IndividualApplication",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueId = table.Column<string>(nullable: true),
                    SrcIncome = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    Application = table.Column<string>(nullable: true),
                    RequestedAmount = table.Column<decimal>(nullable: false),
                    LoanPurpose = table.Column<string>(nullable: true),
                    ApplicationDate = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_IndividualApplication", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_KSTestCurve",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(nullable: true),
                    Range = table.Column<int>(nullable: true),
                    Good = table.Column<int>(nullable: true),
                    Bad = table.Column<int>(nullable: true),
                    Cumm_Good = table.Column<int>(nullable: true),
                    Cumm_Bad = table.Column<int>(nullable: true),
                    Cumm_Perc_Good = table.Column<double>(nullable: true),
                    Cumm_Perc_Bad = table.Column<double>(nullable: true),
                    Cumm_Perc_Diff = table.Column<double>(nullable: true),
                    Cumm_Pop_Good = table.Column<int>(nullable: true),
                    Cumm_Pop_Bad = table.Column<int>(nullable: true),
                    Volume_Accepted = table.Column<int>(nullable: true),
                    Cumm_Accp_Perc = table.Column<double>(nullable: true),
                    Cumm_Bad_Rate = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_KSTestCurve", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Legal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Legal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_LendingOutputs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    Recommendation = table.Column<string>(nullable: true),
                    Rating = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_LendingOutputs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_LoanElibility",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    BusRegNigId = table.Column<int>(nullable: false),
                    AnnualTurnOver = table.Column<double>(nullable: false),
                    OperationId = table.Column<int>(nullable: false),
                    HaveBankAccountId = table.Column<int>(nullable: false),
                    HaveNINId = table.Column<int>(nullable: false),
                    AccountAuthorizeId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_LoanElibility", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_LoanType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanTypes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_LoanType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_LogisticRegressionInputs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    Location = table.Column<double>(nullable: false),
                    Rent_bin = table.Column<double>(nullable: false),
                    Rent_to_Income_bin = table.Column<double>(nullable: false),
                    Return_on_Assets_bin = table.Column<double>(nullable: false),
                    Total_assets_bin = table.Column<double>(nullable: false),
                    Good_Bad = table.Column<bool>(nullable: false),
                    Training_Test = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_LogisticRegressionInputs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ObligorRiskRating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "varchar(200)", nullable: true),
                    Option = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ObligorRiskRating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Operation_Eligibity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Operation_Eligibity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Ownership",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Ownership", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_PositionInIdustry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_PositionInIdustry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ProductCont",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ProductCont", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ProfitAnalysis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CutOff = table.Column<double>(nullable: false),
                    TPCount = table.Column<double>(nullable: false),
                    FPCount = table.Column<double>(nullable: false),
                    Profit = table.Column<double>(nullable: false),
                    ModelDifference = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ProfitAnalysis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_QualitativeAnalysis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attribute = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: false),
                    Percentage = table.Column<double>(nullable: false),
                    MaxScore = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    AttributeScore = table.Column<int>(nullable: false),
                    WeightedAttribute = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_QualitativeAnalysis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_QualitativeAnalysisRating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<string>(nullable: true),
                    RatingDescription = table.Column<string>(type: "varchar(500)", nullable: true),
                    Score = table.Column<int>(nullable: false),
                    Range = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_QualitativeAnalysisRating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_QualityAnalysisCutOff",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CutoffValue = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_QualityAnalysisCutOff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Rating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Rating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_RatingAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Items = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_RatingAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_RegOutput",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParamName = table.Column<string>(nullable: true),
                    Coeff_Estimate = table.Column<double>(nullable: false),
                    Std_Error = table.Column<double>(nullable: false),
                    t_value = table.Column<double>(nullable: false),
                    p_value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_RegOutput", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_RegOutputRunDate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RunDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_RegOutputRunDate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Regression",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<double>(nullable: false),
                    Rent_bin = table.Column<double>(nullable: false),
                    Rent_to_Income_bin = table.Column<double>(nullable: false),
                    Return_on_Assets_bin = table.Column<double>(nullable: false),
                    Total_assets_bin = table.Column<double>(nullable: false),
                    Good_Bad = table.Column<bool>(nullable: false),
                    Training_Test = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Regression", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_RegressionOutputs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    ParamName = table.Column<string>(nullable: false),
                    Coeff_Estimate = table.Column<double>(nullable: false),
                    Std_Error = table.Column<double>(nullable: false),
                    t_value = table.Column<double>(nullable: false),
                    p_value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_RegressionOutputs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_RetailCutoff",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CutoffValue = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_RetailCutoff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_RetailScoring",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attribute = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: false),
                    Percentage = table.Column<double>(nullable: false),
                    MaxScore = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    AttributeScore = table.Column<int>(nullable: false),
                    WeightedAttribute = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_RetailScoring", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_RiskAssessment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RedWarnSignals = table.Column<decimal>(nullable: false),
                    YellowWarnSignals = table.Column<decimal>(nullable: false),
                    QualitativeWarnSignals = table.Column<decimal>(nullable: false),
                    PerformanceModel = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_RiskAssessment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_RiskRatingItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<int>(nullable: false),
                    Category = table.Column<string>(type: "varchar(200)", nullable: true),
                    Option = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_RiskRatingItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Scaling",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Items = table.Column<string>(nullable: true),
                    Values = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Scaling", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SCMonitoring",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scores = table.Column<int>(nullable: false),
                    Bin_name = table.Column<int>(nullable: false),
                    Approved = table.Column<bool>(nullable: false),
                    Rejected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_SCMonitoring", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_score",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_score", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ScoreCardReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Characteristic = table.Column<string>(nullable: true),
                    CharacteristicBin = table.Column<string>(nullable: true),
                    ScoreCardPoints = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ScoreCardReport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ScoreReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    TotalScore = table.Column<double>(nullable: true),
                    QualitativeRating = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ScoreReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ScoretoRating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<string>(nullable: true),
                    PercPD_real = table.Column<double>(nullable: false),
                    PD_real = table.Column<double>(nullable: false),
                    NOC = table.Column<int>(nullable: false),
                    NOD = table.Column<int>(nullable: false),
                    ScoreRanges = table.Column<string>(nullable: true),
                    Odds = table.Column<double>(nullable: false),
                    PercPD_Odds = table.Column<double>(nullable: false),
                    PD_Odds = table.Column<double>(nullable: false),
                    Xr = table.Column<double>(nullable: false),
                    PercPD_est = table.Column<double>(nullable: false),
                    PD_est = table.Column<double>(nullable: false),
                    High = table.Column<double>(nullable: false),
                    Low = table.Column<double>(nullable: false),
                    BinomialTestSP = table.Column<bool>(nullable: false),
                    BinomialTestOdds = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ScoretoRating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ScoringOutputs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<double>(maxLength: 32, nullable: false),
                    Risk_Level = table.Column<string>(maxLength: 32, nullable: false),
                    PD = table.Column<double>(nullable: false),
                    Good_Bad_Odd = table.Column<double>(nullable: false),
                    Interest_Rate = table.Column<double>(nullable: false),
                    Recommendation = table.Column<string>(nullable: true),
                    App_Type = table.Column<string>(nullable: true),
                    Debt_Income_Ratio = table.Column<double>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ScoringOutputs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SetupPage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditScoreWeight = table.Column<double>(nullable: false),
                    QualitativeAnalysisWeight = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_SetupPage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SMETitle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndivividualTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_SMETitle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SplittingMethod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SplittingName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_SplittingMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_StabiltyTrend",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bins = table.Column<string>(nullable: true),
                    SampleFrequency = table.Column<int>(nullable: false),
                    RecentFrequency = table.Column<int>(nullable: false),
                    ThreeMonthFrequency = table.Column<int>(nullable: false),
                    SixMonthFrequency = table.Column<int>(nullable: false),
                    SampleFrequencyPerc = table.Column<double>(nullable: false),
                    RecentFrequencyPerc = table.Column<double>(nullable: false),
                    ThreeMonthFrequencyPerc = table.Column<double>(nullable: false),
                    SixMonthFrequencyPerc = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_StabiltyTrend", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_VintageAnalysis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullDate = table.Column<DateTime>(nullable: false),
                    FullYear = table.Column<string>(nullable: true),
                    FullMonth = table.Column<string>(nullable: true),
                    FullCount = table.Column<int>(nullable: false),
                    Q1 = table.Column<double>(nullable: false),
                    Q2 = table.Column<double>(nullable: false),
                    Q3 = table.Column<double>(nullable: false),
                    Q4 = table.Column<double>(nullable: false),
                    Q5 = table.Column<double>(nullable: false),
                    Q6 = table.Column<double>(nullable: false),
                    Q7 = table.Column<double>(nullable: false),
                    Q8 = table.Column<double>(nullable: false),
                    Q9 = table.Column<double>(nullable: false),
                    Q10 = table.Column<double>(nullable: false),
                    Q11 = table.Column<double>(nullable: false),
                    Q12 = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_VintageAnalysis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblScoringInputDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TrainingSample = table.Column<bool>(nullable: false),
                    UniqueID = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Income = table.Column<double>(maxLength: 32, nullable: false),
                    ReturnonAssets = table.Column<double>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Residentstatus = table.Column<string>(nullable: true),
                    TimeatJob = table.Column<double>(nullable: false),
                    Timeatresidence = table.Column<double>(nullable: false),
                    Product = table.Column<string>(nullable: true),
                    Sector = table.Column<string>(nullable: true),
                    Subsector = table.Column<string>(nullable: true),
                    CurrentAccountStatus = table.Column<string>(nullable: true),
                    Totalassets = table.Column<double>(nullable: false),
                    Rent = table.Column<double>(nullable: false),
                    RenttoIncome = table.Column<double>(nullable: false),
                    TimeatBank = table.Column<double>(nullable: false),
                    Numberofproducts = table.Column<int>(nullable: false),
                    Paymentperformance = table.Column<string>(nullable: true),
                    Previousclaims = table.Column<bool>(nullable: false),
                    GoodBad = table.Column<bool>(nullable: false),
                    Dateopened = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblScoringInputDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblWoe_Age",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WOE = table.Column<double>(nullable: false),
                    Age = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblWoe_Age", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblWoe_PaymentPerformance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WOE = table.Column<double>(nullable: false),
                    PaymentPerformance = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblWoe_PaymentPerformance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblWoe_TimeatJob",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WOE = table.Column<double>(nullable: false),
                    TimeatJob = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblWoe_TimeatJob", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ULoanRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    LoanType = table.Column<string>(maxLength: 25, nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Tenor = table.Column<int>(nullable: false),
                    Status = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ULoanRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Viewbincountpercentage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attribute = table.Column<string>(nullable: true),
                    binning = table.Column<string>(type: "varchar(500)", nullable: true),
                    percentage = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viewbincountpercentage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpDynamicEntityProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityFullName = table.Column<string>(nullable: true),
                    DynamicPropertyId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpDynamicEntityProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpDynamicEntityProperties_AbpDynamicProperties_DynamicPropertyId",
                        column: x => x.DynamicPropertyId,
                        principalTable: "AbpDynamicProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpDynamicPropertyValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    DynamicPropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpDynamicPropertyValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpDynamicPropertyValues_AbpDynamicProperties_DynamicPropertyId",
                        column: x => x.DynamicPropertyId,
                        principalTable: "AbpDynamicProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpFeatures",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    EditionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpFeatures_AbpEditions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "AbpEditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppSubscriptionPayments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Gateway = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    EditionId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: false),
                    DayCount = table.Column<int>(nullable: false),
                    PaymentPeriodType = table.Column<int>(nullable: true),
                    ExternalPaymentId = table.Column<string>(nullable: true),
                    InvoiceNo = table.Column<string>(nullable: true),
                    IsRecurring = table.Column<bool>(nullable: false),
                    SuccessUrl = table.Column<string>(nullable: true),
                    ErrorUrl = table.Column<string>(nullable: true),
                    EditionPaymentType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSubscriptionPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppSubscriptionPayments_AbpEditions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "AbpEditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpEntityChanges",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeTime = table.Column<DateTime>(nullable: false),
                    ChangeType = table.Column<byte>(nullable: false),
                    EntityChangeSetId = table.Column<long>(nullable: false),
                    EntityId = table.Column<string>(maxLength: 48, nullable: true),
                    EntityTypeFullName = table.Column<string>(maxLength: 192, nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpEntityChanges_AbpEntityChangeSets_EntityChangeSetId",
                        column: x => x.EntityChangeSetId,
                        principalTable: "AbpEntityChangeSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 64, nullable: false),
                    IsStatic = table.Column<bool>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    NormalizedName = table.Column<string>(maxLength: 32, nullable: false),
                    ConcurrencyStamp = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpRoles_AbpUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpRoles_AbpUsers_DeleterUserId",
                        column: x => x.DeleterUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpRoles_AbpUsers_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpSettings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpSettings_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpTenants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenancyName = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    ConnectionString = table.Column<string>(maxLength: 1024, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    EditionId = table.Column<int>(nullable: true),
                    SubscriptionEndDateUtc = table.Column<DateTime>(nullable: true),
                    IsInTrialPeriod = table.Column<bool>(nullable: false),
                    CustomCssId = table.Column<Guid>(nullable: true),
                    LogoId = table.Column<Guid>(nullable: true),
                    LogoFileType = table.Column<string>(maxLength: 64, nullable: true),
                    SubscriptionPaymentType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpTenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpTenants_AbpUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpTenants_AbpUsers_DeleterUserId",
                        column: x => x.DeleterUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpTenants_AbpEditions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "AbpEditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpTenants_AbpUsers_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserClaims",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(maxLength: 256, nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpUserClaims_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserLogins",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpUserLogins_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserOrganizationUnits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    OrganizationUnitId = table.Column<long>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserOrganizationUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpUserOrganizationUnits_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpUserRoles_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserTokens",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    Value = table.Column<string>(maxLength: 512, nullable: true),
                    ExpireDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpUserTokens_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpWebhookSendAttempts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WebhookEventId = table.Column<Guid>(nullable: false),
                    WebhookSubscriptionId = table.Column<Guid>(nullable: false),
                    Response = table.Column<string>(nullable: true),
                    ResponseStatusCode = table.Column<int>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpWebhookSendAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpWebhookSendAttempts_AbpWebhookEvents_WebhookEventId",
                        column: x => x.WebhookEventId,
                        principalTable: "AbpWebhookEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SetupSubHeadings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    SubHeading = table.Column<string>(nullable: true),
                    SectionSetupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetupSubHeadings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SetupSubHeadings_SectionSetups_SectionSetupId",
                        column: x => x.SectionSetupId,
                        principalTable: "SectionSetups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubHeadingSetups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    SubHeading = table.Column<string>(nullable: true),
                    SectionSetupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubHeadingSetups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubHeadingSetups_SectionSetups_SectionSetupId",
                        column: x => x.SectionSetupId,
                        principalTable: "SectionSetups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ratingapplicationscoring",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ProductTypeId = table.Column<int>(nullable: true),
                    ApplicantId = table.Column<int>(nullable: true),
                    Appld = table.Column<int>(nullable: true),
                    LoanRequest = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    TenorMonth = table.Column<int>(nullable: false),
                    AgeAttributeId = table.Column<int>(nullable: true),
                    IncomeAttributeId = table.Column<int>(nullable: true),
                    LocationAttributeId = table.Column<int>(nullable: true),
                    RentAttributeId = table.Column<int>(nullable: true),
                    RenttoIncomeAttributeId = table.Column<int>(nullable: true),
                    ReturnonAssetsAttributeId = table.Column<int>(nullable: true),
                    SubSectorAttributeId = table.Column<int>(nullable: true),
                    ExtraParam1 = table.Column<string>(nullable: true),
                    ExtraParam2 = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ratingapplicationscoring", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ratingapplicationscoring_AgeGroup_AgeAttributeId",
                        column: x => x.AgeAttributeId,
                        principalTable: "AgeGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ratingapplicationscoring_AppType_Appld",
                        column: x => x.Appld,
                        principalTable: "AppType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ratingapplicationscoring_Applicant_with_Accno_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant_with_Accno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ratingapplicationscoring_IncomeAttributes_IncomeAttributeId",
                        column: x => x.IncomeAttributeId,
                        principalTable: "IncomeAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ratingapplicationscoring_LocationGroup_LocationAttributeId",
                        column: x => x.LocationAttributeId,
                        principalTable: "LocationGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ratingapplicationscoring_ProductTypeAttributes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypeAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ratingapplicationscoring_RentGroup_RentAttributeId",
                        column: x => x.RentAttributeId,
                        principalTable: "RentGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ratingapplicationscoring_RentToIncomeGroup_RenttoIncomeAttributeId",
                        column: x => x.RenttoIncomeAttributeId,
                        principalTable: "RentToIncomeGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ratingapplicationscoring_ReturnonAssetsAttributes_ReturnonAssetsAttributeId",
                        column: x => x.ReturnonAssetsAttributeId,
                        principalTable: "ReturnonAssetsAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ratingapplicationscoring_SectorGroup_SubSectorAttributeId",
                        column: x => x.SubSectorAttributeId,
                        principalTable: "SectorGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SMELendingApply",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ApplicatioNo = table.Column<int>(nullable: false),
                    BusinessName = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    LoanTypeId = table.Column<int>(nullable: true),
                    LoanAmount = table.Column<double>(nullable: false),
                    LoanTenor = table.Column<int>(nullable: false),
                    Bvn = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    TitleId = table.Column<int>(nullable: false),
                    BusinessAccountNo = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<string>(nullable: true),
                    GenderId = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    BankId = table.Column<int>(nullable: false),
                    BankAccountNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_SMELendingApply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_SMELendingApply_Tbl_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Tbl_Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_SMELendingApply_Tbl_LoanType_LoanTypeId",
                        column: x => x.LoanTypeId,
                        principalTable: "Tbl_LoanType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpDynamicEntityPropertyValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: false),
                    EntityId = table.Column<string>(nullable: true),
                    DynamicEntityPropertyId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpDynamicEntityPropertyValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpDynamicEntityPropertyValues_AbpDynamicEntityProperties_DynamicEntityPropertyId",
                        column: x => x.DynamicEntityPropertyId,
                        principalTable: "AbpDynamicEntityProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpEntityPropertyChanges",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityChangeId = table.Column<long>(nullable: false),
                    NewValue = table.Column<string>(maxLength: 512, nullable: true),
                    OriginalValue = table.Column<string>(maxLength: 512, nullable: true),
                    PropertyName = table.Column<string>(maxLength: 96, nullable: true),
                    PropertyTypeFullName = table.Column<string>(maxLength: 192, nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityPropertyChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpEntityPropertyChanges_AbpEntityChanges_EntityChangeId",
                        column: x => x.EntityChangeId,
                        principalTable: "AbpEntityChanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpPermissions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    IsGranted = table.Column<bool>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    RoleId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpPermissions_AbpRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AbpRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpPermissions_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpRoleClaims",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(maxLength: 256, nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpRoleClaims_AbpRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AbpRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SetupQualitatives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    Qualitative = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    SectionSetupId = table.Column<int>(nullable: false),
                    SetupSubHeadingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetupQualitatives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SetupQualitatives_SectionSetups_SectionSetupId",
                        column: x => x.SectionSetupId,
                        principalTable: "SectionSetups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SetupQualitatives_SetupSubHeadings_SetupSubHeadingId",
                        column: x => x.SetupSubHeadingId,
                        principalTable: "SetupSubHeadings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogs_TenantId_ExecutionDuration",
                table: "AbpAuditLogs",
                columns: new[] { "TenantId", "ExecutionDuration" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogs_TenantId_ExecutionTime",
                table: "AbpAuditLogs",
                columns: new[] { "TenantId", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogs_TenantId_UserId",
                table: "AbpAuditLogs",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpBackgroundJobs_IsAbandoned_NextTryTime",
                table: "AbpBackgroundJobs",
                columns: new[] { "IsAbandoned", "NextTryTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpDynamicEntityProperties_DynamicPropertyId",
                table: "AbpDynamicEntityProperties",
                column: "DynamicPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpDynamicEntityProperties_EntityFullName_DynamicPropertyId_TenantId",
                table: "AbpDynamicEntityProperties",
                columns: new[] { "EntityFullName", "DynamicPropertyId", "TenantId" },
                unique: true,
                filter: "[EntityFullName] IS NOT NULL AND [TenantId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AbpDynamicEntityPropertyValues_DynamicEntityPropertyId",
                table: "AbpDynamicEntityPropertyValues",
                column: "DynamicEntityPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpDynamicProperties_PropertyName_TenantId",
                table: "AbpDynamicProperties",
                columns: new[] { "PropertyName", "TenantId" },
                unique: true,
                filter: "[PropertyName] IS NOT NULL AND [TenantId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AbpDynamicPropertyValues_DynamicPropertyId",
                table: "AbpDynamicPropertyValues",
                column: "DynamicPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChanges_EntityChangeSetId",
                table: "AbpEntityChanges",
                column: "EntityChangeSetId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChanges_EntityTypeFullName_EntityId",
                table: "AbpEntityChanges",
                columns: new[] { "EntityTypeFullName", "EntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChangeSets_TenantId_CreationTime",
                table: "AbpEntityChangeSets",
                columns: new[] { "TenantId", "CreationTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChangeSets_TenantId_Reason",
                table: "AbpEntityChangeSets",
                columns: new[] { "TenantId", "Reason" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChangeSets_TenantId_UserId",
                table: "AbpEntityChangeSets",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityPropertyChanges_EntityChangeId",
                table: "AbpEntityPropertyChanges",
                column: "EntityChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpFeatures_EditionId_Name",
                table: "AbpFeatures",
                columns: new[] { "EditionId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpFeatures_TenantId_Name",
                table: "AbpFeatures",
                columns: new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpLanguages_TenantId_Name",
                table: "AbpLanguages",
                columns: new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpLanguageTexts_TenantId_Source_LanguageName_Key",
                table: "AbpLanguageTexts",
                columns: new[] { "TenantId", "Source", "LanguageName", "Key" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpNotificationSubscriptions_NotificationName_EntityTypeName_EntityId_UserId",
                table: "AbpNotificationSubscriptions",
                columns: new[] { "NotificationName", "EntityTypeName", "EntityId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpNotificationSubscriptions_TenantId_NotificationName_EntityTypeName_EntityId_UserId",
                table: "AbpNotificationSubscriptions",
                columns: new[] { "TenantId", "NotificationName", "EntityTypeName", "EntityId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnitRoles_TenantId_OrganizationUnitId",
                table: "AbpOrganizationUnitRoles",
                columns: new[] { "TenantId", "OrganizationUnitId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnitRoles_TenantId_RoleId",
                table: "AbpOrganizationUnitRoles",
                columns: new[] { "TenantId", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnits_ParentId",
                table: "AbpOrganizationUnits",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnits_TenantId_Code",
                table: "AbpOrganizationUnits",
                columns: new[] { "TenantId", "Code" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpPermissions_TenantId_Name",
                table: "AbpPermissions",
                columns: new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpPermissions_RoleId",
                table: "AbpPermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpPermissions_UserId",
                table: "AbpPermissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpPersistedGrants_SubjectId_ClientId_Type",
                table: "AbpPersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoleClaims_RoleId",
                table: "AbpRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoleClaims_TenantId_ClaimType",
                table: "AbpRoleClaims",
                columns: new[] { "TenantId", "ClaimType" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoles_CreatorUserId",
                table: "AbpRoles",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoles_DeleterUserId",
                table: "AbpRoles",
                column: "DeleterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoles_LastModifierUserId",
                table: "AbpRoles",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoles_TenantId_NormalizedName",
                table: "AbpRoles",
                columns: new[] { "TenantId", "NormalizedName" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpSettings_UserId",
                table: "AbpSettings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpSettings_TenantId_Name_UserId",
                table: "AbpSettings",
                columns: new[] { "TenantId", "Name", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenantNotifications_TenantId",
                table: "AbpTenantNotifications",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_CreationTime",
                table: "AbpTenants",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_CreatorUserId",
                table: "AbpTenants",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_DeleterUserId",
                table: "AbpTenants",
                column: "DeleterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_EditionId",
                table: "AbpTenants",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_LastModifierUserId",
                table: "AbpTenants",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_SubscriptionEndDateUtc",
                table: "AbpTenants",
                column: "SubscriptionEndDateUtc");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_TenancyName",
                table: "AbpTenants",
                column: "TenancyName");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserAccounts_EmailAddress",
                table: "AbpUserAccounts",
                column: "EmailAddress");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserAccounts_UserName",
                table: "AbpUserAccounts",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserAccounts_TenantId_EmailAddress",
                table: "AbpUserAccounts",
                columns: new[] { "TenantId", "EmailAddress" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserAccounts_TenantId_UserId",
                table: "AbpUserAccounts",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserAccounts_TenantId_UserName",
                table: "AbpUserAccounts",
                columns: new[] { "TenantId", "UserName" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserClaims_UserId",
                table: "AbpUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserClaims_TenantId_ClaimType",
                table: "AbpUserClaims",
                columns: new[] { "TenantId", "ClaimType" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserLoginAttempts_UserId_TenantId",
                table: "AbpUserLoginAttempts",
                columns: new[] { "UserId", "TenantId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserLoginAttempts_TenancyName_UserNameOrEmailAddress_Result",
                table: "AbpUserLoginAttempts",
                columns: new[] { "TenancyName", "UserNameOrEmailAddress", "Result" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserLogins_UserId",
                table: "AbpUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserLogins_TenantId_UserId",
                table: "AbpUserLogins",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserLogins_TenantId_LoginProvider_ProviderKey",
                table: "AbpUserLogins",
                columns: new[] { "TenantId", "LoginProvider", "ProviderKey" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserNotifications_UserId_State_CreationTime",
                table: "AbpUserNotifications",
                columns: new[] { "UserId", "State", "CreationTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserOrganizationUnits_UserId",
                table: "AbpUserOrganizationUnits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserOrganizationUnits_TenantId_OrganizationUnitId",
                table: "AbpUserOrganizationUnits",
                columns: new[] { "TenantId", "OrganizationUnitId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserOrganizationUnits_TenantId_UserId",
                table: "AbpUserOrganizationUnits",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserRoles_UserId",
                table: "AbpUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserRoles_TenantId_RoleId",
                table: "AbpUserRoles",
                columns: new[] { "TenantId", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserRoles_TenantId_UserId",
                table: "AbpUserRoles",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_CreatorUserId",
                table: "AbpUsers",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_DeleterUserId",
                table: "AbpUsers",
                column: "DeleterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_LastModifierUserId",
                table: "AbpUsers",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_TenantId_NormalizedEmailAddress",
                table: "AbpUsers",
                columns: new[] { "TenantId", "NormalizedEmailAddress" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_TenantId_NormalizedUserName",
                table: "AbpUsers",
                columns: new[] { "TenantId", "NormalizedUserName" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserTokens_UserId",
                table: "AbpUserTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserTokens_TenantId_UserId",
                table: "AbpUserTokens",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpWebhookSendAttempts_WebhookEventId",
                table: "AbpWebhookSendAttempts",
                column: "WebhookEventId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBinaryObjects_TenantId",
                table: "AppBinaryObjects",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AppChatMessages_TargetTenantId_TargetUserId_ReadState",
                table: "AppChatMessages",
                columns: new[] { "TargetTenantId", "TargetUserId", "ReadState" });

            migrationBuilder.CreateIndex(
                name: "IX_AppChatMessages_TargetTenantId_UserId_ReadState",
                table: "AppChatMessages",
                columns: new[] { "TargetTenantId", "UserId", "ReadState" });

            migrationBuilder.CreateIndex(
                name: "IX_AppChatMessages_TenantId_TargetUserId_ReadState",
                table: "AppChatMessages",
                columns: new[] { "TenantId", "TargetUserId", "ReadState" });

            migrationBuilder.CreateIndex(
                name: "IX_AppChatMessages_TenantId_UserId_ReadState",
                table: "AppChatMessages",
                columns: new[] { "TenantId", "UserId", "ReadState" });

            migrationBuilder.CreateIndex(
                name: "IX_AppFriendships_FriendTenantId_FriendUserId",
                table: "AppFriendships",
                columns: new[] { "FriendTenantId", "FriendUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AppFriendships_FriendTenantId_UserId",
                table: "AppFriendships",
                columns: new[] { "FriendTenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AppFriendships_TenantId_FriendUserId",
                table: "AppFriendships",
                columns: new[] { "TenantId", "FriendUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AppFriendships_TenantId_UserId",
                table: "AppFriendships",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AppSubscriptionPayments_EditionId",
                table: "AppSubscriptionPayments",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSubscriptionPayments_ExternalPaymentId_Gateway",
                table: "AppSubscriptionPayments",
                columns: new[] { "ExternalPaymentId", "Gateway" });

            migrationBuilder.CreateIndex(
                name: "IX_AppSubscriptionPayments_Status_CreationTime",
                table: "AppSubscriptionPayments",
                columns: new[] { "Status", "CreationTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AppSubscriptionPaymentsExtensionData_SubscriptionPaymentId_Key_IsDeleted",
                table: "AppSubscriptionPaymentsExtensionData",
                columns: new[] { "SubscriptionPaymentId", "Key", "IsDeleted" },
                unique: true,
                filter: "[Key] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserDelegations_TenantId_SourceUserId",
                table: "AppUserDelegations",
                columns: new[] { "TenantId", "SourceUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserDelegations_TenantId_TargetUserId",
                table: "AppUserDelegations",
                columns: new[] { "TenantId", "TargetUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_QualitativeSetups_TenantId",
                table: "QualitativeSetups",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ratingapplicationscoring_AgeAttributeId",
                table: "ratingapplicationscoring",
                column: "AgeAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ratingapplicationscoring_Appld",
                table: "ratingapplicationscoring",
                column: "Appld");

            migrationBuilder.CreateIndex(
                name: "IX_ratingapplicationscoring_ApplicantId",
                table: "ratingapplicationscoring",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ratingapplicationscoring_IncomeAttributeId",
                table: "ratingapplicationscoring",
                column: "IncomeAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ratingapplicationscoring_LocationAttributeId",
                table: "ratingapplicationscoring",
                column: "LocationAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ratingapplicationscoring_ProductTypeId",
                table: "ratingapplicationscoring",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ratingapplicationscoring_RentAttributeId",
                table: "ratingapplicationscoring",
                column: "RentAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ratingapplicationscoring_RenttoIncomeAttributeId",
                table: "ratingapplicationscoring",
                column: "RenttoIncomeAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ratingapplicationscoring_ReturnonAssetsAttributeId",
                table: "ratingapplicationscoring",
                column: "ReturnonAssetsAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ratingapplicationscoring_SubSectorAttributeId",
                table: "ratingapplicationscoring",
                column: "SubSectorAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionSetups_TenantId",
                table: "SectionSetups",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_SetupQualitatives_SectionSetupId",
                table: "SetupQualitatives",
                column: "SectionSetupId");

            migrationBuilder.CreateIndex(
                name: "IX_SetupQualitatives_SetupSubHeadingId",
                table: "SetupQualitatives",
                column: "SetupSubHeadingId");

            migrationBuilder.CreateIndex(
                name: "IX_SetupQualitatives_TenantId",
                table: "SetupQualitatives",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_SetupSubHeadings_SectionSetupId",
                table: "SetupSubHeadings",
                column: "SectionSetupId");

            migrationBuilder.CreateIndex(
                name: "IX_SetupSubHeadings_TenantId",
                table: "SetupSubHeadings",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_SubHeadingSetups_SectionSetupId",
                table: "SubHeadingSetups",
                column: "SectionSetupId");

            migrationBuilder.CreateIndex(
                name: "IX_SubHeadingSetups_TenantId",
                table: "SubHeadingSetups",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSectorSetups_TenantId",
                table: "SubSectorSetups",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_LogisticRegressionInputs_TenantId",
                table: "Tbl_LogisticRegressionInputs",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_RegressionOutputs_TenantId",
                table: "Tbl_RegressionOutputs",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SMELendingApply_BankId",
                table: "Tbl_SMELendingApply",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SMELendingApply_LoanTypeId",
                table: "Tbl_SMELendingApply",
                column: "LoanTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpAuditLogs");

            migrationBuilder.DropTable(
                name: "AbpBackgroundJobs");

            migrationBuilder.DropTable(
                name: "AbpDynamicEntityPropertyValues");

            migrationBuilder.DropTable(
                name: "AbpDynamicPropertyValues");

            migrationBuilder.DropTable(
                name: "AbpEntityPropertyChanges");

            migrationBuilder.DropTable(
                name: "AbpFeatures");

            migrationBuilder.DropTable(
                name: "AbpLanguages");

            migrationBuilder.DropTable(
                name: "AbpLanguageTexts");

            migrationBuilder.DropTable(
                name: "AbpNotifications");

            migrationBuilder.DropTable(
                name: "AbpNotificationSubscriptions");

            migrationBuilder.DropTable(
                name: "AbpOrganizationUnitRoles");

            migrationBuilder.DropTable(
                name: "AbpOrganizationUnits");

            migrationBuilder.DropTable(
                name: "AbpPermissions");

            migrationBuilder.DropTable(
                name: "AbpPersistedGrants");

            migrationBuilder.DropTable(
                name: "AbpRoleClaims");

            migrationBuilder.DropTable(
                name: "AbpSettings");

            migrationBuilder.DropTable(
                name: "AbpTenantNotifications");

            migrationBuilder.DropTable(
                name: "AbpTenants");

            migrationBuilder.DropTable(
                name: "AbpUserAccounts");

            migrationBuilder.DropTable(
                name: "AbpUserClaims");

            migrationBuilder.DropTable(
                name: "AbpUserLoginAttempts");

            migrationBuilder.DropTable(
                name: "AbpUserLogins");

            migrationBuilder.DropTable(
                name: "AbpUserNotifications");

            migrationBuilder.DropTable(
                name: "AbpUserOrganizationUnits");

            migrationBuilder.DropTable(
                name: "AbpUserRoles");

            migrationBuilder.DropTable(
                name: "AbpUserTokens");

            migrationBuilder.DropTable(
                name: "AbpWebhookSendAttempts");

            migrationBuilder.DropTable(
                name: "AbpWebhookSubscriptions");

            migrationBuilder.DropTable(
                name: "account_bal_data");

            migrationBuilder.DropTable(
                name: "AllScores");

            migrationBuilder.DropTable(
                name: "AppBinaryObjects");

            migrationBuilder.DropTable(
                name: "AppChatMessages");

            migrationBuilder.DropTable(
                name: "AppFriendships");

            migrationBuilder.DropTable(
                name: "AppInvoices");

            migrationBuilder.DropTable(
                name: "AppSubscriptionPayments");

            migrationBuilder.DropTable(
                name: "AppSubscriptionPaymentsExtensionData");

            migrationBuilder.DropTable(
                name: "AppUserDelegations");

            migrationBuilder.DropTable(
                name: "collectAttribute");

            migrationBuilder.DropTable(
                name: "credit_preprocessingb");

            migrationBuilder.DropTable(
                name: "CreditScore_CutOff");

            migrationBuilder.DropTable(
                name: "CreditScore_DescriptiveStatistics");

            migrationBuilder.DropTable(
                name: "CreditScore_FeatureSelection");

            migrationBuilder.DropTable(
                name: "CreditScore_LogisticRegEquation");

            migrationBuilder.DropTable(
                name: "CreditScore_LogisticRegression");

            migrationBuilder.DropTable(
                name: "CreditScore_PointAllocation");

            migrationBuilder.DropTable(
                name: "CreditScore_ScoreReport");

            migrationBuilder.DropTable(
                name: "CreditScore_WOE");

            migrationBuilder.DropTable(
                name: "CRTD_Population_Stability_Report");

            migrationBuilder.DropTable(
                name: "CRTD_Roc_Data");

            migrationBuilder.DropTable(
                name: "CRTD_Score_Card_Scaling");

            migrationBuilder.DropTable(
                name: "debt_service_ratio");

            migrationBuilder.DropTable(
                name: "Input_Data");

            migrationBuilder.DropTable(
                name: "IV_Table");

            migrationBuilder.DropTable(
                name: "LoanRequests");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Output_table");

            migrationBuilder.DropTable(
                name: "Profit_Analysis");

            migrationBuilder.DropTable(
                name: "QualitativeSetups");

            migrationBuilder.DropTable(
                name: "Rating_Prediction_Output");

            migrationBuilder.DropTable(
                name: "ratingapplicationscoring");

            migrationBuilder.DropTable(
                name: "Retail_Attributes");

            migrationBuilder.DropTable(
                name: "Score_CDF_Table");

            migrationBuilder.DropTable(
                name: "Selected_Attributes");

            migrationBuilder.DropTable(
                name: "SetUpItems");

            migrationBuilder.DropTable(
                name: "SetupQualitatives");

            migrationBuilder.DropTable(
                name: "SME_Attributes");

            migrationBuilder.DropTable(
                name: "SubHeadingSetups");

            migrationBuilder.DropTable(
                name: "SubSectorSetups");

            migrationBuilder.DropTable(
                name: "Tbl_AccountAuthorize");

            migrationBuilder.DropTable(
                name: "Tbl_AgeDistribution");

            migrationBuilder.DropTable(
                name: "Tbl_AttributeCount");

            migrationBuilder.DropTable(
                name: "Tbl_Attributes");

            migrationBuilder.DropTable(
                name: "Tbl_BankAccount");

            migrationBuilder.DropTable(
                name: "Tbl_BinRanges");

            migrationBuilder.DropTable(
                name: "Tbl_BusRegNig");

            migrationBuilder.DropTable(
                name: "Tbl_CharacteristicsAnalysis");

            migrationBuilder.DropTable(
                name: "Tbl_Components");

            migrationBuilder.DropTable(
                name: "Tbl_CreditLineCondition");

            migrationBuilder.DropTable(
                name: "Tbl_CurrentAccStatusDistribution");

            migrationBuilder.DropTable(
                name: "Tbl_DigSetUp");

            migrationBuilder.DropTable(
                name: "Tbl_Feature_Selection");

            migrationBuilder.DropTable(
                name: "Tbl_FinancialRatio");

            migrationBuilder.DropTable(
                name: "Tbl_GenderType");

            migrationBuilder.DropTable(
                name: "Tbl_GiniCurve");

            migrationBuilder.DropTable(
                name: "Tbl_GiniInclusives");

            migrationBuilder.DropTable(
                name: "Tbl_GoodBad");

            migrationBuilder.DropTable(
                name: "Tbl_GoodBadInputs");

            migrationBuilder.DropTable(
                name: "Tbl_GoodBadInputsRaw");

            migrationBuilder.DropTable(
                name: "Tbl_HaveBankAccount");

            migrationBuilder.DropTable(
                name: "Tbl_HaveNIN");

            migrationBuilder.DropTable(
                name: "Tbl_Histograms");

            migrationBuilder.DropTable(
                name: "Tbl_IndividualApplication");

            migrationBuilder.DropTable(
                name: "Tbl_KSTestCurve");

            migrationBuilder.DropTable(
                name: "Tbl_Legal");

            migrationBuilder.DropTable(
                name: "Tbl_LendingOutputs");

            migrationBuilder.DropTable(
                name: "Tbl_LoanElibility");

            migrationBuilder.DropTable(
                name: "Tbl_LogisticRegressionInputs");

            migrationBuilder.DropTable(
                name: "Tbl_ObligorRiskRating");

            migrationBuilder.DropTable(
                name: "Tbl_Operation_Eligibity");

            migrationBuilder.DropTable(
                name: "Tbl_Ownership");

            migrationBuilder.DropTable(
                name: "Tbl_PositionInIdustry");

            migrationBuilder.DropTable(
                name: "Tbl_ProductCont");

            migrationBuilder.DropTable(
                name: "Tbl_ProfitAnalysis");

            migrationBuilder.DropTable(
                name: "Tbl_QualitativeAnalysis");

            migrationBuilder.DropTable(
                name: "Tbl_QualitativeAnalysisRating");

            migrationBuilder.DropTable(
                name: "Tbl_QualityAnalysisCutOff");

            migrationBuilder.DropTable(
                name: "Tbl_Rating");

            migrationBuilder.DropTable(
                name: "Tbl_RatingAttributes");

            migrationBuilder.DropTable(
                name: "Tbl_RegOutput");

            migrationBuilder.DropTable(
                name: "Tbl_RegOutputRunDate");

            migrationBuilder.DropTable(
                name: "Tbl_Regression");

            migrationBuilder.DropTable(
                name: "Tbl_RegressionOutputs");

            migrationBuilder.DropTable(
                name: "Tbl_RetailCutoff");

            migrationBuilder.DropTable(
                name: "Tbl_RetailScoring");

            migrationBuilder.DropTable(
                name: "Tbl_RiskAssessment");

            migrationBuilder.DropTable(
                name: "Tbl_RiskRatingItems");

            migrationBuilder.DropTable(
                name: "Tbl_Scaling");

            migrationBuilder.DropTable(
                name: "Tbl_SCMonitoring");

            migrationBuilder.DropTable(
                name: "tbl_score");

            migrationBuilder.DropTable(
                name: "Tbl_ScoreCardReport");

            migrationBuilder.DropTable(
                name: "Tbl_ScoreReports");

            migrationBuilder.DropTable(
                name: "Tbl_ScoretoRating");

            migrationBuilder.DropTable(
                name: "Tbl_ScoringOutputs");

            migrationBuilder.DropTable(
                name: "Tbl_SetupPage");

            migrationBuilder.DropTable(
                name: "Tbl_SMELendingApply");

            migrationBuilder.DropTable(
                name: "Tbl_SMETitle");

            migrationBuilder.DropTable(
                name: "Tbl_SplittingMethod");

            migrationBuilder.DropTable(
                name: "Tbl_StabiltyTrend");

            migrationBuilder.DropTable(
                name: "Tbl_VintageAnalysis");

            migrationBuilder.DropTable(
                name: "TblScoringInputDatas");

            migrationBuilder.DropTable(
                name: "TblWoe_Age");

            migrationBuilder.DropTable(
                name: "TblWoe_PaymentPerformance");

            migrationBuilder.DropTable(
                name: "TblWoe_TimeatJob");

            migrationBuilder.DropTable(
                name: "ULoanRequests");

            migrationBuilder.DropTable(
                name: "Viewbincountpercentage");

            migrationBuilder.DropTable(
                name: "AbpDynamicEntityProperties");

            migrationBuilder.DropTable(
                name: "AbpEntityChanges");

            migrationBuilder.DropTable(
                name: "AbpRoles");

            migrationBuilder.DropTable(
                name: "AbpWebhookEvents");

            migrationBuilder.DropTable(
                name: "AbpEditions");

            migrationBuilder.DropTable(
                name: "AgeGroup");

            migrationBuilder.DropTable(
                name: "AppType");

            migrationBuilder.DropTable(
                name: "Applicant_with_Accno");

            migrationBuilder.DropTable(
                name: "IncomeAttributes");

            migrationBuilder.DropTable(
                name: "LocationGroup");

            migrationBuilder.DropTable(
                name: "ProductTypeAttributes");

            migrationBuilder.DropTable(
                name: "RentGroup");

            migrationBuilder.DropTable(
                name: "RentToIncomeGroup");

            migrationBuilder.DropTable(
                name: "ReturnonAssetsAttributes");

            migrationBuilder.DropTable(
                name: "SectorGroup");

            migrationBuilder.DropTable(
                name: "SetupSubHeadings");

            migrationBuilder.DropTable(
                name: "Tbl_Bank");

            migrationBuilder.DropTable(
                name: "Tbl_LoanType");

            migrationBuilder.DropTable(
                name: "AbpDynamicProperties");

            migrationBuilder.DropTable(
                name: "AbpEntityChangeSets");

            migrationBuilder.DropTable(
                name: "AbpUsers");

            migrationBuilder.DropTable(
                name: "SectionSetups");
        }
    }
}
