using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAspNetProject.Migrations
{
    /// <inheritdoc />
    public partial class FieldKlassEntityIdRemovedFromStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "klass",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    year = table.Column<int>(type: "integer", maxLength: 2, nullable: false),
                    group = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_klass", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subject",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subject", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_entity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    last_name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    surname = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    role = table.Column<int>(type: "integer", nullable: false),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    image_url = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    phone_number = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    password = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_entity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    klass_id = table.Column<Guid>(type: "uuid", nullable: false),
                    performance = table.Column<int>(type: "integer", nullable: true),
                    klass_entity_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.id);
                    table.ForeignKey(
                        name: "fk_student_klasses_klass_entity_id",
                        column: x => x.klass_entity_id,
                        principalTable: "klass",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_student_klasses_klass_id",
                        column: x => x.klass_id,
                        principalTable: "klass",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_student_user_entity_id",
                        column: x => x.id,
                        principalTable: "user_entity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teacher",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    head_class_id = table.Column<Guid>(type: "uuid", nullable: true),
                    experience = table.Column<int>(type: "integer", nullable: false),
                    salary = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher", x => x.id);
                    table.ForeignKey(
                        name: "fk_teacher_user_entity_id",
                        column: x => x.id,
                        principalTable: "user_entity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subject_teacher",
                columns: table => new
                {
                    subject_entities_id = table.Column<Guid>(type: "uuid", nullable: false),
                    teachers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subject_teacher", x => new { x.subject_entities_id, x.teachers_id });
                    table.ForeignKey(
                        name: "fk_subject_teacher_subject_subject_entities_id",
                        column: x => x.subject_entities_id,
                        principalTable: "subject",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_subject_teacher_teacher_teachers_id",
                        column: x => x.teachers_id,
                        principalTable: "teacher",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_klass_year",
                table: "klass",
                column: "year");

            migrationBuilder.CreateIndex(
                name: "ix_student_klass_entity_id",
                table: "student",
                column: "klass_entity_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_klass_id",
                table: "student",
                column: "klass_id");

            migrationBuilder.CreateIndex(
                name: "ix_subject_name",
                table: "subject",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_subject_teacher_teachers_id",
                table: "subject_teacher",
                column: "teachers_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_entity_email",
                table: "user_entity",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_entity_phone_number",
                table: "user_entity",
                column: "phone_number",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "subject_teacher");

            migrationBuilder.DropTable(
                name: "klass");

            migrationBuilder.DropTable(
                name: "subject");

            migrationBuilder.DropTable(
                name: "teacher");

            migrationBuilder.DropTable(
                name: "user_entity");
        }
    }
}
