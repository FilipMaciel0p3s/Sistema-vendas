﻿using System;
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
    /// Lógica interna para ProdVenListadd.xaml
    /// </summary>
    public partial class ProdVenListadd : Window
    {
       
            private List<Produto> _produtosList = new List<Produto>();

            public List<Produto> ProdutosSelecionados { get; private set; } = new List<Produto>();

            public ProdVenListadd()
            {
                InitializeComponent();
                Loaded += ProdVenListadd_Loaded;
            }

            private void ProdVenListadd_Loaded(object sender, RoutedEventArgs e)
            {
                LoadDataGrid();
            }

            private void BtnSearch_Click(object sender, RoutedEventArgs e)
            {
                var text = txtSearch.Text;

                var filteredList = _produtosList.Where(i => i.Nomep.ToLower().Contains(text));
                dataGrid.ItemsSource = filteredList;
            }

            private void BtnAdicionarProdutos_Click(object sender, RoutedEventArgs e)
            {
                var itens = dataGrid.Items;
                ProdutosSelecionados.Clear();

                foreach (Produto produto in itens)
                {
                    if (produto.IsSelected)
                        ProdutosSelecionados.Add(produto);
                }

                if (ProdutosSelecionados.Count == 0)
                    MessageBox.Show("Nenhum produto foi selecionado!", "", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Close();
            }
            private void LoadDataGrid()
            {
                try
                {
                    _produtosList = new ProdutoDAO().List();
                    dataGrid.ItemsSource = _produtosList;

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

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Produtos open = new Produtos();

            open.ShowDialog();
        }
    }   }

