using MediatR;

namespace RTF.CQS.Abstractions;

public class Query<TResult> : IQuery<TResult>, IRequest<TResult>
{
    
}