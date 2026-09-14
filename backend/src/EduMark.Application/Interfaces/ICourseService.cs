using EduMark.Application.Contracts;
namespace EduMark.Application.Interfaces;
public interface ICourseService { Task<IReadOnlyList<CourseResponse>> GetAllAsync(bool publishedOnly, CancellationToken cancellationToken); Task<CourseResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken); Task<CourseResponse> CreateAsync(CreateCourseRequest request, CancellationToken cancellationToken); Task<CourseResponse?> UpdateAsync(Guid id, UpdateCourseRequest request, CancellationToken cancellationToken); Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken); }
