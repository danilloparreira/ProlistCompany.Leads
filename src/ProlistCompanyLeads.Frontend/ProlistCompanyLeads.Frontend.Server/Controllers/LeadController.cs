namespace ProlistCompanyLeads.Frontend.Server.Controllers;

[ApiController]
[Route("leads")]
public class LeadController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet(Name = nameof(ObterLeadsAsync))]
    [ProducesResponseType(typeof(ObterLeadResponseDto), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> ObterLeadsAsync(CancellationToken ct)
    {
        var request = new ObterLeadRequestDto();
        var response = await _mediator.Send(request, ct);

        return new ObjectResult(response);
    }

    [HttpGet("status/{status}", Name = nameof(ObterLeadsPorStatusAsync))]
    [ProducesResponseType(typeof(ObterLeadResponseDto), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> ObterLeadsPorStatusAsync(Status status, CancellationToken ct)
    {
        var request = new ObterLeadPorStatusRequestDto(status);
        var response = await _mediator.Send(request, ct);

        return new ObjectResult(response);
    }

    [HttpPatch("aceitar/{id}", Name = nameof(AceitarLeadAsync))]
    public async ValueTask<IActionResult> AceitarLeadAsync([FromRoute] Guid id, CancellationToken ct)
    {
        var request = new AceitarLeadRequestDto(id);
        var response = await _mediator.Send(request, ct);

        return new ObjectResult(response);
    }

    [HttpPatch("recusar/{id}", Name = nameof(RecusarLeadAsync))]
    public async ValueTask<IActionResult> RecusarLeadAsync([FromRoute] Guid id, CancellationToken ct)
    {
        var request = new RecusarLeadRequestDto(id);
        var response = await _mediator.Send(request, ct);

        return new ObjectResult(response);
    }
}
