   M S B A M L   `   `   `  ����J  FSistemadeVendas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SistemadeVendas.ViewsSistemadeVendas.Views  5   	   +    %SistemadeVendas.Views.Clientelistwind   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:SistemadeVendas.Views     5   	     � Title$  Lista Clientes��5   	   $��390.379��6    $��1072.555��61   .��5	      �  � RowDefinitions 5
   
   �� 5      $��20 �6   �� 5      $��47 �6   �� 5      .+�5   
   o�  o� 
IsMainMenu . .@�5      m� $��_Arquivo��6   .@�5      m� -   5        $��_Novo��5      6G   m� 5      $
��Sair��6    m� InputGestureText$ Ctrl+E��6)   5      5      �� 5   
   $��1��6   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5   +   $��1��6   $��5q�6       
IsReadOnly .    AutoGenerateColumns .     AlternatingRowBackground �	#FFE5E5E5 �� AlternationCount$ 2��5   X   $��2��6m   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5      $

 Nome��6%    63   �� *Nome+  5      $	
 CPF��6%    62   �� *CPF+  5      $
 E-mail��6%    65   �� *Email+  5      $
 Celular��6%    66   �� *	Celular+  5       $
 Telefone��6%    67   �� *
telefone+  5!      $
 
Logradouro��6%    69   �� *Endereco.Rua+  5"      $
 Numero��6%    65   �� *Endereco.Numero+  5#      $
 Baiiro��6%    65   �� *Endereco.Bairro+  5$      $
 Cidade��6%    65   �� *Endereco.Cidade+  5%      $
 Estado��6%    65   �� *Endereco.Estado+4  .System.Windows.Controls.DataGridTemplateColumn  5&      $
 Ações��6)      CellTemplate 5'      �� 5(      .R�5)      ��  �� Orientation$ 
Horizontal=�6)   .+�5*   "   �� -   5        $��90��5*   )   $��20��64    � ToolTip$ Visualizar Registro��6@   $��0 0 5 0q�6^   $��Editar��6�   �� 5+   "   -   5        $��90��5+   )   $��20��64   $ Excluir Registro��6@   $��Deletar��6w   5,      5-      5/      51      53      54      