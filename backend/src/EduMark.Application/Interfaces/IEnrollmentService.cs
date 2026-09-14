using EduMark.Application.Contracts;
namespace EduMark.Application.Interfaces;
public interface IEnrollmentService { Task<EnrollmentResponse?> EnrollAsync(Guid courseId, CreateEnrollmentRequest request, CancellationToken cancellationToken); Task<IReadOnlyList<EnrollmentResponse>> GetByCourseAsync(Guid courseId, CancellationToken cancellationToken); }
