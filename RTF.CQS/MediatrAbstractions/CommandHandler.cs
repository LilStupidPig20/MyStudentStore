using MediatR;

namespace RTF.CQS.Abstractions;

public abstract class CommandHandler<TCommand> : RequestHandler<TCommand, bool>, ICommandHandler<TCommand>
    where TCommand : Command
{
    protected override async Task<bool> CoreHandle(TCommand request, CancellationToken cancellationToken)
    {
        await Handle(request, cancellationToken);
        return true;
    }

    public abstract Task Handle(TCommand request, CancellationToken ct);
}

public abstract class CommandHandler<TCommand, TResult> : RequestHandler<TCommand, TResult>, ICommandHandler<TCommand, TResult>
    where TCommand : Command<TResult>
{
    protected override async Task<TResult> CoreHandle(TCommand request, CancellationToken cancellationToken)
    {
        var result = await HandleWithResult(request, cancellationToken);
        return result;
    }
    
    public abstract Task<TResult> HandleWithResult(TCommand request, CancellationToken ct);
}