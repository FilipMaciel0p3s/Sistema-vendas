   M S B A M L   `   `   `  ����J  FSistemadeVendas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SistemadeVendasSistemadeVendas  5   	        SistemadeVendas.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:SistemadeVendas     5   	     � Title$
  Menu��5   	   $��277.962��6   $��351.604��6'   .��5	      � -   5         �Name$ Produto��5	      $��0,0,0,0q�6   
������� � RowDefinitions 5
   
   �� 5      $��29 �6   �� 5      $��4 �6   �� 5      $	��170 �6   �� 5      $	��148 �6   .+�5   
   �� $��0��6   .+�5      o� .@�5      m� $��	Cadastrar��6   $��20��6.   .@�5      m� -   5        $��_Cliente��5      5      m� 5      -   5        $��Produto��5      60   m� 5      -   5        $��Venda��5      6.   5      �� 5      m� 5      $��	_Listagem��6   $��20��6.   $��59��6:   .@�5      m� -   5        $��_Cliente��5      5!      m� 5#      -   5        $��Funcionario��5#      64   m� 5$      -   5        $��Produto��5$      60   5%      5&      5'      �� 5(   
   -   5         ��Name$ Cliente��5(      $��Cliente��6"   $
��Left=�64   $��	24,21,0,0q�6O   $	��Top=�6b   $��75��6z   $��2��6�   $��26��6�   �� 5)   
   -	   5        $ Produtos��5)      $��produtos��6#   $
��Left=�66   $��	24,68,0,0q�6Q   $	��Top=�6d   $��75��6|   $��26��6�   $��2��6�   �� 5*   
   -
   5        $ Venda��5*      $��vendas��6    $
��Left=�61   $��
24,114,0,0q�6L   $	��Top=�6`   $��75��6x   $��26��6�   $��2��6�   �� 5+   
   -   5        
���  ��$��Fechar��5+   #   $��	248,0,0,0q�64   $	��Top=�6G   $
��Left=�6_   $��75��6z   $��26��6�   $��3��6�   6�   5-      5.      