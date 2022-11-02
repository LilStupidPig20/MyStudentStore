using MediatR;

namespace RTF.CQS.Abstractions;

public class Command : IRequest<bool>, ICommand
{
}