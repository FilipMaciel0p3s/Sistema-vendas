   M S B A M L   `   `   `  ����J  FSistemadeVendas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SistemadeVendasSistemadeVendas  5   	       SistemadeVendas.Venda   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:SistemadeVendas     5   	     � Title$  Venda��5   	   $	��515��6   
�������$	��999��66   .��5	      � $��0,0,2,6q�6    � RowDefinitions 5
   
   �� 5      $��18 �6   �� 5      $��18 �6   �� 5      $��44 �6   �� 5      $��0 �6   �� 5      $��70 �6   �� 5      �� 5      $	��116 �6   �� 5      $��71 �6   .+�5   
   �� $��0��6   .+�5      o� .@�5      m� $��_Arquivo��6   $��20��6-   .@�5      m� -   5        $��_Sair��5      6.   5      5      5      �� 5   
   $��2��6   $��
10,1,10,10q�6"    �� Orientation$ 
Horizontal=�66   .+�5!      (  "System.Windows.Controls.DatePicker  -   5          Name$ dtPickerData��5#      
�������$	��210��5$       J� RenderTransformOrigin$ 0.505,0.833&�6   5%      �� 5'   
   $��6��6   $ 
Horizontal=�6"   $��
15,7,10,50q�6;   .+�5(      �� -   5         ��Name$ comboBoxFuncionario��5(       �� DisplayMemberPath$
 Nome��5)       �� SelectedValuePath$ Id��5*      $	��296��5+      $��
0,80,0,-55q�6#   5-      �� 5/   
   $��4��6   $��10,10,10,58q�6   .+�50      �� $��30(�51      
 �� Top$ 10��52      $	��227��6!   �� 6.   $�Itens da compr��62   �� 6J   $�a:��6N   6[   �� 53      -   5        	 ��Name$	 btnAddProdutos��55      
 �� Right$
 10��54      $	��250��56      $��40��6   $��Adicionar Produto��58      $��Right=�59       �� Left$	 697��6-   $ 10��6?   5;      �� 5@   
   $
��Left=�6   $	��228��62   $��10,0,0,0q�6?   $��5��6Q   $��2��6^   $	��Top=�6o   $	��979��6�   .��5B      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5B      $��5��6)      CanUserAddRows .     CanUserDeleteRows .     AutoGenerateColumns .     AlternatingRowBackground �	#FFE5E5E5   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5G      $ 0.5,0.5&�6,   $��2��6L   $	��218��6]   $	��953��6j   z�5H      V� 5I      .~�5J      �� �� 5K       �� AngleX$ 0.413Q�6(   �� 5L      T� 5M       T� X$ 0.743Q�6-   5N         Columns 5P      0  *System.Windows.Controls.DataGridTextColumn  5Q      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6)      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *Id+  5R      $ Produto��6)    .  6L   �� *Produto.Nome+  5S      $ 
Quantidade��6)    6=   �� *
Quantidade+  5U      $ Valor unitário��6)    .  6S   �� *Valor+ �� ConverterCulture$ pt-BR�� �� StringFormat$ C��  5V      $ Valor Total��6)    .  6P   �� *
ValorTotal+$ pt-BR��$ C��4  .System.Windows.Controls.DataGridTemplateColumn  5X      $ Remover��6-      CellTemplate 5Y      �� 5Z      .R�5[   "   �� -   5        $��Remover��5[   )   $��15��5\   )   $��10(�65   $��0q�6C    � ToolTip$) #Remover produto da lista de compras��5]   )   6W   5^      5`      5b      5c      �� 5f   
   $��6��6   $��	0,0,20,45q�6   $��40��61   $��Bottom=�6=   .+�5g      �� -   5         ��Name$ txtFormaPagamento��5h      $ 16��5g      $	��306��5i      $��0q�6#   $��30��6.   $	 108��6:   �� 5k      -   5        $ txtValorTotal��5l      $
 0��5k      {�.  $��Right=�5n      $	��230��5o      $��28��6!   $	 354��6-   $	 108��6?   5p      �� 5s   
   $��7��6   $��636,10,10,10q�6"   $ 
Horizontal=�68   .+�5t      �� -	   5        $	 	btnSalvar��5u      $	��190��5v      $��40��6   $	��0,5q�5w   )   $��Realizar Venda��66   �� 5x      -
   5        $	 btnClose��5y      $	��140��5z      $��40��6   $��10,5,0,5q�6)   
���  ��$
��Sair��5{   9   $ 0.5,0.5&�6H   z�5|      V� 5}      .~�5~      �� �� 5      �� 5�       �� Angle$ -0.065Q�6*   T� 5�      5�      5�      5�      �� 5�   
   -   5        $ comboBoxcliente��5�      $
��Left=�5�      $��
636,92,0,0q�6.   $��6��6B   $	��Top=�6O   $	��333��6g   $��34��6s   $��2��6   $
 Nome��5�      $ Id��5�      5�      5�      