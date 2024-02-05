namespace ProlistCompany.Leads.AppServices.Leads.ObterPorStatus;

public class ObterLeadPorStatusHandler(ILeadService leadService) : IRequestHandler<ObterLeadPorStatusRequestDto, ObterLeadPorStatusResponseDto>
{
    private readonly ILeadService _leadService = leadService;

    public async Task<ObterLeadPorStatusResponseDto> Handle(ObterLeadPorStatusRequestDto request, CancellationToken ct)
    {
        var leadsDto = new List<ObterLeadPorStatusDto>();
        var leads = await _leadService.ObterLeadsPorStatusAsync(request.Status, ct);

        foreach (var lead in leads)
        {
            leadsDto.Add(new(
                lead.Categoria,
                lead.DataDeInclusao,
                lead.Descricao,
                lead.Email,
                lead.Id,
                lead.Identificador,
                lead.Nome,
                lead.Preco,
                lead.Sobrenome,
                lead.Suburbio,
                lead.Telefone
                ));
        }

        return await Task.FromResult(new ObterLeadPorStatusResponseDto(leadsDto));
    }
}
