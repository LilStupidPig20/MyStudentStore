using MediatR;

namespace RTF.CQS.Abstractions;

public class Command : IRequest<bool>, ICommand
{
}

public class Command<TResult> : IRequest<TResult>, ICommand<TResult>
{
}