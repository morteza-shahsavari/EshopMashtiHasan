using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Security.Domain.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectAreas",
                columns: table => new
                {
                    ProjectAreaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersianTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAreas", x => x.ProjectAreaID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectControllers",
                columns: table => new
                {
                    ProjectControllerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectControllerName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PersianTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ProjectAreaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectControllers", x => x.ProjectControllerID);
                    table.ForeignKey(
                        name: "FK_ProjectControllers_ProjectAreas_ProjectAreaID",
                        column: x => x.ProjectAreaID,
                        principalTable: "ProjectAreas",
                        principalColumn: "ProjectAreaID");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsEmailActivated = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "ProjectActions",
                columns: table => new
                {
                    ProjectActionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectActionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersianTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ProjectControllerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectActions", x => x.ProjectActionID);
                    table.ForeignKey(
                        name: "FK_ProjectActions_ProjectControllers_ProjectControllerID",
                        column: x => x.ProjectControllerID,
                        principalTable: "ProjectControllers",
                        principalColumn: "ProjectControllerID");
                });

            migrationBuilder.CreateTable(
                name: "RoleActions",
                columns: table => new
                {
                    RoleActionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    ProjectActionID = table.Column<int>(type: "int", nullable: false),
                    HasPermission = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleActions", x => x.RoleActionID);
                    table.ForeignKey(
                        name: "FK_RoleActions_ProjectActions_ProjectActionID",
                        column: x => x.ProjectActionID,
                        principalTable: "ProjectActions",
                        principalColumn: "ProjectActionID");
                    table.ForeignKey(
                        name: "FK_RoleActions_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectActions_ProjectControllerID",
                table: "ProjectActions",
                column: "ProjectControllerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectControllers_ProjectAreaID",
                table: "ProjectControllers",
                column: "ProjectAreaID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleActions_ProjectActionID",
                table: "RoleActions",
                column: "ProjectActionID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleActions_RoleID",
                table: "RoleActions",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleActions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ProjectActions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ProjectControllers");

            migrationBuilder.DropTable(
                name: "ProjectAreas");
        }
    }
}
