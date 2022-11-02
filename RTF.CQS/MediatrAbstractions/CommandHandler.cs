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