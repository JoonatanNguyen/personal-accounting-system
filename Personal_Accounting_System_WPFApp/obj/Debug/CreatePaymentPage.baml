   M S B A M L   `   `   `  ����\  XPersonal_Accounting_System_WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Personal_Accounting_System_WPFApp!Personal_Accounting_System_WPFApp  5      5    /Personal_Accounting_System_WPFApp.CreatePayment   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:Personal_Accounting_System_WPFApp     5        N� 
Background
  ����� N� Title$ CreatePaymentPage��5
      .��5      � $��	0,0,0,-67q�6   .+�5   
   �� -   5         ��Name$ AmountTextBox��5      $
��Left=�6)   $��23��6D    �� TextWrapping$
 Wrap=�6P   $	��Top=�6e   $	��120��6}   $��
145,10,0,0q�6�   �� 5   
   -   5        $ ProductNameTextBox��5      $
��Left=�6.   $��23��6I   $
 Wrap=�6U   $	��Top=�6j   $	��120��6�   $��
145,87,0,0q�6�   �� 5   
   -   5        $ ExplanationTextBox��5      $
��Left=�6.   $��23��6I   $
 Wrap=�6U   $	��Top=�6j   $	��120��6�   $��145,125,0,0q�6�   �� 5   
   -   5        $ PayerAccountTextBox��5      $
��Left=�6/   $��23��6J   $
 Wrap=�6V   $	��Top=�6k   $	��120��6�   $��145,163,0,0q�6�   �� 5   
   -   5        $ ReceiverAccountTextBox��5      $
��Left=�62   $��23��6M   $
 Wrap=�6Y   $	��Top=�6n   $	��120��6�   $��145,199,0,0q�6�   �� 5   
   -   5        $ OwnerOfPurchaseTextBox��5      $
��Left=�62   $��23��6M   $
 Wrap=�6Y   $	��Top=�6n   $	��120��6�   $��145,236,0,0q�6�   �� 5   
   -   5        $ CategoryTextBox��5      $
��Left=�6+   $��23��6F   $
 Wrap=�6R   $	��Top=�6g   $	��120��6   $��145,273,0,0q�6�   �� 5   
   -   5         ��Name$ CreateButton��5      $��Create��6'   $
��Left=�68   $	��Top=�6S   $��75��6k   $��132,321,0,0q�6v   6�   �� 5   
   $��Amount��6   $
��Left=�6!   $	��Top=�6<   $��21,7,0,0q�6T   $��97��6f   �� 5   
   $
��Date��6   $
��Left=�6   $	��Top=�6:   $��	21,47,0,0q�6R   $��97��6e   �� 5   
   $��Product Name��6   $
��Left=�6'   $	��Top=�6B   $��	21,84,0,0q�6Z   $��97��6m   �� 5   
   $��Explanation��6   $
��Left=�6&   $	��Top=�6A   $��
21,122,0,0q�6Y   $��97��6m   �� 5   
   $��Payer Account��6   $
��Left=�6(   $	��Top=�6C   $��
21,160,0,0q�6[   $��97��6o   �� 5   
   $��Receiver Account��6   $
��Left=�6+   $	��Top=�6F   $��
21,196,0,0q�6^   $	��110��6r   �� 5   
   $��Owner of purchase��6   $
��Left=�6,   $	��Top=�6G   $��
21,233,0,0q�6_   $	��110��6s   �� 5   
   $��Category��6   $
��Left=�6#   $	��Top=�6>   $��
21,269,0,0q�6V   $��97��6j   (  "System.Windows.Controls.DatePicker  5   
   -	   5          Name$ 	DateInput��5      $
��Left=�6(   $	��Top=�6C    J� RenderTransformOrigin$ 1.512,1.328&�6[   $��
145,49,0,0q�6   �� 5   
   $��Your Account��6   $
��Left=�6'   $	��Top=�6B   $��357,29,-188.792,0q�6Z   $	��132��6u   �� 5   
   -
   5         ��Name$ 	AccountId��5      $
��Left=�6#   $	��Top=�6>   $��527,29,-267.792,0q�6V   $��41��6q   $��26��6|   &   System.Windows.Controls.DataGrid  5    
   -   5          Name$ CategoryList��5       $
��Left=�6)   $	��187��6D   $��409,139,-295.792,0q�6Q   $	��Top=�6m   $	��187��6�   �� 5!   
   $��Categories: ��6   $
��Left=�6'   $��409,104,-208.792,0q�6B   $	��Top=�6^   $	��100��6v   5"      5#      