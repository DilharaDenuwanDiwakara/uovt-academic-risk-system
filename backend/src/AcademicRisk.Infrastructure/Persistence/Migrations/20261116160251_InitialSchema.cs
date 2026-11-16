using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademicRisk.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "academic_programmes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_programmes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "modules",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_modules", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "curricula",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    academic_programme_id = table.Column<Guid>(type: "uuid", nullable: false),
                    version = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_curricula", x => x.id);
                    table.ForeignKey(
                        name: "fk_curricula_academic_programmes_academic_programme_id",
                        column: x => x.academic_programme_id,
                        principalTable: "academic_programmes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "academic_batches",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    curriculum_id = table.Column<Guid>(type: "uuid", nullable: false),
                    batch_code = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    intake_year = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_batches", x => x.id);
                    table.ForeignKey(
                        name: "fk_academic_batches_curricula_curriculum_id",
                        column: x => x.curriculum_id,
                        principalTable: "curricula",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "curriculum_modules",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    curriculum_id = table.Column<Guid>(type: "uuid", nullable: false),
                    module_id = table.Column<Guid>(type: "uuid", nullable: false),
                    semester_number = table.Column<int>(type: "integer", nullable: false),
                    credits = table.Column<int>(type: "integer", nullable: false),
                    module_type = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    gpa_classification = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_curriculum_modules", x => x.id);
                    table.CheckConstraint("CK_CurriculumModules_Credits", "\"credits\" > 0");
                    table.CheckConstraint("CK_CurriculumModules_SemesterNumber", "\"semester_number\" BETWEEN 1 AND 6");
                    table.ForeignKey(
                        name: "fk_curriculum_modules_curricula_curriculum_id",
                        column: x => x.curriculum_id,
                        principalTable: "curricula",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_curriculum_modules_modules_module_id",
                        column: x => x.module_id,
                        principalTable: "modules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "grade_definitions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    curriculum_id = table.Column<Guid>(type: "uuid", nullable: false),
                    grade_code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    grade_point = table.Column<decimal>(type: "numeric(4,2)", precision: 4, scale: 2, nullable: true),
                    minimum_mark = table.Column<int>(type: "integer", nullable: true),
                    maximum_mark = table.Column<int>(type: "integer", nullable: true),
                    earns_credits = table.Column<bool>(type: "boolean", nullable: true),
                    description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_grade_definitions", x => x.id);
                    table.ForeignKey(
                        name: "fk_grade_definitions_curricula_curriculum_id",
                        column: x => x.curriculum_id,
                        principalTable: "curricula",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "academic_periods",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    academic_batch_id = table.Column<Guid>(type: "uuid", nullable: false),
                    semester_number = table.Column<int>(type: "integer", nullable: false),
                    label = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    start_date = table.Column<DateOnly>(type: "date", nullable: true),
                    end_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_periods", x => x.id);
                    table.CheckConstraint("CK_AcademicPeriods_SemesterNumber", "\"semester_number\" BETWEEN 1 AND 6");
                    table.ForeignKey(
                        name: "fk_academic_periods_academic_batches_academic_batch_id",
                        column: x => x.academic_batch_id,
                        principalTable: "academic_batches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    student_key = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    academic_batch_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_students", x => x.id);
                    table.ForeignKey(
                        name: "fk_students_academic_batches_academic_batch_id",
                        column: x => x.academic_batch_id,
                        principalTable: "academic_batches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "student_module_enrollments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    student_id = table.Column<Guid>(type: "uuid", nullable: false),
                    curriculum_module_id = table.Column<Guid>(type: "uuid", nullable: false),
                    academic_period_id = table.Column<Guid>(type: "uuid", nullable: false),
                    registered_on = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_student_module_enrollments", x => x.id);
                    table.ForeignKey(
                        name: "fk_student_module_enrollments_academic_periods_academic_period",
                        column: x => x.academic_period_id,
                        principalTable: "academic_periods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_module_enrollments_curriculum_modules_curriculum_mo",
                        column: x => x.curriculum_module_id,
                        principalTable: "curriculum_modules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_module_enrollments_students_student_id",
                        column: x => x.student_id,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "student_module_results",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    student_module_enrollment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    examination_period_id = table.Column<Guid>(type: "uuid", nullable: false),
                    attempt_number = table.Column<int>(type: "integer", nullable: false),
                    grade_code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    has_academic_concession = table.Column<bool>(type: "boolean", nullable: false),
                    published_on = table.Column<DateOnly>(type: "date", nullable: true),
                    notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_student_module_results", x => x.id);
                    table.CheckConstraint("CK_StudentModuleResults_AttemptNumber", "\"attempt_number\" >= 1");
                    table.ForeignKey(
                        name: "fk_student_module_results_academic_periods_examination_period_",
                        column: x => x.examination_period_id,
                        principalTable: "academic_periods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_module_results_student_module_enrollments_student_m",
                        column: x => x.student_module_enrollment_id,
                        principalTable: "student_module_enrollments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_academic_batches_curriculum_id_intake_year_batch_code",
                table: "academic_batches",
                columns: new[] { "curriculum_id", "intake_year", "batch_code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_academic_periods_academic_batch_id_semester_number",
                table: "academic_periods",
                columns: new[] { "academic_batch_id", "semester_number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_academic_programmes_code",
                table: "academic_programmes",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_curricula_academic_programme_id_version",
                table: "curricula",
                columns: new[] { "academic_programme_id", "version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_curriculum_modules_curriculum_id_module_id",
                table: "curriculum_modules",
                columns: new[] { "curriculum_id", "module_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_curriculum_modules_module_id",
                table: "curriculum_modules",
                column: "module_id");

            migrationBuilder.CreateIndex(
                name: "ix_grade_definitions_curriculum_id_grade_code",
                table: "grade_definitions",
                columns: new[] { "curriculum_id", "grade_code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_modules_code",
                table: "modules",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_student_module_enrollments_academic_period_id",
                table: "student_module_enrollments",
                column: "academic_period_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_module_enrollments_curriculum_module_id",
                table: "student_module_enrollments",
                column: "curriculum_module_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_module_enrollments_student_id_curriculum_module_id_",
                table: "student_module_enrollments",
                columns: new[] { "student_id", "curriculum_module_id", "academic_period_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_student_module_results_examination_period_id",
                table: "student_module_results",
                column: "examination_period_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_module_results_student_module_enrollment_id_attempt",
                table: "student_module_results",
                columns: new[] { "student_module_enrollment_id", "attempt_number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_students_academic_batch_id",
                table: "students",
                column: "academic_batch_id");

            migrationBuilder.CreateIndex(
                name: "ix_students_student_key",
                table: "students",
                column: "student_key",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "grade_definitions");

            migrationBuilder.DropTable(
                name: "student_module_results");

            migrationBuilder.DropTable(
                name: "student_module_enrollments");

            migrationBuilder.DropTable(
                name: "academic_periods");

            migrationBuilder.DropTable(
                name: "curriculum_modules");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "modules");

            migrationBuilder.DropTable(
                name: "academic_batches");

            migrationBuilder.DropTable(
                name: "curricula");

            migrationBuilder.DropTable(
                name: "academic_programmes");
        }
    }
}
