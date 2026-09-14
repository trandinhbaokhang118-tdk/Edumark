using EduMark.Application.Interfaces;
using EduMark.Infrastructure.Persistence;
using EduMark.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace EduMark.Infrastructure;
public static class DependencyInjection { public static IServiceCollection AddInfrastructure(this IServiceCollection s, IConfiguration c) { s.AddDbContext<EduMarkDbContext>(o => o.UseSqlite(c.GetConnectionString("EduMarkDb"))); s.AddScoped<ICourseService, CourseService>(); s.AddScoped<IEnrollmentService, EnrollmentService>(); return s; } }
