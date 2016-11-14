namespace Wibci.LogicCommand
{
    public enum TaskResult
    {
        Success,
        Failed,
        AccessDenied,
        Canceled
    }

    public class TaskCommandResult : CommandResult
    {
        public TaskCommandResult()
        {
            TaskResult = TaskResult.Success;
        }

        public TaskResult TaskResult { get; set; }
    }
}