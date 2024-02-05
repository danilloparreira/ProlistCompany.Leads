namespace ProlistCompany.Leads.AppServices.Leads.Aceitar;

public class AceitarLeadHandler(ILeadService leadService) : IRequestHandler<AceitarLeadRequestDto, AceitarLeadResponseDto>
{
    private readonly ILeadService _leadService = leadService;

    public async Task<AceitarLeadResponseDto> Handle(AceitarLeadRequestDto request, CancellationToken ct)
    {
        var lead = await _leadService.AlterarStatusDoLeadAsync(request.Id, Status.Aceito, ct);

        return await Task.FromResult(new AceitarLeadResponseDto(new(
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
