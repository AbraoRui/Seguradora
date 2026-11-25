using Segurandora.Dados;
using System.Collections.Generic;

namespace Segurandora.Negocio
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
