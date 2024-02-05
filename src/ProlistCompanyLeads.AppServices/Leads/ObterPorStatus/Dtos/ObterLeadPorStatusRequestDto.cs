namespace ProlistCompany.Leads.AppServices.Leads.ObterPorStatus;

public record struct ObterLeadPorStatusRequestDto(Status Status) : IRequest<ObterLeadPorStatusResponseDto>;
