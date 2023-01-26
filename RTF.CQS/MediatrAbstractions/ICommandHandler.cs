namespace RTF.CQS.Abstractions;

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task Handle(TCommand request, CancellationToken ct);
}

public interface ICommandHandler<in TCommand, TResult> where TCommand : ICommand<TResult>
{
    Task<TResult> HandleWithResult(TCommand request, CancellationToken ct);
}