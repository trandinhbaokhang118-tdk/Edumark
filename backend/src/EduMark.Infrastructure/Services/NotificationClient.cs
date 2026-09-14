using System.Net.Http.Json;
using EduMark.Application.Contracts;
using EduMark.Application.Interfaces;
using Microsoft.Extensions.Logging;
namespace EduMark.Infrastructure.Services;
public sealed class NotificationClient(HttpClient client, ILogger<NotificationClient> logger) : INotificationClient { public async Task NotifyEnrollmentAsync(EnrollmentNotification notification, CancellationToken ct) { try { var response = await client.PostAsJsonAsync("api/v1/notifications/enrollment", notification, ct); if (!response.IsSuccessStatusCode) logger.LogWarning("Notification service rejected enrollment event with {StatusCode}", response.StatusCode); } catch (HttpRequestException ex) { logger.LogWarning(ex, "Notification service unavailable. Enrollment remains successful."); } } }
