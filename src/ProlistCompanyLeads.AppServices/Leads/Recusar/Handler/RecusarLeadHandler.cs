namespace ProlistCompany.Leads.AppServices.Leads.Recusar;

public class RecusarLeadHandler(ILeadService leadService) : IRequestHandler<RecusarLeadRequestDto, RecusarLeadResponseDto>
{
    private readonly ILeadService _leadService = leadService;

    public async Task<RecusarLeadResponseDto> Handle(RecusarLeadRequestDto request, CancellationToken ct)
    {
        var lead = await _leadService.AlterarStatusDoLeadAsync(request.Id, Status.Recusado, ct);

        return await Task.FromResult(new RecusarLeadResponseDto(new(
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
                        )));
    }
}
