namespace ProlistCompany.Leads.Models.Base;

/// <summary>
/// Uma entidade tem a responsabilidade de representar objetos mutáveis e com identidade única no domínio que possuem um ciclo de vida.
/// </summary>
/// <typeparam name="TId">Tipo do identificador que será dado para essa entidade</typeparam>
public class Entidade<TId>(TId id) where TId : new()
{
    /// <summary>
    /// Construtor responsável de criar uma nova identificação passada por parâmetro para essa entidade.
    /// </summary>
    /// <param name="id">Identificador para ser inserido nessa entidade.</param>
    //[SetsRequiredMembers]
    //public Entidade(TId id)
    //{
    //    Id = id;
    //}

    /// <summary>
    /// Propriedade responsável por armazenar um identificador para a entidade.
    /// </summary>
    [Key]
    [Column(Order = 0)]
    [Required(ErrorMessage = "É obrigatório o preenchimento do Id para uma entidade.")]
    public required TId Id { get; init; } = id;

    /// <summary>
    /// Propriedade responsável por armazenar a data de inclusão dessa entidade.
    /// </summary>
    [Column(Order = 1)]
    [Required(ErrorMessage = "É obrigatório informar a data que essa entidade sendo incluída.")]
    public DateTimeOffset DataDeInclusao { get; private set; } = DateTimeOffset.Now;

    /// <summary>
    /// Propriedade responsável por armazenar um código para a genrência de concorrência otimista no banco de dados.
    /// </summary>
    [Timestamp]
    [ConcurrencyCheck]
    [Column(Order = 999)]
    [ExcludeFromCodeCoverage]
    public byte[] Timestamp { get; private set; }
}
