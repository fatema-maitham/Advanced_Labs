namespace Lab3._1_DependencyInjection.Services
{
    public interface IOperationService
    {
        string CreatedAt { get; }
    }

    public interface ITransientOperation : IOperationService { }
    public interface IScopedOperation : IOperationService { }
    public interface ISingletonOperation : IOperationService { }
}
