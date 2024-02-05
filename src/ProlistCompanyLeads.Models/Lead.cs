namespace ProlistCompany.Leads.Models;

public class Lead : Entidade<Guid>
{
    [SetsRequiredMembers]
    public Lead() : base(Guid.NewGuid())
    {
        Nome = string.Empty;
        Identificador = int.MinValue;
        Preco = double.MinValue;
        Suburbio = string.Empty;
        Categoria = string.Empty;
        Status = Status.Pendente;
        Sobrenome = string.Empty;
        Telefone = string.Empty;
        Email = string.Empty;
    }

    [SetsRequiredMembers]
    public Lead(string nome, int identificador, double preco, string suburbio, string categoria, string sobrenome, string telefone, string email, string? descricao) : base(Guid.NewGuid())
    {
        Nome = nome;
        Identificador = identificador;
        Preco = preco;
        Suburbio = suburbio;
        Categoria = categoria;
        Status = Status.Pendente;
        Sobrenome = sobrenome;
        Telefone = telefone;
        Email = email;
        Descricao = descricao;
    }

    [Required(AllowEmptyStrings = false, ErrorMessage = "O nome não pode ser vazio ou nulo.")]
    [NotNull]
    [Range(0, 200)]
    public string Nome { get; internal set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "O sobrenome não pode ser vazio ou nulo.")]
    [NotNull]
    [Range(0, 200)]
    public string Sobrenome { get; internal set; }

    [Required(ErrorMessage = "O identificador não pode ser vazio ou nulo.")]
    [NotNull]
    public int Identificador { get; internal set; }

    [Required(ErrorMessage = "O telefone não pode ser vazio ou nulo.")]
    [NotNull]
    public string Telefone { get; internal set; }

    [Required(ErrorMessage = "O email não pode ser vazio ou nulo.")]
    [NotNull]
    [EmailAddress]
    public string Email { get; internal set; }

    [Required(ErrorMessage = "O preço deve ser informado.")]
    public double Preco { get; internal set; }

    [Required(ErrorMessage = "O subúbio deve ser informado.")]
    [NotNull]
    [Range(0, 30)]
    public string Suburbio { get; internal set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "A categoria não pode ser vazia ou nula.")]
    [NotNull]
    [Range(0, 20)]
    public string Categoria { get; internal set; }

    public Status Status { get; internal set; }

    public string? Descricao { get; internal set; }

    public void AplicarDesconto()
    {
        Preco -= (Preco * 0.1);
    }

    public void AtualizarStatus(Status status)
    {
        Status = status;
    }
}
