   M S B A M L   `   `   `  ����J  FSistemadeVendas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SistemadeVendas.ViewsSistemadeVendas.Views  5   	   +    %SistemadeVendas.Views.Produtolistwind   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:SistemadeVendas.Views     5   	     � Title$  Produtolistwind��5   	   $	��450��6!   $	��800��6.   .��5	      �  � RowDefinitions 5
   
   �� 5      $��20 �6   �� 5      $��47 �6   �� 5      .+�5   
   o�  o� 
IsMainMenu . .@�5      m� $��_Arquivo��6   .@�5      m� -   5        $��_Novo��5      6G   m� 5      $
��Sair��6    m� InputGestureText$ Ctrl+E��6)   5      5      �� 5   
   $��1��6   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5   +   $��1��6   $��5q�6       
IsReadOnly .    AutoGenerateColumns .     AlternatingRowBackground �	#FFE5E5E5 �� AlternationCount$ 2��5   X   $��2��6m   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5      $

 Nome��6%    63   �� *Nomep+  5      $
 Marca��6%    64   �� *Marca+  5      $
 Valor��6%    64   �� *
ValorVenda+ �� ConverterCulture$ pt-BR�� �� StringFormat$ C��  5       $
 Descrição��6%    68   �� *	Descricao+5$      5&      5'      