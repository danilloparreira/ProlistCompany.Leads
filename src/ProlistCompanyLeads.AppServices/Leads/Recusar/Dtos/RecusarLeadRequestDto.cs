namespace ProlistCompany.Leads.AppServices.Leads.Recusar;

public record struct RecusarLeadRequestDto(Guid Id) : IRequest<RecusarLeadResponseDto>;
