using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure; // Adicionado para garantir o acesso ao DbContextOptionsBuilder
using Seguradora.Dados.Models; // Substitua "SeuProjeto.Models" pelo namespace correto onde a classe Cliente está definida

public class SeguradoraContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=DESKTOP-3TIO6TG\LOCALHOST;Database=SeguradoraDB;Trusted_Connection=True;",
            sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure();
            });
    }
}