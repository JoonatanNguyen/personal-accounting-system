   M S B A M L   `   `   `  ����\  XPersonal_Accounting_System_WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Personal_Accounting_System_WPFApp!Personal_Accounting_System_WPFApp  5      =    7Personal_Accounting_System_WPFApp.ShowUsersTransactions   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:Personal_Accounting_System_WPFApp     5        N� 
Background
  ����� N� Title$ ShowUsersTransactions��5
      $��377.714��6%   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��59* �6   �� 5      $
��113* �6   .+�5   
   �� $��
Users List��6   $
��Left=�6%   $	��Top=�6@   $��	10,17,0,0q�6X   $��71��6k   $��26��6v   �� 5   
   $��User controllers��6   $
��Left=�6+   $	��Top=�6F   $��1��6^   $��17.714,17,0,0q�6n   $	��142��6�   $��26��6�   �� 5   
   -   5         ��Name$ UsersListBox��5      $
��Left=�6(   $	��100��6C   $	��Top=�6P   $	��100��6h   $��
10,151,0,0q�6t   ��5      �� 5      .R�5      �� �� 5      ��6$   �� *	ChildName+ �� 5      ��6$   �� *
ParentName+5      5      5      �� 5   
   -   5         ��Name$ 	UsersName��5      $��User's name��6#   $
��Left=�69   $	��Top=�6T   $��	10,83,0,0q�6l   $��86��6   $��26��6�   �� 5   
   -   5        $��Modify��5      $
��Left=�6"   $	��Top=�6=   $��75��6U   $��28.286,117,0,0q�6`   $��1��6x   6�   �� 5    
   -   5        $��Show Transactions��5       $
��Left=�6-   $	��Top=�6H   $	��108��6`   $��1��6l   $��51.286,172,0,0q�6|   6�   �� 5!   
   -   5        $	��Add��5!      $
��Left=�6   $	��Top=�6:   $��75��6R   $��1��6]   $��133.286,117,0,0q�6m   6�   5#      5$      