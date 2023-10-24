using CQRSMediatRExampel.Models;
using MediatR;

namespace CQRSMediatRExampel.Notification
{
    public record ProductAddedNotification(Product Product) : INotification;
}
