using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SistemadeVendas.DataBase;
using SistemadeVendas.Views;

namespace SistemadeVendas
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                Conexao var = new Conexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


      
        private void Cli_Btn(object sender, RoutedEventArgs e)
        {
            Cliente cli = new Cliente();

            cli.ShowDialog();
        }

      

        private void Venda_Btn(object sender, RoutedEventArgs e)
        {
            Venda ven = new Venda();

            ven.ShowDialog();
        }

        

        private void Prod_Btn(object sender, RoutedEventArgs e)
        {
            Produtos prod = new Produtos();
            prod.ShowDialog();
        }

        private void Close_btn(object sender, RoutedEventArgs e)
        {

            Close();
        }

        private void CC_click(object sender, RoutedEventArgs e)
        {

            Cliente cli = new Cliente();

            cli.ShowDialog();
        }

  

        private void pp_click(object sender, RoutedEventArgs e)
        {
            Produtos prod = new Produtos();
            prod.ShowDialog();
        }

        private void vv_click(object sender, RoutedEventArgs e)
        {
            Venda ven = new Venda();

            ven.ShowDialog();
        }

        private void LLcli_click(object sender, RoutedEventArgs e)
        {
            Clientelistwind llcli = new Clientelistwind();

            llcli.ShowDialog();
        }

        private void llfun_click(object sender, RoutedEventArgs e)
        {
            Funcionariolistwind llfun = new Funcionariolistwind();

            llfun.ShowDialog();
        }

        private void lispro_click(object sender, RoutedEventArgs e)
        {
            Produtolistwind open = new Produtolistwind();

            open.ShowDialog();

        }

        private void Listven_click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();

        }
    }
}
