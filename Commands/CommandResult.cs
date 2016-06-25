namespace Wibci.LogicCommand
{
    public class CommandResult
    {
        public CommandResult()
        {
            Notification = Notification.Success();
        }

        public Notification Notification { get; set; }

        public virtual bool IsValid(NotificationSeverity severity = NotificationSeverity.Error)
        {
            return Notification.IsValid(severity);
        }
    }
}