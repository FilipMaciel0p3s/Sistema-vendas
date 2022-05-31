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
using MySql.Data.MySqlClient;
using SistemadeVendas.DataBase;
using SistemadeVendas.Interface;
using SistemadeVendas.Helper;
using SistemadeVendas.Models;
using SistemadeVendas.Views;

namespace SistemadeVendas.Views
{
    /// <summary>
    /// Lógica interna para Produtolistwind.xaml
    /// </summary>
    public partial class Produtolistwind : Window
    {
        public Produtolistwind()
        {
            InitializeComponent();
            Loaded += Produtolistwind_Loaded;
        }

        private void Produtolistwind_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            try
            {
                var dao = new ProdutoDAO();

                dataGrid.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void MenuItem_Novo_Click(object sender, RoutedEventArgs e)
        {
            var window = new Produtos();
            window.ShowDialog();
            LoadDataGrid();
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            var prodSelected = dataGrid.SelectedItem as Produto;

            var window = new Cliente(prodSelected.Id);
            window.ShowDialog();
            LoadDataGrid();
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            var prodSelected = dataGrid.SelectedItem as Produto;

            var result = MessageBox.Show($"Deseja realmente remover o produto `{prodSelected.Nomep}`?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new ProdutoDAO();
                    dao.Delete(prodSelected);
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
