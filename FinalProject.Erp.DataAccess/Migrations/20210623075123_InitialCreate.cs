using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Erp.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gsm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sehir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ilce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostaKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Birim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirimAdi = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Aciklama = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Kod = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenlemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GeriAlmaTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EkleyenId = table.Column<int>(type: "int", nullable: true),
                    DuzenleyenId = table.Column<int>(type: "int", nullable: true),
                    SilenId = table.Column<int>(type: "int", nullable: true),
                    GeriAlanId = table.Column<int>(type: "int", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CariGrubu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CariGrubuAdi = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Aciklama = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Kod = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenlemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GeriAlmaTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EkleyenId = table.Column<int>(type: "int", nullable: true),
                    DuzenleyenId = table.Column<int>(type: "int", nullable: true),
                    SilenId = table.Column<int>(type: "int", nullable: true),
                    GeriAlanId = table.Column<int>(type: "int", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariGrubu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Depo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepoAdi = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Yetkili = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Aciklama = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Kod = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenlemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GeriAlmaTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EkleyenId = table.Column<int>(type: "int", nullable: true),
                    DuzenleyenId = table.Column<int>(type: "int", nullable: true),
                    SilenId = table.Column<int>(type: "int", nullable: true),
                    GeriAlanId = table.Column<int>(type: "int", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DovizKur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<DateTime>(type: "datetime", nullable: false),
                    DovizKodu = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true),
                    DovizCinsi = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Birim = table.Column<short>(type: "smallint", nullable: false),
                    DovizAlis = table.Column<decimal>(type: "decimal(8,4)", precision: 8, scale: 4, nullable: false),
                    DovizSatis = table.Column<decimal>(type: "decimal(8,4)", precision: 8, scale: 4, nullable: false),
                    EfektifAlis = table.Column<decimal>(type: "decimal(8,4)", precision: 8, scale: 4, nullable: false),
                    EfektifSatis = table.Column<decimal>(type: "decimal(8,4)", precision: 8, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DovizKur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marka",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkaAdi = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Aciklama = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Kod = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenlemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GeriAlmaTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EkleyenId = table.Column<int>(type: "int", nullable: true),
                    DuzenleyenId = table.Column<int>(type: "int", nullable: true),
                    SilenId = table.Column<int>(type: "int", nullable: true),
                    GeriAlanId = table.Column<int>(type: "int", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marka", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OzelKod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OzelKodTip = table.Column<int>(type: "int", nullable: false),
                    OzelKodSira = table.Column<int>(type: "int", nullable: false),
                    OzelKodAdi = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Aciklama = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Kod = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenlemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GeriAlmaTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EkleyenId = table.Column<int>(type: "int", nullable: true),
                    DuzenleyenId = table.Column<int>(type: "int", nullable: true),
                    SilenId = table.Column<int>(type: "int", nullable: true),
                    GeriAlanId = table.Column<int>(type: "int", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OzelKod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sehir",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SehirAdi = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Aciklama = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Kod = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenlemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GeriAlmaTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EkleyenId = table.Column<int>(type: "int", nullable: true),
                    DuzenleyenId = table.Column<int>(type: "int", nullable: true),
                    SilenId = table.Column<int>(type: "int", nullable: true),
                    GeriAlanId = table.Column<int>(type: "int", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sehir", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StokGrubu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StokGrubuAdi = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Aciklama = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Kod = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenlemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GeriAlmaTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EkleyenId = table.Column<int>(type: "int", nullable: true),
                    DuzenleyenId = table.Column<int>(type: "int", nullable: true),
                    SilenId = table.Column<int>(type: "int", nullable: true),
                    GeriAlanId = table.Column<int>(type: "int", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StokGrubu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StokTur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StokTurAdi = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Aciklama = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Kod = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenlemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GeriAlmaTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EkleyenId = table.Column<int>(type: "int", nullable: true),
                    DuzenleyenId = table.Column<int>(type: "int", nullable: true),
                    SilenId = table.Column<int>(type: "int", nullable: true),
                    GeriAlanId = table.Column<int>(type: "int", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StokTur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ulke",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UlkeAdi = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Aciklama = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Kod = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenlemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GeriAlmaTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EkleyenId = table.Column<int>(type: "int", nullable: true),
                    DuzenleyenId = table.Column<int>(type: "int", nullable: true),
                    SilenId = table.Column<int>(type: "int", nullable: true),
                    GeriAlanId = table.Column<int>(type: "int", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ulke", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CariAltGrubu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CariGrubuId = table.Column<int>(type: "int", nullable: false),
                    CariAltGrubuAdi = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Aciklama = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Kod = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenlemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GeriAlmaTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EkleyenId = table.Column<int>(type: "int", nullable: true),
                    DuzenleyenId = table.Column<int>(type: "int", nullable: true),
                    SilenId = table.Column<int>(type: "int", nullable: true),
                    GeriAlanId = table.Column<int>(type: "int", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariAltGrubu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CariAltGrubu_CariGrubu_CariGrubuId",
                        column: x => x.CariGrubuId,
                        principalTable: "CariGrubu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkaId = table.Column<int>(type: "int", nullable: false),
                    ModelAdi = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Aciklama = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Kod = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenlemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GeriAlmaTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EkleyenId = table.Column<int>(type: "int", nullable: true),
                    DuzenleyenId = table.Column<int>(type: "int", nullable: true),
                    SilenId = table.Column<int>(type: "int", nullable: true),
                    GeriAlanId = table.Column<int>(type: "int", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Model_Marka_MarkaId",
                        column: x => x.MarkaId,
                        principalTable: "Marka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Banka",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankaAdi = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    BankaSube = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    HesapNo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    IbanNo = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    Yetkili = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    OzelKod1Id = table.Column<int>(type: "int", nullable: true),
                    Telefon = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Faks = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Gsm = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Web = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Aciklama = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Kod = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenlemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GeriAlmaTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EkleyenId = table.Column<int>(type: "int", nullable: true),
                    DuzenleyenId = table.Column<int>(type: "int", nullable: true),
                    SilenId = table.Column<int>(type: "int", nullable: true),
                    GeriAlanId = table.Column<int>(type: "int", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banka_OzelKod_OzelKod1Id",
                        column: x => x.OzelKod1Id,
                        principalTable: "OzelKod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kasa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KasaAdi = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Yetkili = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    OzelKod1Id = table.Column<int>(type: "int", nullable: true),
                    Aciklama = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Kod = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenlemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GeriAlmaTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EkleyenId = table.Column<int>(type: "int", nullable: true),
                    DuzenleyenId = table.Column<int>(type: "int", nullable: true),
                    SilenId = table.Column<int>(type: "int", nullable: true),
                    GeriAlanId = table.Column<int>(type: "int", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kasa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kasa_OzelKod_OzelKod1Id",
                        column: x => x.OzelKod1Id,
                        principalTable: "OzelKod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ilce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SehirId = table.Column<int>(type: "int", nullable: false),
                    IlceAdi = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Aciklama = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Kod = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenlemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GeriAlmaTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EkleyenId = table.Column<int>(type: "int", nullable: true),
                    DuzenleyenId = table.Column<int>(type: "int", nullable: true),
                    SilenId = table.Column<int>(type: "int", nullable: true),
                    GeriAlanId = table.Column<int>(type: "int", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilce", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ilce_Sehir_SehirId",
                        column: x => x.SehirId,
                        principalTable: "Sehir",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StokAltGrubu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StokGrubuId = table.Column<int>(type: "int", nullable: false),
                    StokAltGrubuAdi = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Aciklama = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Kod = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenlemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GeriAlmaTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EkleyenId = table.Column<int>(type: "int", nullable: true),
                    DuzenleyenId = table.Column<int>(type: "int", nullable: true),
                    SilenId = table.Column<int>(type: "int", nullable: true),
                    GeriAlanId = table.Column<int>(type: "int", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StokAltGrubu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StokAltGrubu_StokGrubu_StokGrubuId",
                        column: x => x.StokGrubuId,
                        principalTable: "StokGrubu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CariTipi = table.Column<byte>(type: "tinyint", nullable: false),
                    CariUnvani = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Yetkili = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CariGrubuId = table.Column<int>(type: "int", nullable: true),
                    CariAltGrubuId = table.Column<int>(type: "int", nullable: true),
                    FiyatGrubu = table.Column<byte>(type: "tinyint", nullable: false),
                    VergiDaire = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    VergiNo = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    TcKimlikNo = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Adres = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    UlkeId = table.Column<int>(type: "int", nullable: true),
                    SehirId = table.Column<int>(type: "int", nullable: true),
                    IlceId = table.Column<int>(type: "int", nullable: true),
                    Telefon = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Faks = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Gsm = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Web = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    OzelKod1Id = table.Column<int>(type: "int", nullable: true),
                    OzelKod2Id = table.Column<int>(type: "int", nullable: true),
                    OzelKod3Id = table.Column<int>(type: "int", nullable: true),
                    Aciklama = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Kod = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenlemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GeriAlmaTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EkleyenId = table.Column<int>(type: "int", nullable: true),
                    DuzenleyenId = table.Column<int>(type: "int", nullable: true),
                    SilenId = table.Column<int>(type: "int", nullable: true),
                    GeriAlanId = table.Column<int>(type: "int", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cari_CariAltGrubu_CariAltGrubuId",
                        column: x => x.CariAltGrubuId,
                        principalTable: "CariAltGrubu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cari_CariGrubu_CariGrubuId",
                        column: x => x.CariGrubuId,
                        principalTable: "CariGrubu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cari_Ilce_IlceId",
                        column: x => x.IlceId,
                        principalTable: "Ilce",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cari_OzelKod_OzelKod1Id",
                        column: x => x.OzelKod1Id,
                        principalTable: "OzelKod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cari_OzelKod_OzelKod2Id",
                        column: x => x.OzelKod2Id,
                        principalTable: "OzelKod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cari_OzelKod_OzelKod3Id",
                        column: x => x.OzelKod3Id,
                        principalTable: "OzelKod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cari_Sehir_SehirId",
                        column: x => x.SehirId,
                        principalTable: "Sehir",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cari_Ulke_UlkeId",
                        column: x => x.UlkeId,
                        principalTable: "Ulke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StokTurId = table.Column<int>(type: "int", nullable: false),
                    StokAdi = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    StokGrubuId = table.Column<int>(type: "int", nullable: true),
                    StokAltGrubuId = table.Column<int>(type: "int", nullable: true),
                    MarkaId = table.Column<int>(type: "int", nullable: true),
                    ModelId = table.Column<int>(type: "int", nullable: true),
                    BirimId = table.Column<int>(type: "int", nullable: false),
                    Barkod = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    AlisKdv = table.Column<short>(type: "smallint", nullable: false),
                    SatisKdv = table.Column<short>(type: "smallint", nullable: false),
                    AlisKdvDurum = table.Column<byte>(type: "tinyint", nullable: false),
                    SatisKdvDurum = table.Column<byte>(type: "tinyint", nullable: false),
                    AlisFiyat1 = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    AlisFiyat2 = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    AlisFiyat3 = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    SatisFiyat1 = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    SatisFiyat2 = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    SatisFiyat3 = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    GecerliFiyat = table.Column<byte>(type: "tinyint", nullable: false),
                    OzelKod1Id = table.Column<int>(type: "int", nullable: true),
                    OzelKod2Id = table.Column<int>(type: "int", nullable: true),
                    OzelKod3Id = table.Column<int>(type: "int", nullable: true),
                    Aciklama = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Kod = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenlemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GeriAlmaTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EkleyenId = table.Column<int>(type: "int", nullable: true),
                    DuzenleyenId = table.Column<int>(type: "int", nullable: true),
                    SilenId = table.Column<int>(type: "int", nullable: true),
                    GeriAlanId = table.Column<int>(type: "int", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stok_Birim_BirimId",
                        column: x => x.BirimId,
                        principalTable: "Birim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stok_Marka_MarkaId",
                        column: x => x.MarkaId,
                        principalTable: "Marka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stok_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stok_OzelKod_OzelKod1Id",
                        column: x => x.OzelKod1Id,
                        principalTable: "OzelKod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stok_OzelKod_OzelKod2Id",
                        column: x => x.OzelKod2Id,
                        principalTable: "OzelKod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stok_OzelKod_OzelKod3Id",
                        column: x => x.OzelKod3Id,
                        principalTable: "OzelKod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stok_StokAltGrubu_StokAltGrubuId",
                        column: x => x.StokAltGrubuId,
                        principalTable: "StokAltGrubu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stok_StokGrubu_StokGrubuId",
                        column: x => x.StokGrubuId,
                        principalTable: "StokGrubu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stok_StokTur_StokTurId",
                        column: x => x.StokTurId,
                        principalTable: "StokTur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankaHareket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankaId = table.Column<int>(type: "int", nullable: false),
                    TransferBankaId = table.Column<int>(type: "int", nullable: true),
                    CariId = table.Column<int>(type: "int", nullable: true),
                    KasaId = table.Column<int>(type: "int", nullable: true),
                    HareketTip = table.Column<byte>(type: "tinyint", nullable: false),
                    GC = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MakbuzNo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Tutar = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    Aciklama = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Kod = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenlemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GeriAlmaTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EkleyenId = table.Column<int>(type: "int", nullable: true),
                    DuzenleyenId = table.Column<int>(type: "int", nullable: true),
                    SilenId = table.Column<int>(type: "int", nullable: true),
                    GeriAlanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankaHareket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankaHareket_Banka_BankaId",
                        column: x => x.BankaId,
                        principalTable: "Banka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankaHareket_Banka_TransferBankaId",
                        column: x => x.TransferBankaId,
                        principalTable: "Banka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankaHareket_Cari_CariId",
                        column: x => x.CariId,
                        principalTable: "Cari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankaHareket_Kasa_KasaId",
                        column: x => x.KasaId,
                        principalTable: "Kasa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CariHareket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CariId = table.Column<int>(type: "int", nullable: false),
                    TransferCariId = table.Column<int>(type: "int", nullable: true),
                    KasaId = table.Column<int>(type: "int", nullable: true),
                    BankaId = table.Column<int>(type: "int", nullable: true),
                    HareketTip = table.Column<byte>(type: "tinyint", nullable: false),
                    GC = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MakbuzNo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Tutar = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    Aciklama = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Kod = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenlemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GeriAlmaTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EkleyenId = table.Column<int>(type: "int", nullable: true),
                    DuzenleyenId = table.Column<int>(type: "int", nullable: true),
                    SilenId = table.Column<int>(type: "int", nullable: true),
                    GeriAlanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariHareket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CariHareket_Banka_BankaId",
                        column: x => x.BankaId,
                        principalTable: "Banka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CariHareket_Cari_CariId",
                        column: x => x.CariId,
                        principalTable: "Cari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CariHareket_Cari_TransferCariId",
                        column: x => x.TransferCariId,
                        principalTable: "Cari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CariHareket_Kasa_KasaId",
                        column: x => x.KasaId,
                        principalTable: "Kasa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KasaHareket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KasaId = table.Column<int>(type: "int", nullable: false),
                    TransferKasaId = table.Column<int>(type: "int", nullable: true),
                    CariId = table.Column<int>(type: "int", nullable: true),
                    BankaId = table.Column<int>(type: "int", nullable: true),
                    HareketTip = table.Column<byte>(type: "tinyint", nullable: false),
                    GC = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MakbuzNo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Tutar = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    Aciklama = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Kod = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    EklemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzenlemeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GeriAlmaTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EkleyenId = table.Column<int>(type: "int", nullable: true),
                    DuzenleyenId = table.Column<int>(type: "int", nullable: true),
                    SilenId = table.Column<int>(type: "int", nullable: true),
                    GeriAlanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KasaHareket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KasaHareket_Banka_BankaId",
                        column: x => x.BankaId,
                        principalTable: "Banka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KasaHareket_Cari_CariId",
                        column: x => x.CariId,
                        principalTable: "Cari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KasaHareket_Kasa_KasaId",
                        column: x => x.KasaId,
                        principalTable: "Kasa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KasaHareket_Kasa_TransferKasaId",
                        column: x => x.TransferKasaId,
                        principalTable: "Kasa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Banka_BankaAdi",
                table: "Banka",
                column: "BankaAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Banka_Kod",
                table: "Banka",
                column: "Kod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Banka_OzelKod1Id",
                table: "Banka",
                column: "OzelKod1Id");

            migrationBuilder.CreateIndex(
                name: "IX_BankaHareket_BankaId",
                table: "BankaHareket",
                column: "BankaId");

            migrationBuilder.CreateIndex(
                name: "IX_BankaHareket_CariId",
                table: "BankaHareket",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_BankaHareket_KasaId",
                table: "BankaHareket",
                column: "KasaId");

            migrationBuilder.CreateIndex(
                name: "IX_BankaHareket_Kod",
                table: "BankaHareket",
                column: "Kod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankaHareket_TransferBankaId",
                table: "BankaHareket",
                column: "TransferBankaId");

            migrationBuilder.CreateIndex(
                name: "IX_Birim_BirimAdi",
                table: "Birim",
                column: "BirimAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Birim_Kod",
                table: "Birim",
                column: "Kod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cari_CariAltGrubuId",
                table: "Cari",
                column: "CariAltGrubuId");

            migrationBuilder.CreateIndex(
                name: "IX_Cari_CariGrubuId",
                table: "Cari",
                column: "CariGrubuId");

            migrationBuilder.CreateIndex(
                name: "IX_Cari_CariUnvani",
                table: "Cari",
                column: "CariUnvani",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cari_IlceId",
                table: "Cari",
                column: "IlceId");

            migrationBuilder.CreateIndex(
                name: "IX_Cari_Kod",
                table: "Cari",
                column: "Kod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cari_OzelKod1Id",
                table: "Cari",
                column: "OzelKod1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cari_OzelKod2Id",
                table: "Cari",
                column: "OzelKod2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cari_OzelKod3Id",
                table: "Cari",
                column: "OzelKod3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cari_SehirId",
                table: "Cari",
                column: "SehirId");

            migrationBuilder.CreateIndex(
                name: "IX_Cari_UlkeId",
                table: "Cari",
                column: "UlkeId");

            migrationBuilder.CreateIndex(
                name: "IX_CariAltGrubu_CariGrubuId",
                table: "CariAltGrubu",
                column: "CariGrubuId");

            migrationBuilder.CreateIndex(
                name: "IX_CariGrubu_CariGrubuAdi",
                table: "CariGrubu",
                column: "CariGrubuAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CariGrubu_Kod",
                table: "CariGrubu",
                column: "Kod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CariHareket_BankaId",
                table: "CariHareket",
                column: "BankaId");

            migrationBuilder.CreateIndex(
                name: "IX_CariHareket_CariId",
                table: "CariHareket",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_CariHareket_KasaId",
                table: "CariHareket",
                column: "KasaId");

            migrationBuilder.CreateIndex(
                name: "IX_CariHareket_Kod",
                table: "CariHareket",
                column: "Kod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CariHareket_TransferCariId",
                table: "CariHareket",
                column: "TransferCariId");

            migrationBuilder.CreateIndex(
                name: "IX_Depo_DepoAdi",
                table: "Depo",
                column: "DepoAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Depo_Kod",
                table: "Depo",
                column: "Kod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ilce_SehirId",
                table: "Ilce",
                column: "SehirId");

            migrationBuilder.CreateIndex(
                name: "IX_Kasa_KasaAdi",
                table: "Kasa",
                column: "KasaAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kasa_Kod",
                table: "Kasa",
                column: "Kod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kasa_OzelKod1Id",
                table: "Kasa",
                column: "OzelKod1Id");

            migrationBuilder.CreateIndex(
                name: "IX_KasaHareket_BankaId",
                table: "KasaHareket",
                column: "BankaId");

            migrationBuilder.CreateIndex(
                name: "IX_KasaHareket_CariId",
                table: "KasaHareket",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_KasaHareket_KasaId",
                table: "KasaHareket",
                column: "KasaId");

            migrationBuilder.CreateIndex(
                name: "IX_KasaHareket_Kod",
                table: "KasaHareket",
                column: "Kod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KasaHareket_TransferKasaId",
                table: "KasaHareket",
                column: "TransferKasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Marka_Kod",
                table: "Marka",
                column: "Kod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Marka_MarkaAdi",
                table: "Marka",
                column: "MarkaAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Model_MarkaId",
                table: "Model",
                column: "MarkaId");

            migrationBuilder.CreateIndex(
                name: "IX_OzelKod_Kod",
                table: "OzelKod",
                column: "Kod");

            migrationBuilder.CreateIndex(
                name: "IX_OzelKod_OzelKodAdi",
                table: "OzelKod",
                column: "OzelKodAdi");

            migrationBuilder.CreateIndex(
                name: "IX_Sehir_Kod",
                table: "Sehir",
                column: "Kod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sehir_SehirAdi",
                table: "Sehir",
                column: "SehirAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stok_BirimId",
                table: "Stok",
                column: "BirimId");

            migrationBuilder.CreateIndex(
                name: "IX_Stok_Kod",
                table: "Stok",
                column: "Kod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stok_MarkaId",
                table: "Stok",
                column: "MarkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Stok_ModelId",
                table: "Stok",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Stok_OzelKod1Id",
                table: "Stok",
                column: "OzelKod1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stok_OzelKod2Id",
                table: "Stok",
                column: "OzelKod2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stok_OzelKod3Id",
                table: "Stok",
                column: "OzelKod3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stok_StokAdi",
                table: "Stok",
                column: "StokAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stok_StokAltGrubuId",
                table: "Stok",
                column: "StokAltGrubuId");

            migrationBuilder.CreateIndex(
                name: "IX_Stok_StokGrubuId",
                table: "Stok",
                column: "StokGrubuId");

            migrationBuilder.CreateIndex(
                name: "IX_Stok_StokTurId",
                table: "Stok",
                column: "StokTurId");

            migrationBuilder.CreateIndex(
                name: "IX_StokAltGrubu_StokGrubuId",
                table: "StokAltGrubu",
                column: "StokGrubuId");

            migrationBuilder.CreateIndex(
                name: "IX_StokGrubu_Kod",
                table: "StokGrubu",
                column: "Kod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StokGrubu_StokGrubuAdi",
                table: "StokGrubu",
                column: "StokGrubuAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StokTur_Kod",
                table: "StokTur",
                column: "Kod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StokTur_StokTurAdi",
                table: "StokTur",
                column: "StokTurAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ulke_Kod",
                table: "Ulke",
                column: "Kod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ulke_UlkeAdi",
                table: "Ulke",
                column: "UlkeAdi",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BankaHareket");

            migrationBuilder.DropTable(
                name: "CariHareket");

            migrationBuilder.DropTable(
                name: "Depo");

            migrationBuilder.DropTable(
                name: "DovizKur");

            migrationBuilder.DropTable(
                name: "KasaHareket");

            migrationBuilder.DropTable(
                name: "Stok");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Banka");

            migrationBuilder.DropTable(
                name: "Cari");

            migrationBuilder.DropTable(
                name: "Kasa");

            migrationBuilder.DropTable(
                name: "Birim");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "StokAltGrubu");

            migrationBuilder.DropTable(
                name: "StokTur");

            migrationBuilder.DropTable(
                name: "CariAltGrubu");

            migrationBuilder.DropTable(
                name: "Ilce");

            migrationBuilder.DropTable(
                name: "Ulke");

            migrationBuilder.DropTable(
                name: "OzelKod");

            migrationBuilder.DropTable(
                name: "Marka");

            migrationBuilder.DropTable(
                name: "StokGrubu");

            migrationBuilder.DropTable(
                name: "CariGrubu");

            migrationBuilder.DropTable(
                name: "Sehir");
        }
    }
}
