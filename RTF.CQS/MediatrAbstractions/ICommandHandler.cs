namespace RTF.CQS.Abstractions;

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task Handle(TCommand request, CancellationToken ct);
}