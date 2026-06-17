using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAspNetProject.Migrations
{
    /// <inheritdoc />
    public partial class TeacherBecameNullableForSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_student_klasses_klass_entity_id",
                table: "student");

            migrationBuilder.DropIndex(
                name: "ix_student_klass_entity_id",
                table: "student");

            migrationBuilder.DropColumn(
                name: "klass_entity_id",
                table: "student");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "klass_entity_id",
                table: "student",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_student_klass_entity_id",
                table: "student",
                column: "klass_entity_id");

            migrationBuilder.AddForeignKey(
                name: "fk_student_klasses_klass_entity_id",
                table: "student",
                column: "klass_entity_id",
                principalTable: "klass",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
