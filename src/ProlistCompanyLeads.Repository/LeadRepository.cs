namespace ProlistCompany.Leads.Repository;

public class LeadRepository(string connectionString) : ILeadRepository
{
    private readonly ContextRepository _context = new();

    public async ValueTask CommitAsync(CancellationToken ct) =>
        await _context.SaveChangesAsync(ct);

    public async ValueTask<Lead?> ObterLeadAsync(Guid id, CancellationToken ct) =>
        await _context
                .Leads
                .FirstOrDefaultAsync(x => x.Id == id, ct);

    public async ValueTask<List<Lead>> ObterLeadsPorStatusAsync(Status status, CancellationToken ct) =>
        await _context
                .Leads
                .Where(x => x.Status == status)
                .ToListAsync(ct);

    public async ValueTask<List<Lead>> ObterTodosLeadsAsync(CancellationToken ct) =>
        await _context
                .Leads
                .AsNoTracking()
                .ToListAsync(ct);
}
