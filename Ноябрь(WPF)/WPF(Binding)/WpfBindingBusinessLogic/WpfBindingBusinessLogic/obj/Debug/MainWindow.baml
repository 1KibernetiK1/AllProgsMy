   M S B A M L   `   `   `  ����R  NWpfBindingBusinessLogic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WpfBindingBusinessLogicWpfBindingBusinessLogic  5   	   (    "WpfBindingBusinessLogic.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:WpfBindingBusinessLogic     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5
      � -   5        $��MainGrid��5
       � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��4* �6   .+�5   
   �� -   5        $��
ListboxCar��5      $��14(�6$   
�������$��0��6E   $��5q�6U   � 5   
   -   5        $��Cargr��5      $��1��6    � DataContext 6,   ��  �� ElementName$ 
ListboxCar�� �� Path$ SelectedItem� � RowDefinitions 5      �� 5      $��50 �6    �� 5      $��* �6    .+�5      �� $��0��6   
������� �� CornerRadius$ 	30,0,30,0��66   $��3q�6O   
���**��._�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�66   $��Center=�6Q   .+�5      �� $��20(�6    $��Model:��6.   �� 5      $��20(�6    ��6.   �� *Model+5      5      � 5      $��1��6    5      �� 5      $��1* �6'   �� 5       $��3* �6'   .+�5#      �� $��1��6   ��6(   �� *ImageSource+�� 5$      $��0��6   
�������.+�5%      �� $ 
Horizontal=�6!   .+�5&      �� $!��Производитель:��6$   �� 5'      ��6$   �� *Manufacturer+5(      �� 5)      $ 
Horizontal=�6!   .+�5*      �� $��	Цена:��6$   �� 5+      ��6$   �� *Price+5,      �� 5-      $ 
Horizontal=�6!   .+�5.      �� $��год:��6$   �� 5/      ��6$   �� *Year+50      51      �� 53      -   5        $��50��53      $��25��6$   $��4q�60   $
��Left=�6;   $
��Show��6V   6e   55      56      57      58      