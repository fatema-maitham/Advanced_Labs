namespace Lab3._1_DependencyInjection.Services
{
    public class OperationService : ITransientOperation,
                                   IScopedOperation,
                                   ISingletonOperation
    {
        public string CreatedAt { get; } = DateTime.Now.ToString("HH:mm:ss.fff");
    }
}
