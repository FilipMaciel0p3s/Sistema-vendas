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
using SistemadeVendas.Views;
using SistemadeVendas.Helper;

namespace SistemadeVendas
{
    /// <summary>
    /// Lógica interna para Venda.xaml
    /// </summary>
    public partial class Venda : Window
    {
        private Vendas _vend = new Vendas();


        private List<VendaItem> _VendaItemlist = new List<VendaItem>();

        public Venda()
        {
            InitializeComponent();
            Loaded += CompraWindow_Loaded;
        }

        private void CompraWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (dtPickerData.SelectedDate != null)
                _vend.DataVenda = (DateTime)dtPickerData.SelectedDate;

            if (comboBoxFuncionario.SelectedItem != null)
                _vend.funcVenda = comboBoxFuncionario.SelectedItem as Funcionario1;

            if (comboBoxFuncionario.SelectedItem != null)
                _vend.Clivenda = comboBoxcliente.SelectedItem as Cliente;

            _vend.Formapagamento = txtFormaPagamento.Text;
            _vend.ValorTotal = UpdateValorTotal();
            SalvarCompra();
        }

        private void BtnAddProduto_Click(object sender, RoutedEventArgs e)
        {
            var window = new ProdVenListadd();
            window.ShowDialog();

            var produtosSelecionadosList = window.ProdutosSelecionados;
            var count = 1;

            foreach (Produto produto in produtosSelecionadosList)
            {

                if (!_VendaItemlist.Exists(item => item.provend.Id == produto.Id))
                {
                    _VendaItemlist.Add(new VendaItem()
                    {
                        Id = count,
                        provend = produto,
                        Quantidade = 1,
                        Valor = produto.ValorVenda,
                        ValorTotal = produto.ValorVenda
                    }) ;

                    count++;
                }
            }

            LoadDataGrid();
        }

        private void BtnRemoverProduto_Click(object sender, RoutedEventArgs e)
        {
            var itemSelected = dataGrid.SelectedItem as VendaItem;
            _VendaItemlist.Remove(itemSelected);
            LoadDataGrid();
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var item = e.Row.Item as VendaItem;

            var value = (e.EditingElement as TextBox).Text;
            _ = int.TryParse(value, out int quantidade);

            if (quantidade > 1)
            {
                item.Quantidade = quantidade;
                item.ValorTotal = quantidade * item.Valor;
            }

            LoadDataGrid();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SalvarCompra()
        {
            try
            {
                
               
                    var dao = new VendaDAO();
                    dao.Insert(_vend);

                    MessageBox.Show($"Compra realizada com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);

                    this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private double UpdateValorTotal()
        {
            double valor = 0.0;

            _VendaItemlist.ForEach(item => valor += item.ValorTotal);

            txtValorTotal.Text = valor.ToString("C");

            return valor;
        }

        private void LoadDataGrid()
        {
            _ = UpdateValorTotal();
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = _VendaItemlist;
        }

        private void LoadData()
        {
            dtPickerData.SelectedDate = DateTime.Now;

            try
            {
                comboBoxFuncionario.ItemsSource = new FuncionarioDAO().List();
                comboBoxcliente.ItemsSource = new ClienteDAO().List();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
