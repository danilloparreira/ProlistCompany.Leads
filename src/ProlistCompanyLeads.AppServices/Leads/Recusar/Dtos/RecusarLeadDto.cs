namespace ProlistCompany.Leads.AppServices.Leads.Recusar;

public record struct RecusarLeadDto(string Categoria, DateTimeOffset DataDeInclusao, string? Descricao, string Email, Guid Id, int Identificador, string Nome, double Preco, string Sobrenome, string Suburbio, string Telefone);
