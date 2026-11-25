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

            btnSalvar.Click += btnSalvar_Click;
        }

        // AQUI: O método que será executado quando o botão for clicado
        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var novoCliente = new Cliente
            {
                Nome = txtNome.Text,
                CPF = txtCpf.Text,               
            };

            _clienteService.AdicionarCliente(novoCliente);

            // Atualiza o DataGrid
            dgClientes.ItemsSource = null;
            dgClientes.ItemsSource = _clienteService.ObterTodos();

            // Limpa os campos
            txtNome.Clear();
            txtCpf.Clear();
        }
    }
}