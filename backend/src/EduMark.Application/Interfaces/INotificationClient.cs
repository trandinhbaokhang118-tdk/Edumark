using EduMark.Application.Contracts;
namespace EduMark.Application.Interfaces;
/// <summary>Port for notifying another bounded context after a successful enrollment.</summary>
public interface INotificationClient { Task NotifyEnrollmentAsync(EnrollmentNotification notification, CancellationToken cancellationToken); }
