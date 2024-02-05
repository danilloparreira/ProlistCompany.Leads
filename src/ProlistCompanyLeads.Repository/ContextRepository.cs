namespace ProlistCompany.Leads.Repository;

internal class ContextRepository : DbContext
{
    public DbSet<Lead> Leads { get; set; }

    /// <summary>
    /// <see cref="DbContext.OnConfiguring(DbContextOptionsBuilder)"/>
    /// </summary>
    /// <param name="optionsBuilder">Opções para realizar a construção desejada do contexto.</param>
    [ExcludeFromCodeCoverage]
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        ArgumentNullException.ThrowIfNull(optionsBuilder);

        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Lead;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.EnableDetailedErrors();

        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }

    /// <summary>
    /// <see cref="DbContext.OnModelCreating(ModelBuilder)"/>
    /// </summary>
    /// <param name="modelBuilder">Configurações dos modelos transacionados nesse contexto.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.Entity<Lead>().HasData(
            new(
                nome: "Alexandre",
                identificador: 123,
                preco: 79.14,
                suburbio: "Av Pres. Vargas",
                categoria: "Tester",
                sobrenome: "Soares",
                telefone: "+5578915257395",
                email: "soaresale@bol.com.br",
                descricao: "Cliente assíduo"
                ),
            new(
                nome: "Macário",
                identificador: 312,
                preco: 512.00,
                suburbio: "Av Pres. Vargas",
                categoria: "Tester",
                sobrenome: "Costa",
                telefone: "+5578915257395",
                email: "soaresale@bol.com.br",
                descricao: null
                ),
            new(
                nome: "Yuri",
                identificador: 835,
                preco: 51356.4574,
                suburbio: "Av Pres. Vargas",
                categoria: "Tester",
                sobrenome: "Marçal",
                telefone: "+5578915257395",
                email: "soaresale@bol.com.br",
                descricao: string.Empty
                ),
            new(
                nome: "Ada",
                identificador: 780,
                preco: 134211211888766.00,
                suburbio: "Av Pres. Vargas",
                categoria: "Tester",
                sobrenome: "Byron",
                telefone: "+5578915257395",
                email: "soaresale@bol.com.br",
                descricao: "Em negociação"
                ));
    }
}
