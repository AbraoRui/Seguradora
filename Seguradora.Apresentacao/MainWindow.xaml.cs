using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Seguradora.Dados;
using Seguradora.Dados.Models;
using Seguradora.Negocio;

namespace Seguradora.Apresentacao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClienteService _clienteService = new ClienteService();
        //private TextBox txtEmail;

        public MainWindow()
        {
            InitializeComponent();

            //txtEmail = (TextBox)this.FindName("txtEmail");

            //btnSalvar.Click += btnSalvar_Click;

            // Tenta carregar os dados, mas captura o erro para não quebrar a janela
            try
            {
                CarregarClientes();
            }
            catch (Exception ex)
            {
                // Mostra a mensagem real do erro (se houver uma exceção interna, mostra ela)
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message, "Erro ao conectar ao banco");
            }
        }

        private void CarregarClientes()
        {
            dgClientes.ItemsSource = null;
            dgClientes.ItemsSource = _clienteService.ObterTodos();
        }       

        private void btnAbrirCadastro_Click(object sender, RoutedEventArgs e)
        {
            // Instancia a nova janela que criamos anteriormente
            var janelaCadastro = new CadastroClienteWindow();

            // Abre a janela como modal (bloqueia a MainWindow até que ela seja fechada)
            bool? resultado = janelaCadastro.ShowDialog();

            // Se o usuário clicou em "Salvar" na nova janela, atualiza o DataGrid
            if (resultado == true)
            {
                CarregarClientes();
            }
        }

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Implemente a lógica de pesquisa aqui
            string termoPesquisa = txtPesquisaNome.Text.Trim();

            // Se o campo estiver vazio, recarrega todos os clientes
            if (string.IsNullOrWhiteSpace(termoPesquisa))
            {
                CarregarClientes();
                return;
            }

            // Atualiza o DataGrid com o resultado da pesquisa
            dgClientes.ItemsSource = null;
            dgClientes.ItemsSource = _clienteService.PesquisarPorNome(termoPesquisa);
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtPesquisaNome.Clear();
            CarregarClientes(); // Recarrega a lista completa
        }

        private void MenuCadastrarCliente_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Implemente a lógica de cadastro de cliente aqui
            var janelaCadastro = new CadastroClienteWindow();
            bool? resultado = janelaCadastro.ShowDialog();

            if (resultado == true)
            {
                CarregarClientes(); // Atualiza o DataGrid após cadastrar
            }
        }
    }
}