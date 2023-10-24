using CQRSMediatRExampel.Models;
using CQRSMediatRExampel.Notification;
using MediatR;

namespace CQRSMediatRExampel.Handlers
{
    public class CacheInvalidationHandler : INotificationHandler<ProductAddedNotification>
    {
        private readonly FakeData _fakeData;

        public CacheInvalidationHandler(FakeData fakeData)
        {
            _fakeData = fakeData;
        }

        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fakeData.EventOccured(notification.Product, "Cache Invalidated");
            await Task.CompletedTask;
        }
    }
}
