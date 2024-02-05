namespace ProlistCompany.Leads.Services;

public class LeadService(ILeadRepository leadRepository, IEmailService emailService) : ILeadService
{
    private readonly ILeadRepository _leadRepository = leadRepository;
    private readonly IEmailService _emailService = emailService;

    public async ValueTask<Lead> AlterarStatusDoLeadAsync(Guid id, Status status, CancellationToken ct)
    {
        if (await _leadRepository.ObterLeadAsync(id, ct) is var lead && lead == null)
            throw new ArgumentNullException(nameof(id), "Lead não encontrado.");

        lead.AtualizarStatus(status);

        if (status == Status.Aceito && lead.Preco > 500)
        {
            lead.AplicarDesconto();
            await _emailService.EnviarEmail("sistema@prolistcompany.com.br", "vendas@test.com", $"Cliente aceito.", $"O cliente {lead.Nome} foi aceito.");
        }

        await _leadRepository.CommitAsync(ct);

        return lead;
    }

    public async ValueTask<List<Lead>> ObterLeadsPorStatusAsync(Status status, CancellationToken ct)
    {
        var leads = await _leadRepository.ObterLeadsPorStatusAsync(status, ct);

        return leads;
    }

    public async ValueTask<List<Lead>> ObterTodosLeadsAsync(CancellationToken ct)
    {
        var leads = await _leadRepository.ObterTodosLeadsAsync(ct);

        return leads;
    }
}
