using Seguradora.Dados;
using System.Collections.Generic;

namespace Seguradora.Negocio
{
    public class ClienteService
    {
        private List<Cliente> _clientes = new List<Cliente>();

        public void AdicionarCliente(Cliente cliente)
        {
            _clientes.Add(cliente);
        }

        public List<Cliente> ObterTodos()
        {
            return _clientes;
        }

    }
}
