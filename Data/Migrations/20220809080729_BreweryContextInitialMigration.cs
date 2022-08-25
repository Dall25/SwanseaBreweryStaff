using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class BreweryContextInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserSection",
                columns: table => new
                {
                    UserSectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSection", x => x.UserSectionId);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    UserTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.UserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    UserSectionId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_UserSection_UserSectionId",
                        column: x => x.UserSectionId,
                        principalTable: "UserSection",
                        principalColumn: "UserSectionId");
                    table.ForeignKey(
                        name: "FK_User_UserType_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserType",
                        principalColumn: "UserTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserSection",
                columns: new[] { "UserSectionId", "Name" },
                values: new object[,]
                {
                    { 1, "Canning" },
                    { 2, "Brewing" },
                    { 3, "Labs" },
                    { 4, "HR" },
                    { 5, "Sales" }
                });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "UserTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Assistant" },
                    { 2, "Manager" },
                    { 3, "Engineer" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "UserSectionId", "UserTypeId" },
                values: new object[,]
                {
                    { new Guid("120d5ff6-1d0a-4915-88b3-450cdaf9fb6d"), "Ellie@SWBC.com", "Ellie", "Dallimore", 4, 1 },
                    { new Guid("39b79056-d79a-4672-a068-104cc3d77116"), "Jamie@SWBC.com", "Jamie", "Buckley", 5, 2 },
                    { new Guid("42481486-17f2-4cd3-bda2-04d3b46c8e0f"), "Maddie@SWBC.com", "Maddie", "Williams", 3, 1 },
                    { new Guid("630958ef-30c8-4c43-a822-f5b3b5192bd1"), "Luke@SWBC.com", "Luke", "Dallimore", 3, 2 },
                    { new Guid("6325b363-02c5-4d36-bb95-a232b226e95f"), "Alan@SWBC.com", "Alan", "Grant", 1, 2 },
                    { new Guid("822bfbc5-f936-4da2-93af-d0caf7efa97d"), "Ian@SWBC.com", "Ian", "Malcome", 2, 1 },
                    { new Guid("bf445a42-b936-44d4-90b4-00cc4a9189b7"), "Henry@SWBC.com", "Henry", "Dallimore", 1, 1 },
                    { new Guid("d818a056-1d33-4276-bc80-c8dcf128fe20"), "Ben@SWBC.com", "Ben", "Sztucki", 4, 2 },
                    { new Guid("ef258c81-b08e-4b73-9173-956db34a6e7b"), "Sarah@SWBC.com", "Sarah", "Williams", 4, 2 },
                    { new Guid("ff96657b-00c1-4c68-a6d6-4bd213777f53"), "Mike@SWBC.com", "Mike", "Prosser", 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_UserSectionId",
                table: "User",
                column: "UserSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeId",
                table: "User",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserSection");

            migrationBuilder.DropTable(
                name: "UserType");
        }
    }
}
