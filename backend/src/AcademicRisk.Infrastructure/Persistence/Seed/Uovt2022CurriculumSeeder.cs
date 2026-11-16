using AcademicRisk.Domain.Entities;
using AcademicRisk.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace AcademicRisk.Infrastructure.Persistence.Seed;

/// <summary>
/// Reference-data seeder based on UoVT's 2022 Software Technology course structure
/// (course tables on PDF pages 3-4, grade codes on page 9).
/// Seed only after EF migrations have been applied. This does not seed students,
/// actual batch calendars, approved GPA points, or official prerequisites.
/// </summary>
public static class Uovt2022CurriculumSeeder
{
    // Internal application code, NOT an official UoVT programme code.
    private const string ProgrammeCode = "BTECH-ST";
    private const string CurriculumVersion = "2022";

    private sealed record ModuleSeed(int Semester, string Code, string Title, int Credits,
        ModuleType Type, GpaClassification Gpa);

    private static readonly ModuleSeed[] ModuleData =
    [
        new(1, "IT103011", "Mathematics for ICT I", 3, ModuleType.Compulsory, GpaClassification.Gpa),
        new(1, "IT104021", "Computer Programming", 4, ModuleType.Compulsory, GpaClassification.Gpa),
        new(1, "IT104031", "Software Development Practices", 4, ModuleType.Compulsory, GpaClassification.Gpa),
        new(1, "IT103041", "Digital Electronics", 3, ModuleType.Compulsory, GpaClassification.Gpa),
        new(1, "IT103051", "Data Communication and Networks", 3, ModuleType.Compulsory, GpaClassification.Gpa),
        new(1, "IT103061", "Database Design", 3, ModuleType.Compulsory, GpaClassification.Gpa),
        new(1, "IT104071", "Internet Technologies", 4, ModuleType.Compulsory, GpaClassification.Gpa),
        new(1, "LS103101", "Communication Skills in English I", 3, ModuleType.Compulsory, GpaClassification.NonGpa),
        new(2, "IT202011", "Operating Systems", 2, ModuleType.Compulsory, GpaClassification.Gpa),
        new(2, "IT203021", "Mathematics for ICT II", 3, ModuleType.Compulsory, GpaClassification.Gpa),
        new(2, "IT203031", "Computer Architecture", 3, ModuleType.Compulsory, GpaClassification.Gpa),
        new(2, "IT204041", "Data Structures and Algorithms", 4, ModuleType.Compulsory, GpaClassification.Gpa),
        new(2, "IT206051", "Database Systems and Programming", 6, ModuleType.Compulsory, GpaClassification.Gpa),
        new(2, "IT204061", "Visual Programming I", 4, ModuleType.Compulsory, GpaClassification.Gpa),
        new(2, "IT206071", "Web Programming", 6, ModuleType.Compulsory, GpaClassification.Gpa),
        new(2, "IT203081", "Computer Networks", 3, ModuleType.Compulsory, GpaClassification.Gpa),
        new(2, "LS203111", "Communication Skills in English II", 3, ModuleType.Compulsory, GpaClassification.NonGpa),
        new(3, "IT304011", "Web Technology and Applications", 4, ModuleType.Compulsory, GpaClassification.Gpa),
        new(3, "IT304021", "Platform Independent Programming", 4, ModuleType.Compulsory, GpaClassification.Gpa),
        new(3, "IT306031", "Visual Programming II", 6, ModuleType.Compulsory, GpaClassification.Gpa),
        new(3, "IT306041", "Software Architectures and Design", 6, ModuleType.Compulsory, GpaClassification.Gpa),
        new(3, "IT304051", "Software Deployment and Evolution", 4, ModuleType.Compulsory, GpaClassification.Gpa),
        new(3, "IT304061", "Database Implementation", 4, ModuleType.Compulsory, GpaClassification.Gpa),
        new(3, "MS304121", "Entrepreneurship Development and Management", 4, ModuleType.Compulsory, GpaClassification.Gpa),
        new(3, "IT302160", "Psychology", 2, ModuleType.Elective, GpaClassification.NonGpa),
        new(3, "IT302170", "Soft Skills and Personal development", 2, ModuleType.Elective, GpaClassification.NonGpa),
        new(4, "IT404010", "Mobile Application Development", 4, ModuleType.Compulsory, GpaClassification.Gpa),
        new(4, "IT404020", "Cloud Based Application Development", 4, ModuleType.Compulsory, GpaClassification.Gpa),
        new(4, "IT402030", "Human Computer Interaction", 2, ModuleType.Compulsory, GpaClassification.Gpa),
        new(4, "IT404041", "Real-Time Programming", 4, ModuleType.Compulsory, GpaClassification.Gpa),
        new(4, "IT406051", "Software Testing and Reliability", 6, ModuleType.Compulsory, GpaClassification.Gpa),
        new(4, "IT403061", "Enterprise System Technologies and Architectures", 3, ModuleType.Compulsory, GpaClassification.Gpa),
        new(4, "IT402070", "UX Engineering", 2, ModuleType.Elective, GpaClassification.Gpa),
        new(4, "MS403130", "Research Methodology", 3, ModuleType.Compulsory, GpaClassification.Gpa),
        new(4, "IT402170", "Meditation & Stress Management", 2, ModuleType.Elective, GpaClassification.NonGpa),
        new(4, "EE402911", "Energy Management in IT Environment", 2, ModuleType.Elective, GpaClassification.NonGpa),
        new(5, "IT514011", "Work Based / Industrial Training", 14, ModuleType.Compulsory, GpaClassification.Gpa),
        new(6, "IT604011", "Professional Issues in Information Technology", 4, ModuleType.Compulsory, GpaClassification.Gpa),
        new(6, "IT604021", "Enterprise System Design", 4, ModuleType.Compulsory, GpaClassification.Gpa),
        new(6, "IT604030", "Enterprise Resource Planning Systems", 4, ModuleType.Compulsory, GpaClassification.Gpa),
        new(6, "IT604040", "Intelligent Systems", 4, ModuleType.Compulsory, GpaClassification.Gpa),
        new(6, "IT604051", "Information Systems Security and Practices", 4, ModuleType.Compulsory, GpaClassification.Gpa),
        new(6, "IT604061", "Software Project Management", 4, ModuleType.Compulsory, GpaClassification.Gpa),
        new(6, "IT604071", "Enterprise Application Development", 4, ModuleType.Compulsory, GpaClassification.Gpa),
        new(6, "IT602080", "Photography", 2, ModuleType.Elective, GpaClassification.NonGpa),
        new(6, "MS602910", "Occupational Health and Safety", 2, ModuleType.Elective, GpaClassification.NonGpa),
        new(6, "IT604090", "Game Development and Programming", 4, ModuleType.Elective, GpaClassification.Gpa),
        new(6, "IT603100", "Digital Marketing", 3, ModuleType.Elective, GpaClassification.Gpa),
        new(6, "IT612111", "Final Year Project (Software Development Project)", 12, ModuleType.Compulsory, GpaClassification.Gpa),
    ];

