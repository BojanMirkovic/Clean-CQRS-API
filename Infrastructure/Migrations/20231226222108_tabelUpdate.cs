using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class tabelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
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
                        name: "FK_Birds_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
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
                        name: "FK_Cats_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
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
                        name: "FK_Dogs_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "AnimalType", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345678"), "Dog", "TestDogForUnitTests", null },
                    { new Guid("12345678-1234-5678-1234-567812345680"), "Cat", "TestCatForUnitTests", null },
                    { new Guid("12345678-1234-5678-1234-567812345682"), "Bird", "TestBirdForUnitTestBird1", null },
                    { new Guid("12345680-1224-5878-1234-667812345690"), "Bird", "TestBirdForUnitTestBird2", null },
                    { new Guid("3bddcce1-5b65-4b5d-8b81-4b2978e9dadc"), "Bird", "Ara", null },
                    { new Guid("6498bca8-ebab-45d7-8936-5635afc05721"), "Cat", "Azrael", null },
                    { new Guid("6ad7ab00-2e9f-4c6c-a1dd-bfe7425ed329"), "Dog", "Ari", null },
                    { new Guid("7f7994ed-0508-4474-9d84-99be962c2fa8"), "Bird", "Sova", null },
                    { new Guid("a210c7b9-1d07-43e7-834c-27bc0a8b5ead"), "Cat", "Kity", null },
                    { new Guid("c047c84c-7827-43bc-b2ee-0fde2936d171"), "Dog", "Astor", null },
                    { new Guid("c1c5d6d5-d209-49c4-8313-30c90bfef3dc"), "Cat", "Micko", null },
                    { new Guid("debb6b0a-a1c1-410f-a75a-979bf09af4fc"), "Bird", "Vrana", null },
                    { new Guid("fb3bfb09-f7bf-4f7a-9495-75a25dba48e3"), "Dog", "Max", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("047425eb-15a5-4310-9d25-e281ab036868"), "$2a$11$EHmReaSAE1koOfh0tO/krOXm1Sx7nJ3Hs1YBCR5PBF2BxIN69UBa.", "user", "NotAnAdmin" },
                    { new Guid("047425eb-15a5-4310-9d25-e281ab036869"), "$2a$11$2WHuDaCJajagIx9fuu7Db.Er7OT0ZdP53RjoorVWfiv.R/XW23MZu", "user", "TestUser" },
                    { new Guid("08260479-52a0-4c0e-a588-274101a2c3be"), "$2a$11$xxYuGtY3fJovEG/Izz1dJuE0mAClMoty/QWhocYI0iFVjVqqrYBBe", "admin", "Bojan" }
                });

            migrationBuilder.InsertData(
                table: "UsersHaveAnimals",
                columns: new[] { "Id", "AnimalId", "UserId" },
                values: new object[,]
                {
                    { -5, new Guid("12345680-1224-5878-1234-667812345690"), new Guid("047425eb-15a5-4310-9d25-e281ab036868") },
                    { -4, new Guid("12345678-1234-5678-1234-567812345682"), new Guid("047425eb-15a5-4310-9d25-e281ab036868") },
                    { -3, new Guid("12345678-1234-5678-1234-567812345682"), new Guid("08260479-52a0-4c0e-a588-274101a2c3be") },
                    { -2, new Guid("12345680-1224-5878-1234-667812345690"), new Guid("08260479-52a0-4c0e-a588-274101a2c3be") },
                    { -1, new Guid("12345678-1234-5678-1234-567812345682"), new Guid("08260479-52a0-4c0e-a588-274101a2c3be") }
                });

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "AnimalId", "CanFly", "Color" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345682"), false, "blue" },
                    { new Guid("12345680-1224-5878-1234-667812345690"), false, "blue" },
                    { new Guid("3bddcce1-5b65-4b5d-8b81-4b2978e9dadc"), false, "Red" },
                    { new Guid("7f7994ed-0508-4474-9d84-99be962c2fa8"), true, "Grey" },
                    { new Guid("debb6b0a-a1c1-410f-a75a-979bf09af4fc"), true, "Black" }
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "AnimalId", "Breed", "LikesToPlay", "Weight" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345680"), "Domestic Cat", false, 6 },
                    { new Guid("6498bca8-ebab-45d7-8936-5635afc05721"), "Siamese Cat", false, 6 },
                    { new Guid("a210c7b9-1d07-43e7-834c-27bc0a8b5ead"), "Persian Cat", true, 4 },
                    { new Guid("c1c5d6d5-d209-49c4-8313-30c90bfef3dc"), "Domestic Cat", true, 6 }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "AnimalId", "Breed", "Weight" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345678"), "German Terrire", 9 },
                    { new Guid("6ad7ab00-2e9f-4c6c-a1dd-bfe7425ed329"), "English Pointer", 31 },
                    { new Guid("c047c84c-7827-43bc-b2ee-0fde2936d171"), "English Pointer", 28 },
                    { new Guid("fb3bfb09-f7bf-4f7a-9495-75a25dba48e3"), "German Shepherd", 37 }
                });
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
                name: "Animals");
        }
    }
}
