   M S B A M L   `   `   `  ����\  XPersonal_Accounting_System_WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Personal_Accounting_System_WPFApp!Personal_Accounting_System_WPFApp  5      ;    5Personal_Accounting_System_WPFApp.ShowKidsTransaction   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:Personal_Accounting_System_WPFApp     5        N� 
Background
  ����� N� Title$ ShowKidsTransaction��5
      $��373.524��6#   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��122* �6   �� 5      $
��251* �6   .+�5   
   �� -   5         ��Name$ ChildrenTransactionLabel��5      $��Children's transactions��62   $
��Left=�6T   $��20.714,10,0,0q�6o   $	��Top=�6�   $	��168��6�   $��26��6�   $��1��6�   �� 5   
   $��Children list��6   $
��Left=�6(   $��	18,10,0,0q�6C   $	��Top=�6V   $	��103��6n   $��26��6z   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ChildrenTransaction��5      $
��Left=�60   $	��164��6K   $��9.714,116,0,0q�6X   $	��Top=�6o   $	��232��6�   $��1��6�   �� 5   
   -   5        $ kidsName��5      $��
child's Id��6"   $
��Left=�67   $��	18,69,0,0q�6R   $	��Top=�6e   $��90��6}   $��24��6�   �� 5   
   -   5         ��Name$ kidsListBox��5      $
��Left=�6'   $	��100��6B   $��
18,127,0,0q�6O   $	��Top=�6c   $	��100��6{   ��5      �� 5      .R�5      �� ��6    �� *	ChildName+5      5      �� 5   
   -   5        $��Today��5      $
��Left=�6!   $	��Top=�6<   $��75��6T   $��21��6_   $��6.714,53,0,0q�6k   $��1��6�   6�   �� 5   
   -   5        $��Monthly��5      $
��Left=�6#   $	��Top=�6>   $��75��6V   $��1��6a   $��86.714,53,0,0q�6q   $��21��6�   6�   �� 5   
   -   5        $��Anual��5      $
��Left=�6!   $	��Top=�6<   $��75��6T   $��1��6_   $��166.714,54,0,0q�6o   $��21��6�   6�   �� 5    
   $��Total expenses:��6   $��266.919,126,-111.543,0q�6*   $	��Top=�6J   $
��Left=�6b   $��96��6}   $��1��6�   �� 5!   
   -   5        $ TotalExpense��5!      $
��Left=�6&   $��266.919,152,-76.543,0q�6A   $	��Top=�6`    J� RenderTransformOrigin$ 0.819,0.259&�6x   $��25��6�   $��61��6�   $��1��6�   �� 5"   
   $��Total income:��6   $��390.919,126,-235.543,0q�6(   $	��Top=�6H   $
��Left=�6`   $��96��6{   $��1��6�   �� 5#   
   -	   5        $ TotalIncome��5#      $
��Left=�6%   $��390.919,157,-200.543,0q�6@   $	��Top=�6`   $ 0.819,0.259&�6x   $��25��6�   $��61��6�   $��1��6�   �� 5$   
   $��Total balance:��6   $��266.919,182,-111.543,0q�6)   $	��Top=�6I   $
��Left=�6a   $��96��6|   $��1��6�   �� 5%   
   -
   5        $ TotalBalance��5%      $
��Left=�6&   $��266.919,208,-76.543,0q�6A   $	��Top=�6`   $ 0.819,0.259&�6x   $��25��6�   $��61��6�   $��1��6�   5&      5'      