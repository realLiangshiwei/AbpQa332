using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace qa.Migrations
{
    public partial class added_qatenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QaTenant",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    AbpTenantId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QaTenant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QaTenant_AbpTenants_AbpTenantId",
                        column: x => x.AbpTenantId,
                        principalTable: "AbpTenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QaTenant_AbpTenantId",
                table: "QaTenant",
                column: "AbpTenantId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QaTenant");
        }
    }
}
