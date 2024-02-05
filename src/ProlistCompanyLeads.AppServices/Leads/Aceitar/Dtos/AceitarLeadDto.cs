namespace ProlistCompany.Leads.AppServices.Leads.Aceitar;

public record struct AceitarLeadDto(string Categoria, DateTimeOffset DataDeInclusao, string? Descricao, string Email, Guid Id, int Identificador, string Nome, double Preco, string Sobrenome, string Suburbio, string Telefone);
