using MediatR;

namespace BookManagement.Application.Notifications.ReturnedBook;

public class ReturnedBookNotificationHandler : INotificationHandler<ReturnedBookNotification> {
    public Task Handle(ReturnedBookNotification notification, CancellationToken cancellationToken) {
        if (notification.ReturnedAt is not null) {
            Console.WriteLine("Livro já devolvido!");
            return Task.CompletedTask;
        }

        if (notification.ToReturn >= notification.ReturnedAt) {
            Console.WriteLine("Devolução em dia!");
        } else {
            Console.WriteLine($"Devolução com atraso de {notification.ReturnedAt!.Value.Subtract(notification.ToReturn).TotalDays} dias");
        }

        return Task.CompletedTask;
    }
}

public class ReturnedBookNotification(DateTime toReturn, DateTime? returnedAt) : INotification {
    public DateTime ToReturn { get; private set; } = toReturn;
    public DateTime? ReturnedAt { get; private set; } = returnedAt;
}