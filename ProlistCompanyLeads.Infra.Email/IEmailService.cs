namespace ProlistCompany.Leads.Infra.Email;

public interface IEmailService
{
    Task EnviarEmail(string de, string para, string titulo, string corpo);
}
