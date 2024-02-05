namespace ProlistCompany.Leads.Services.Abstractions;

public interface ILeadService
{
    ValueTask<Lead> AlterarStatusDoLeadAsync(Guid id, Status status, CancellationToken ct);
    ValueTask<List<Lead>> ObterLeadsPorStatusAsync(Status status, CancellationToken ct);
    ValueTask<List<Lead>> ObterTodosLeadsAsync(CancellationToken ct);
}