    // Normal mark bands refer to final *module* grades. Special codes are
    // component-specific or administrative; do not assign overall marks.
    private sealed record GradeSeed(string Code, int? Minimum, int? Maximum,
        bool? EarnsCredits, string? Description = null);

    private static readonly GradeSeed[] GradeData =
    [
        new("A+", 85, null, true), new("A", 75, 84, true),
        new("A-", 70, 74, true), new("B+", 65, 69, true),
        new("B", 60, 64, true), new("B-", 55, 59, true),
        new("C+", 50, 54, true), new("C", 45, 49, true),
        new("C-", 40, 44, true), new("D+", 35, 39, true),
        new("D", 30, 34, true),
        new("F(ET)", null, null, false, "End-semester examination failure; see university regulations"),
        new("F(CA)", null, null, false, "Continuous-assessment failure; see university regulations"),
        new("I(ET)", null, null, null, "Incomplete end-semester examination"),
        new("I", null, null, null, "Module incomplete"),
        new("Pass", null, null, true, "Repeat student obtained pass mark in end exam"),
        new("N/A", null, null, null, "Not applicable / exempted in category 1")
    ];

    public static async Task SeedAsync(AcademicRiskDbContext db, CancellationToken cancellationToken = default)
    {
        // Relies on existing unique indexes on programme code, module code,
        // curriculum (programme, version), curriculum module (curriculum,module),
        // grade definition (curriculum, grade code).
        await using var transaction = await db.Database.BeginTransactionAsync(cancellationToken);

        var programme = await db.AcademicProgrammes.SingleOrDefaultAsync(
            x => x.Code == ProgrammeCode, cancellationToken);
        if (programme is null)
        {
            programme = new AcademicProgramme
            {
                Code = ProgrammeCode,
                Name = "Bachelor of Technology in Software Technology"
            };
            db.AcademicProgrammes.Add(programme);
        }
        else if (programme.Name != "Bachelor of Technology in Software Technology")
        {
            throw new InvalidOperationException("Programme code exists with different name. Review reference data.");
        }

        // Save principal entities before FK-based lookups.
        await db.SaveChangesAsync(cancellationToken);

        var curriculum = await db.Curricula.SingleOrDefaultAsync(
            x => x.AcademicProgrammeId == programme.Id && x.Version == CurriculumVersion,
            cancellationToken);
        if (curriculum is null)
        {
            curriculum = new Curriculum
            {
                AcademicProgrammeId = programme.Id,
                Version = CurriculumVersion,
                Description = "UoVT Software Technology course structure (2022 document)"
            };
            db.Curricula.Add(curriculum);
            await db.SaveChangesAsync(cancellationToken);
        }

        var codes = ModuleData.Select(x => x.Code).ToArray();
        var modulesByCode = (await db.Modules.Where(x => codes.Contains(x.Code))
                .ToListAsync(cancellationToken))
            .ToDictionary(x => x.Code, StringComparer.Ordinal);
        foreach (var item in ModuleData)
        {
            if (modulesByCode.TryGetValue(item.Code, out var existing))
            {
                if (existing.Title != item.Title)
                    throw new InvalidOperationException($"Module {item.Code} has a different title. Review before reseeding.");
                continue;
            }
            var module = new Module { Code = item.Code, Title = item.Title };
            db.Modules.Add(module);
            modulesByCode.Add(module.Code, module);
        }
        await db.SaveChangesAsync(cancellationToken);

        var mapped = (await db.CurriculumModules.Where(x => x.CurriculumId == curriculum.Id)
                .ToListAsync(cancellationToken))
            .ToDictionary(x => x.ModuleId);
        foreach (var item in ModuleData)
        {
            var module = modulesByCode[item.Code];
            if (mapped.TryGetValue(module.Id, out var existing))
            {
                if (existing.SemesterNumber != item.Semester || existing.Credits != item.Credits ||
                    existing.ModuleType != item.Type || existing.GpaClassification != item.Gpa)
                    throw new InvalidOperationException($"Curriculum mapping for {item.Code} differs. Review reference data.");
                continue;
            }
            db.CurriculumModules.Add(new CurriculumModule
            {
                CurriculumId = curriculum.Id,
                ModuleId = module.Id,
                SemesterNumber = item.Semester,
                Credits = item.Credits,
                ModuleType = item.Type,
                GpaClassification = item.Gpa
            });
        }

        var gradesByCode = (await db.GradeDefinitions.Where(x => x.CurriculumId == curriculum.Id)
                .ToListAsync(cancellationToken))
            .ToDictionary(x => x.GradeCode, StringComparer.Ordinal);
        foreach (var item in GradeData)
        {
            if (gradesByCode.TryGetValue(item.Code, out var existing))
            {
                // Do not overwrite approved GradePoint values populated later.
                if (existing.MinimumMark != item.Minimum || existing.MaximumMark != item.Maximum ||
                    existing.EarnsCredits != item.EarnsCredits)
                    throw new InvalidOperationException($"Grade definition {item.Code} differs. Review official rules.");
                continue;
            }
            db.GradeDefinitions.Add(new GradeDefinition
            {
                CurriculumId = curriculum.Id,
                GradeCode = item.Code,
                MinimumMark = item.Minimum,
                MaximumMark = item.Maximum,
                EarnsCredits = item.EarnsCredits,
                GradePoint = null,
                Description = item.Description
            });
        }
        await db.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
    }
}
