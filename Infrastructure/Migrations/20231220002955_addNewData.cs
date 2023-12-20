using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addNewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Dogs",
                newName: "Breed");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cats",
                newName: "Breed");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Birds",
                newName: "Color");

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Dogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Cats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalType = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "AnimalUser",
                columns: table => new
                {
                    AnimalsAnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalUser", x => new { x.AnimalsAnimalId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_AnimalUser_Animals_AnimalsAnimalId",
                        column: x => x.AnimalsAnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalUser_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "AnimalType", "Name" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345678"), "", "TestDogForUnitTests" },
                    { new Guid("12345678-1234-5678-1234-567812345680"), "", "TestCatForUnitTests" },
                    { new Guid("12345678-1234-5678-1234-567812345682"), "", "TestBirdForUnitTestBird1" },
                    { new Guid("12345680-1224-5878-1234-667812345690"), "", "TestBirdForUnitTestBird2" },
                    { new Guid("5b9f99c8-da69-4741-8a0b-17a619a78e2f"), "", "Kity" },
                    { new Guid("6eb4810a-3c3d-456c-a9af-12a9c9ac4d4a"), "", "Max" },
                    { new Guid("71cf39e7-1b71-44c1-ae15-d28be38cf1aa"), "", "Ara" },
                    { new Guid("7275d8f0-d002-42ce-9d4f-fe26b3f0d146"), "", "Vrana" },
                    { new Guid("87432a85-57fc-46a8-864f-af62572b993d"), "", "Sova" },
                    { new Guid("ab41472c-c29d-4767-8b3c-62e471be5936"), "", "Ari" },
                    { new Guid("b3358c43-be74-4c89-a141-b02a44b610bf"), "", "Micko" },
                    { new Guid("b61c6bd1-0aa9-4bb7-af46-cf43cbcd5bca"), "", "Astor" },
                    { new Guid("f3e3805c-b9c3-4f0e-88ef-3aa0f6781e0b"), "", "Azrael" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("047425eb-15a5-4310-9d25-e281ab036868"), "$2a$11$Pi/8GysOPuSjjWtgAji.KOP6549LqYfBh4gqArxKJKc/t9zjXFiUW", "user", "NotAnAdmin" },
                    { new Guid("047425eb-15a5-4310-9d25-e281ab036869"), "$2a$11$ZA1DbFEisNF4HhkiQvCBF./FHhQ9Nra.pCYhkiw3MfllL7aFdjuGe", "user", "TestUser" },
                    { new Guid("08260479-52a0-4c0e-a588-274101a2c3be"), "$2a$11$xnBzx/ygATSZerKyMiOJY.rmP7nQ2W.Kk2pR0UOcK4TSx8./cBUe2", "admin", "Bojan" }
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
                    { new Guid("12345678-1234-5678-1234-567812345682"), false, "blue" },
                    { new Guid("12345680-1224-5878-1234-667812345690"), false, "blue" },
                    { new Guid("71cf39e7-1b71-44c1-ae15-d28be38cf1aa"), false, "Red" },
                    { new Guid("7275d8f0-d002-42ce-9d4f-fe26b3f0d146"), true, "Black" },
                    { new Guid("87432a85-57fc-46a8-864f-af62572b993d"), true, "Grey" }
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "AnimalId", "Breed", "LikesToPlay", "Weight" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345680"), "Domestic Cat", false, 6 },
                    { new Guid("5b9f99c8-da69-4741-8a0b-17a619a78e2f"), "Persian Cat", true, 4 },
                    { new Guid("b3358c43-be74-4c89-a141-b02a44b610bf"), "Domestic Cat", true, 6 },
                    { new Guid("f3e3805c-b9c3-4f0e-88ef-3aa0f6781e0b"), "Siamese Cat", false, 6 }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "AnimalId", "Breed", "Weight" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345678"), "German Terrire", 9 },
                    { new Guid("6eb4810a-3c3d-456c-a9af-12a9c9ac4d4a"), "German Shepherd", 37 },
                    { new Guid("ab41472c-c29d-4767-8b3c-62e471be5936"), "English Pointer", 31 },
                    { new Guid("b61c6bd1-0aa9-4bb7-af46-cf43cbcd5bca"), "English Pointer", 28 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalUser_UsersUserId",
                table: "AnimalUser",
                column: "UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Birds_Animals_AnimalId",
                table: "Birds",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cats_Animals_AnimalId",
                table: "Cats",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Animals_AnimalId",
                table: "Dogs",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Birds_Animals_AnimalId",
                table: "Birds");

            migrationBuilder.DropForeignKey(
                name: "FK_Cats_Animals_AnimalId",
                table: "Cats");

            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Animals_AnimalId",
                table: "Dogs");

            migrationBuilder.DropTable(
                name: "AnimalUser");

            migrationBuilder.DropTable(
                name: "UsersHaveAnimals");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "AnimalId",
                keyValue: new Guid("12345678-1234-5678-1234-567812345682"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "AnimalId",
                keyValue: new Guid("12345680-1224-5878-1234-667812345690"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "AnimalId",
                keyValue: new Guid("71cf39e7-1b71-44c1-ae15-d28be38cf1aa"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "AnimalId",
                keyValue: new Guid("7275d8f0-d002-42ce-9d4f-fe26b3f0d146"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "AnimalId",
                keyValue: new Guid("87432a85-57fc-46a8-864f-af62572b993d"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "AnimalId",
                keyValue: new Guid("12345678-1234-5678-1234-567812345680"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "AnimalId",
                keyValue: new Guid("5b9f99c8-da69-4741-8a0b-17a619a78e2f"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "AnimalId",
                keyValue: new Guid("b3358c43-be74-4c89-a141-b02a44b610bf"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "AnimalId",
                keyValue: new Guid("f3e3805c-b9c3-4f0e-88ef-3aa0f6781e0b"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "AnimalId",
                keyValue: new Guid("12345678-1234-5678-1234-567812345678"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "AnimalId",
                keyValue: new Guid("6eb4810a-3c3d-456c-a9af-12a9c9ac4d4a"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "AnimalId",
                keyValue: new Guid("ab41472c-c29d-4767-8b3c-62e471be5936"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "AnimalId",
                keyValue: new Guid("b61c6bd1-0aa9-4bb7-af46-cf43cbcd5bca"));

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Cats");

            migrationBuilder.RenameColumn(
                name: "Breed",
                table: "Dogs",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Breed",
                table: "Cats",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Birds",
                newName: "Name");
        }
    }
}
