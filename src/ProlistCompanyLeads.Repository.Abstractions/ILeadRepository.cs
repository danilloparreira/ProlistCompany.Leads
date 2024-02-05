namespace ProlistCompany.Leads.Repository.Abstractions;

public interface ILeadRepository
{
    ValueTask CommitAsync(CancellationToken ct);
    ValueTask<Lead?> ObterLeadAsync(Guid id, CancellationToken ct);
    ValueTask<List<Lead>> ObterLeadsPorStatusAsync(Status status, CancellationToken ct);
    ValueTask<List<Lead>> ObterTodosLeadsAsync(CancellationToken ct);
}