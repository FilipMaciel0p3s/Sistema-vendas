   M S B A M L   `   `   `  ����J  FSistemadeVendas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SistemadeVendas.ViewsSistemadeVendas.Views  5   	   /    )SistemadeVendas.Views.Funcionariolistwind   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:SistemadeVendas.Views     5   	   LmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     5   
     � Title$  Lista de Funcionários��5	   	   $��448.6��6'   $��836.5��66   .��5
      � $��0,0,0,35q�6    � ColumnDefinitions 5   
   �� 5      $
��292* �6   �� 5      $	��57* �6    � RowDefinitions 5   
   �� 5      $��22 �6   �� 5      .+�5   
   o�  o� 
IsMainMenu . $��2��6!   .@�5      m� $��_Arquivo��6   .@�5      m� -   5        $
��Sair��5       m� InputGestureText$ Ctrl+E��6)   6C   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5   4   $��1��6   $��
5,5,10,-30q�6       
IsReadOnly .    AutoGenerateColumns .     AlternatingRowBackground �	#FFE5E5E5	 �� AlternationCount$	 2��5   X   $��2��6m   
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5      $ Nome do Funcionário��6%    6B   �� *Nome+  5      $
 Sexo��6%    63   �� *Sexo.Genero+  5       $	 CPF��6%    62   �� *CPF+  5!      $ E-mail��6%    65   �� *Email+  5"      $ Celular��6%    66   �� *	Celular+  5#      $ Função��6%    65   �� *Funcao+  5$      $ Salário��6%    66   �� *	Salario+ �� ConverterCulture$ pt-BR�� �� StringFormat$ C��4  .System.Windows.Controls.DataGridTemplateColumn  5&      $ Delete��6)      CellTemplate 5'      �� 5(      .R�5)      ��  �� Orientation$ 
Horizontal=�6)   .+�5*   "   �� -   5        $��90��5*   )   $��20��64    � ToolTip$ Excluir Registro��6@   $��Deletar��6w   5+      5,      5.      50      52      53      