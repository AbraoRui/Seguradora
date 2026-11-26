using System;
using System.Windows;
using Seguradora.Dados.Models;
using Seguradora.Negocio;

namespace Seguradora.Apresentacao
{
    public partial class CadastroClienteWindow : Window
    {
        private ClienteService _clienteService = new ClienteService();

        public CadastroClienteWindow()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            // Validação dos campos obrigatórios
            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtCpf.Text))
            {
                MessageBox.Show("Os campos Nome e CPF são obrigatórios!", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var novoCliente = new Cliente
                {
                    Nome = txtNome.Text.Trim(),
                    CPF = txtCpf.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim()
                };

                _clienteService.AdicionarCliente(novoCliente);

                MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);

                // Define o resultado como true para avisar a MainWindow que deu tudo certo
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o cliente: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            // Fecha a janela sem salvar
            this.DialogResult = false;
            this.Close();
        }
    }
}