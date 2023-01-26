using MediatR;

namespace RTF.CQS.Abstractions;

public abstract class RequestHandler<TRequest, TResult> : IRequestHandler<TRequest, TResult>
    where TRequest : IRequest<TResult>
{
    async Task<TResult> IRequestHandler<TRequest, TResult>.Handle(TRequest request, CancellationToken cancellationToken)
    {
        return await CoreHandle(request, cancellationToken);
    }

    protected abstract Task<TResult> CoreHandle(TRequest request, CancellationToken cancellationToken);
}