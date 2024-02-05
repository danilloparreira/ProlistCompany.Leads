namespace ProlistCompany.Leads.AppServices.Leads.Obter;

public class ObterLeadsHandler(ILeadService leadService) : IRequestHandler<ObterLeadRequestDto, ObterLeadResponseDto>
{
    private readonly ILeadService _leadService = leadService;

    public async Task<ObterLeadResponseDto> Handle(ObterLeadRequestDto request, CancellationToken ct)
    {
        var leadsDto = new List<ObterLeadDto>();
        var leads = await _leadService.ObterTodosLeadsAsync(ct);

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

        return await Task.FromResult(new ObterLeadResponseDto(leadsDto));
    }
}
