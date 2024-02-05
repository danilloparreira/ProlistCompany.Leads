namespace ProlistCompany.Leads.Infra.Email;

public class EmailService : IEmailService
{
    public Task EnviarEmail(string de, string para, string titulo, string corpo)
    {
        return Task.CompletedTask;
    }
}
