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

namespace SistemadeVendas
{
    /// <summary>
    /// Lógica interna para Produtos.xaml
    /// </summary>
    public partial class Produtos : Window
    {

    

         private int _id;

        private Produto prod;

        public Produtos()
        {
            InitializeComponent();
            Loaded += Produtolistwind_Loaded;
        }

        public Produtos(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += Produtolistwind_Loaded;
        }

        private void Produtolistwind_Loaded(object sender, RoutedEventArgs e)
        {
            prod = new Produto();
        

            if (_id > 0)
                FillForm();
        }


        private void Salvar_prod_click(object sender, RoutedEventArgs e)
        {

            prod.Nomep = txtnome.Text;
            prod.Descricao = txtdis.Text;
            prod.Marca = txtmarca.Text;
            if (double.TryParse(txtval.Text, out double ValorVenda))
                prod.ValorVenda = ValorVenda;


            SaveData();
        }

        private void SaveData()
        {
            try
            {

                var dao = new ProdutoDAO();
                var text = "atualizado";

                if (prod.Id == 0)
                {
                    dao.Insert(prod);
                    text = "adicionado";
                }
                else
                    dao.Update(prod);

                MessageBox.Show($"O Produto foi {text} com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                CloseFormVerify();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseFormVerify()
        {
            if (prod.Id == 0)
            {
                var result = MessageBox.Show("Deseja continuar adicionando produto?", "Continuar?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.No)
                    this.Close();
                else
                    ClearInputs();
            }
            else
                this.Close();
        }

        private void FillForm()
        {
            try
            {
                var dao = new ProdutoDAO();
                prod = dao.GetById(_id);
                prod.Nomep = txtnome.Text;
                prod.Descricao = txtdis.Text;
                prod.Marca = txtmarca.Text;
                if (double.TryParse(txtval.Text, out double ValorVenda))
                    prod.ValorVenda = ValorVenda;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void ClearInputs()
        {
            txtnome.Text = "";
             txtdis.Text = "";
             txtmarca.Text = "";
            txtval.Text = null;
        }

        private void Cancel_btn(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Deseja continuar adicionando cliente?", "Continuar?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
                this.Close();
            else
                ClearInputs();
        }

        private void List_click(object sender, RoutedEventArgs e)
        {
            Produtolistwind open = new Produtolistwind();

            open.ShowDialog();
        }
    }
}
