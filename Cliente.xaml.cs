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

    public partial class Cliente : Window
    {
     
                private int _id;

        private Clientes _cli;
         public Cliente()
        {
            InitializeComponent();
           Loaded += Clientelistwind_Loaded;
        }

        public Cliente(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += Clientelistwind_Loaded;
        }

        private void Clientelistwind_Loaded(object sender, RoutedEventArgs e)
        {
            _cli = new Clientes();

            LoadComboBox();

            if (_id > 0)
                FillForm();
        }


        private void Salvar_btn(object sender, RoutedEventArgs e) {
            _cli.Nome = Nometxt.Text;
            _cli.CPF = cpftxt.Text;
            _cli.RG = rgtxt.Text;
            _cli.telefone = teltxt.Text;
            _cli.Email = emailtxt.Text;
            _cli.Celular = celtxt.Text;


            if (dtPickerDataNascimento.SelectedDate != null)
                _cli.DataNascimento = (DateTime)dtPickerDataNascimento.SelectedDate;           
          

                _cli.Endereco = new Endereco();
            _cli.Endereco.Rua = ruatxt.Text;
            _cli.Endereco.Bairro = Baitxt.Text;
            _cli.Endereco.Cidade = cidadetxt.Text;

            if (int.TryParse(Numtxt.Text, out int numero))
                _cli.Endereco.Numero = numero;

            if (comboBoxEstado.SelectedItem != null)
                _cli.Endereco.Estado = comboBoxEstado.SelectedItem as string;

            SaveData();
        }

        private void SaveData()
        {
            try
            {

                var dao = new ClienteDAO();
                var text = "atualizado";

                if (_cli.Id == 0)
                {
                    dao.Insert(_cli);
                    text = "adicionado";
                }
                else
                    dao.Update(_cli);

                MessageBox.Show($"O cliente foi {text} com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                CloseFormVerify();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FillForm()
        {
            try
            {
                var dao = new ClienteDAO();
                _cli = dao.GetById(_id);
                
                _cli.Nome = Nometxt.Text;
                _cli.CPF = cpftxt.Text;
                _cli.RG = rgtxt.Text;
                _cli.telefone = teltxt.Text;
                _cli.Email = emailtxt.Text;
                _cli.Celular = celtxt.Text;

                if (_cli.Endereco != null)
                {

                    _cli.Endereco.Rua = ruatxt.Text;
                    Numtxt.Text = _cli.Endereco.Numero.ToString();
                    _cli.Endereco.Bairro = Baitxt.Text;
                    _cli.Endereco.Cidade = cidadetxt.Text;

                    comboBoxEstado.SelectedValue = _cli.Endereco.Estado;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseFormVerify()
        {
            if (_cli.Id == 0)
            {
                var result = MessageBox.Show("Deseja continuar adicionando cliente?", "Continuar?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.No)
                    this.Close();
                else
                    ClearInputs();
            }
            else
                this.Close();
        }

        private void LoadComboBox()
        {
            try
            {
                comboBoxEstado.ItemsSource = Estado.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearInputs()
        {
            Nometxt.Text = "";
            cpftxt.Text = "";
            cpftxt.Text = "";
            dtPickerDataNascimento.SelectedDate = null;
            teltxt.Text = "";
            emailtxt.Text = "";
            celtxt.Text = "";
          
        }

        private void Cancel_btn(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Deseja continuar adicionando cliente?", "Continuar?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
                this.Close();
            else
                ClearInputs();
        }



        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Funcionariolistwind fun = new Funcionariolistwind();

            fun.ShowDialog();
        }

    

        private void lista_click(object sender, RoutedEventArgs e)
        {
            Clientelistwind open = new Clientelistwind();

            open.ShowDialog();
        }

     
    }
 }

