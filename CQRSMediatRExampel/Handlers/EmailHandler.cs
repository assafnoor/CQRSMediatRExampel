using CQRSMediatRExampel.Models;
using CQRSMediatRExampel.Notification;
using MediatR;

namespace CQRSMediatRExampel.Handlers
{
    public class EmailHandler : INotificationHandler<ProductAddedNotification>
    {
        private readonly FakeData _fakeData;

        public EmailHandler(FakeData fakeData)
        {
            _fakeData = fakeData;
        }

        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fakeData.EventOccured(notification.Product, "Email sent");
            await Task.CompletedTask;
        }
    }
}
