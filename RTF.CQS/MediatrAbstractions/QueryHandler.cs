namespace RTF.CQS.Abstractions;

public abstract class QueryHandler<TQuery, TResult> : RequestHandler<TQuery, TResult>, IQueryHandler<TQuery, TResult>
    where TQuery : Query<TResult>
{
    protected override Task<TResult> CoreHandle(TQuery request, CancellationToken ct)
    {
        return Handle(request, ct);
    }

    public abstract Task<TResult> Handle(TQuery request, CancellationToken ct);
}