using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserTabelHasAnimalIdFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "AnimalId",
                keyValue: new Guid("10c9e943-49e7-44cb-bd06-c809185438dd"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "AnimalId",
                keyValue: new Guid("2d4e07c0-4277-4779-bee7-8ac4a6fa331e"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "AnimalId",
                keyValue: new Guid("c4feb719-e1a4-47c5-a278-c2e94fcc54be"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "AnimalId",
                keyValue: new Guid("5a0eaeb0-7dd3-4100-aa79-f0add7c49d67"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "AnimalId",
                keyValue: new Guid("968dea87-60e2-4093-a191-d77e6a41e033"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "AnimalId",
                keyValue: new Guid("f9d68585-a161-4087-8373-fe70a7b59eb0"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "AnimalId",
                keyValue: new Guid("5e2efcf6-072b-4838-914c-a4c39cf10ded"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "AnimalId",
                keyValue: new Guid("93a5f790-f162-4e19-9fd8-8018e1cbc259"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "AnimalId",
                keyValue: new Guid("d54d24c3-975a-413e-b2b5-55e57cc0a878"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: new Guid("10c9e943-49e7-44cb-bd06-c809185438dd"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: new Guid("2d4e07c0-4277-4779-bee7-8ac4a6fa331e"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: new Guid("5a0eaeb0-7dd3-4100-aa79-f0add7c49d67"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: new Guid("5e2efcf6-072b-4838-914c-a4c39cf10ded"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: new Guid("93a5f790-f162-4e19-9fd8-8018e1cbc259"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: new Guid("968dea87-60e2-4093-a191-d77e6a41e033"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: new Guid("c4feb719-e1a4-47c5-a278-c2e94fcc54be"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: new Guid("d54d24c3-975a-413e-b2b5-55e57cc0a878"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: new Guid("f9d68585-a161-4087-8373-fe70a7b59eb0"));

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "AnimalId", "AnimalType", "Name" },
                values: new object[,]
                {
                    { new Guid("032f97dc-f536-4bf5-99f6-3160f4f3a4d9"), "", "Ari" },
                    { new Guid("056bae45-79b7-4c2f-9e6b-26d3f543565b"), "", "Micko" },
                    { new Guid("132379ea-8748-4273-a6aa-b1002dbd80ca"), "", "Kity" },
                    { new Guid("490da8d5-3730-4906-8166-706bcd1a49f9"), "", "Azrael" },
                    { new Guid("60dcdf09-7955-4954-bbc5-d2ce66b625c2"), "", "Ara" },
                    { new Guid("7197e6de-c10f-46c2-a7b6-ed7c6d3091d2"), "", "Max" },
                    { new Guid("753f500f-1970-4d75-b29e-ac83f148c55b"), "", "Vrana" },
                    { new Guid("ad6842f9-9935-4c6d-b177-f66d589260a0"), "", "Astor" },
                    { new Guid("e7bdcf6f-7481-4112-9266-84eb1242f45d"), "", "Sova" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("047425eb-15a5-4310-9d25-e281ab036868"),
                column: "Password",
                value: "$2a$11$z3SI1lzAN1hybO21WC1aqevBj4G99rC8EDbjLKXnO82tbHIQeCg2u");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("047425eb-15a5-4310-9d25-e281ab036869"),
                column: "Password",
                value: "$2a$11$iWdG8Ngglhy5Br7F8g9zIejQOVV4xv0koIOZ90gHtE70OURzZvFOG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("08260479-52a0-4c0e-a588-274101a2c3be"),
                column: "Password",
                value: "$2a$11$jj292GecTuOwiDYy9vTUC.S1IkY/kvDF2K9XZlIKiYT9eiYyaJDfO");

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "AnimalId", "CanFly", "Color" },
                values: new object[,]
                {
                    { new Guid("60dcdf09-7955-4954-bbc5-d2ce66b625c2"), false, "Red" },
                    { new Guid("753f500f-1970-4d75-b29e-ac83f148c55b"), true, "Black" },
                    { new Guid("e7bdcf6f-7481-4112-9266-84eb1242f45d"), true, "Grey" }
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "AnimalId", "Breed", "LikesToPlay", "Weight" },
                values: new object[,]
                {
                    { new Guid("056bae45-79b7-4c2f-9e6b-26d3f543565b"), "Domestic Cat", true, 6 },
                    { new Guid("132379ea-8748-4273-a6aa-b1002dbd80ca"), "Persian Cat", true, 4 },
                    { new Guid("490da8d5-3730-4906-8166-706bcd1a49f9"), "Siamese Cat", false, 6 }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "AnimalId", "Breed", "Weight" },
                values: new object[,]
                {
                    { new Guid("032f97dc-f536-4bf5-99f6-3160f4f3a4d9"), "English Pointer", 31 },
                    { new Guid("7197e6de-c10f-46c2-a7b6-ed7c6d3091d2"), "German Shepherd", 37 },
                    { new Guid("ad6842f9-9935-4c6d-b177-f66d589260a0"), "English Pointer", 28 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "AnimalId",
                keyValue: new Guid("60dcdf09-7955-4954-bbc5-d2ce66b625c2"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "AnimalId",
                keyValue: new Guid("753f500f-1970-4d75-b29e-ac83f148c55b"));

            migrationBuilder.DeleteData(
                table: "Birds",
                keyColumn: "AnimalId",
                keyValue: new Guid("e7bdcf6f-7481-4112-9266-84eb1242f45d"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "AnimalId",
                keyValue: new Guid("056bae45-79b7-4c2f-9e6b-26d3f543565b"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "AnimalId",
                keyValue: new Guid("132379ea-8748-4273-a6aa-b1002dbd80ca"));

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "AnimalId",
                keyValue: new Guid("490da8d5-3730-4906-8166-706bcd1a49f9"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "AnimalId",
                keyValue: new Guid("032f97dc-f536-4bf5-99f6-3160f4f3a4d9"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "AnimalId",
                keyValue: new Guid("7197e6de-c10f-46c2-a7b6-ed7c6d3091d2"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "AnimalId",
                keyValue: new Guid("ad6842f9-9935-4c6d-b177-f66d589260a0"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: new Guid("032f97dc-f536-4bf5-99f6-3160f4f3a4d9"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: new Guid("056bae45-79b7-4c2f-9e6b-26d3f543565b"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: new Guid("132379ea-8748-4273-a6aa-b1002dbd80ca"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: new Guid("490da8d5-3730-4906-8166-706bcd1a49f9"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: new Guid("60dcdf09-7955-4954-bbc5-d2ce66b625c2"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: new Guid("7197e6de-c10f-46c2-a7b6-ed7c6d3091d2"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: new Guid("753f500f-1970-4d75-b29e-ac83f148c55b"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: new Guid("ad6842f9-9935-4c6d-b177-f66d589260a0"));

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "AnimalId",
                keyValue: new Guid("e7bdcf6f-7481-4112-9266-84eb1242f45d"));

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "AnimalId", "AnimalType", "Name" },
                values: new object[,]
                {
                    { new Guid("10c9e943-49e7-44cb-bd06-c809185438dd"), "", "Ara" },
                    { new Guid("2d4e07c0-4277-4779-bee7-8ac4a6fa331e"), "", "Sova" },
                    { new Guid("5a0eaeb0-7dd3-4100-aa79-f0add7c49d67"), "", "Kity" },
                    { new Guid("5e2efcf6-072b-4838-914c-a4c39cf10ded"), "", "Max" },
                    { new Guid("93a5f790-f162-4e19-9fd8-8018e1cbc259"), "", "Astor" },
                    { new Guid("968dea87-60e2-4093-a191-d77e6a41e033"), "", "Micko" },
                    { new Guid("c4feb719-e1a4-47c5-a278-c2e94fcc54be"), "", "Vrana" },
                    { new Guid("d54d24c3-975a-413e-b2b5-55e57cc0a878"), "", "Ari" },
                    { new Guid("f9d68585-a161-4087-8373-fe70a7b59eb0"), "", "Azrael" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("047425eb-15a5-4310-9d25-e281ab036868"),
                column: "Password",
                value: "$2a$11$3zu0cm.HElaHpTsdEOrP.Ob3Ev9ggpkMfY6OFdpnTZy/F.sYXWNTa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("047425eb-15a5-4310-9d25-e281ab036869"),
                column: "Password",
                value: "$2a$11$qWEsMalco3HiM.tEQst5We3mGrReV/7V0S/0QAI0xjLjAkWfLF/su");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("08260479-52a0-4c0e-a588-274101a2c3be"),
                column: "Password",
                value: "$2a$11$WyqaeU.YeLlrYqo7sDlDIOty0sIzpkG3l.W1rxX..Ho9g882nR4RO");

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "AnimalId", "CanFly", "Color" },
                values: new object[,]
                {
                    { new Guid("10c9e943-49e7-44cb-bd06-c809185438dd"), false, "Red" },
                    { new Guid("2d4e07c0-4277-4779-bee7-8ac4a6fa331e"), true, "Grey" },
                    { new Guid("c4feb719-e1a4-47c5-a278-c2e94fcc54be"), true, "Black" }
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "AnimalId", "Breed", "LikesToPlay", "Weight" },
                values: new object[,]
                {
                    { new Guid("5a0eaeb0-7dd3-4100-aa79-f0add7c49d67"), "Persian Cat", true, 4 },
                    { new Guid("968dea87-60e2-4093-a191-d77e6a41e033"), "Domestic Cat", true, 6 },
                    { new Guid("f9d68585-a161-4087-8373-fe70a7b59eb0"), "Siamese Cat", false, 6 }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "AnimalId", "Breed", "Weight" },
                values: new object[,]
                {
                    { new Guid("5e2efcf6-072b-4838-914c-a4c39cf10ded"), "German Shepherd", 37 },
                    { new Guid("93a5f790-f162-4e19-9fd8-8018e1cbc259"), "English Pointer", 28 },
                    { new Guid("d54d24c3-975a-413e-b2b5-55e57cc0a878"), "English Pointer", 31 }
                });
        }
    }
}
