namespace ProlistCompany.Leads.AppServices.Leads.Aceitar;

public record struct AceitarLeadRequestDto(Guid Id) : IRequest<AceitarLeadResponseDto>;