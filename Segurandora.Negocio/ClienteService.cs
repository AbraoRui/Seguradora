using Seguradora.Dados.Models;
using System.Collections.Generic;
using System.Linq;
using Seguradora.Dados;
using Microsoft.EntityFrameworkCore; // Adicionado para corrigir CS1061
using Microsoft.Data.SqlClient;


namespace Seguradora.Negocio
{
    public class ClienteService
    {
        // Nenhuma alteração necessária neste arquivo para o IDE0305.
        // Não há inicialização de coleção que possa ser simplificada.
        // Caso o diagnóstico IDE0305 esteja ocorrendo em outro arquivo, por favor, forneça o trecho correspondente para análise.
        public List<Cliente> ObterTodos()
        {
            using (var context = new SeguradoraContext())
            {
                return [.. context.Clientes];
            }
        }

        public void AdicionarCliente(Cliente cliente)
        {
            using (var context = new SeguradoraContext())
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
            }
        }

        // Pesquisar por nome do cliente
        public List<Cliente> PesquisarPorNome(string nome)
        {
            using (var context = new SeguradoraContext())
            {
                // StartsWith traduz para "LIKE 'nome%'" no SQL Server
                return context.Clientes
                              .Where(c => c.Nome.StartsWith(nome))
                              .ToList();
            }
        }
    }
    
}
