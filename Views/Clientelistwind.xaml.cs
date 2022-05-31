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
using System.Windows.Shapes;
using SistemadeVendas.Models;

namespace SistemadeVendas.Views
{
    /// <summary>
    /// Lógica interna para Clientelistwind.xaml
    /// </summary>
    public partial class Clientelistwind : Window
    {
        public Clientelistwind()
        {
            InitializeComponent();
            Loaded += Clientelistwind_Loaded;
        }

        private void Clientelistwind_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            try
            {
                var dao = new ClienteDAO();

                dataGrid.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void MenuItem_Novo_Click(object sender, RoutedEventArgs e)
        {
            var window = new Cliente();
            window.ShowDialog();
            LoadDataGrid();
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            var ClientesSelected = dataGrid.SelectedItem as Clientes;

            var window = new Cliente(ClientesSelected.Id);
            window.ShowDialog();
            LoadDataGrid();
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            var ClientesSelected = dataGrid.SelectedItem as Clientes;

            var result = MessageBox.Show($"Deseja realmente remover o cliente `{ClientesSelected.Nome}`?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new ClienteDAO();
                    dao.Delete(ClientesSelected);
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

     
    }
}

