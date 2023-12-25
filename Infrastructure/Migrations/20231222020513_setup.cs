using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class setup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.AnimalId);
                });

            migrationBuilder.CreateTable(
                name: "UsersHaveAnimals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersHaveAnimals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Birds",
                columns: table => new
                {
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanFly = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birds", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Birds_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    LikesToPlay = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Cats_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Dogs_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "AnimalId");
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "AnimalId", "AnimalType", "Name" },
                values: new object[,]
                {
                    { new Guid("10c9e943-49e7-44cb-bd06-c809185438dd"), "", "Ara" },
                    { new Guid("12345678-1234-5678-1234-567812345678"), "", "TestDogForUnitTests" },
                    { new Guid("12345678-1234-5678-1234-567812345680"), "", "TestCatForUnitTests" },
                    { new Guid("12345678-1234-5678-1234-567812345682"), "", "TestBirdForUnitTestBird1" },
                    { new Guid("12345680-1224-5878-1234-667812345690"), "", "TestBirdForUnitTestBird2" },
                    { new Guid("2d4e07c0-4277-4779-bee7-8ac4a6fa331e"), "", "Sova" },
                    { new Guid("5a0eaeb0-7dd3-4100-aa79-f0add7c49d67"), "", "Kity" },
                    { new Guid("5e2efcf6-072b-4838-914c-a4c39cf10ded"), "", "Max" },
                    { new Guid("93a5f790-f162-4e19-9fd8-8018e1cbc259"), "", "Astor" },
                    { new Guid("968dea87-60e2-4093-a191-d77e6a41e033"), "", "Micko" },
                    { new Guid("c4feb719-e1a4-47c5-a278-c2e94fcc54be"), "", "Vrana" },
                    { new Guid("d54d24c3-975a-413e-b2b5-55e57cc0a878"), "", "Ari" },
                    { new Guid("f9d68585-a161-4087-8373-fe70a7b59eb0"), "", "Azrael" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AnimalId", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("047425eb-15a5-4310-9d25-e281ab036868"), null, "$2a$11$3zu0cm.HElaHpTsdEOrP.Ob3Ev9ggpkMfY6OFdpnTZy/F.sYXWNTa", "user", "NotAnAdmin" },
                    { new Guid("047425eb-15a5-4310-9d25-e281ab036869"), null, "$2a$11$qWEsMalco3HiM.tEQst5We3mGrReV/7V0S/0QAI0xjLjAkWfLF/su", "user", "TestUser" },
                    { new Guid("08260479-52a0-4c0e-a588-274101a2c3be"), null, "$2a$11$WyqaeU.YeLlrYqo7sDlDIOty0sIzpkG3l.W1rxX..Ho9g882nR4RO", "admin", "Bojan" }
                });

            migrationBuilder.InsertData(
                table: "UsersHaveAnimals",
                columns: new[] { "Id", "AnimalId", "UserId" },
                values: new object[,]
                {
                    { -4, new Guid("12345680-1224-5878-1234-667812345690"), new Guid("047425eb-15a5-4310-9d25-e281ab036868") },
                    { -3, new Guid("12345678-1234-5678-1234-567812345682"), new Guid("047425eb-15a5-4310-9d25-e281ab036868") },
                    { -2, new Guid("12345680-1224-5878-1234-667812345690"), new Guid("08260479-52a0-4c0e-a588-274101a2c3be") },
                    { -1, new Guid("12345678-1234-5678-1234-567812345682"), new Guid("08260479-52a0-4c0e-a588-274101a2c3be") }
                });

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "AnimalId", "CanFly", "Color" },
                values: new object[,]
                {
                    { new Guid("10c9e943-49e7-44cb-bd06-c809185438dd"), false, "Red" },
                    { new Guid("12345678-1234-5678-1234-567812345682"), false, "blue" },
                    { new Guid("12345680-1224-5878-1234-667812345690"), false, "blue" },
                    { new Guid("2d4e07c0-4277-4779-bee7-8ac4a6fa331e"), true, "Grey" },
                    { new Guid("c4feb719-e1a4-47c5-a278-c2e94fcc54be"), true, "Black" }
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "AnimalId", "Breed", "LikesToPlay", "Weight" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345680"), "Domestic Cat", false, 6 },
                    { new Guid("5a0eaeb0-7dd3-4100-aa79-f0add7c49d67"), "Persian Cat", true, 4 },
                    { new Guid("968dea87-60e2-4093-a191-d77e6a41e033"), "Domestic Cat", true, 6 },
                    { new Guid("f9d68585-a161-4087-8373-fe70a7b59eb0"), "Siamese Cat", false, 6 }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "AnimalId", "Breed", "Weight" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345678"), "German Terrire", 9 },
                    { new Guid("5e2efcf6-072b-4838-914c-a4c39cf10ded"), "German Shepherd", 37 },
                    { new Guid("93a5f790-f162-4e19-9fd8-8018e1cbc259"), "English Pointer", 28 },
                    { new Guid("d54d24c3-975a-413e-b2b5-55e57cc0a878"), "English Pointer", 31 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AnimalId",
                table: "Users",
                column: "AnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Birds");

            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UsersHaveAnimals");

            migrationBuilder.DropTable(
                name: "Animal");
        }
    }
}
