using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Seguradora.Dados.Models; // Adicione esta linha
using Microsoft.Data.SqlClient;

namespace Seguradora.Dados
{
    public class SeguradoraContext : DbContext // Corrigido: herda de DbContext
    {
        // Representa a tabela de Clientes no banco de dados
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // String de conexão com o SQL Server LocalDB
            // O banco "SeguradoraDB" será criado automaticamente
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-3TIO6TG\LOCALHOST;Database=SeguradoraDB;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-3TIO6TG\LOCALHOST;Database=SeguradoraDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
