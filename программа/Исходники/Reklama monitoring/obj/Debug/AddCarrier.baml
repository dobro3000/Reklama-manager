   M S B A M L   `   `   `  ����M  IReklama monitoring, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Reklama_monitoringReklama_monitoring  5   	   #    Reklama_monitoring.AddCarrier   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Reklama_monitoring     5   	     � Title$  Носитель��5   	   $��221.453��6   $��278.943��6+    � WindowStartupLocation$ CenterScreen=�6;    � 
ResizeMode$ NoResize=�6`   .��5	      � $��0,0,2,10q�6    � ColumnDefinitions 5
   
   �� 5      $	��14* �6   �� 5      $
��125* �6   �� 5      $
��132* �6    � RowDefinitions 5   
   �� 5      $	��68* �6   �� 5      $	��23* �6   .+�5   
   �� $
��Left=�6   $��4,32,0,0q�6/   $
��Wrap=�6A   $��Название��6U   $	��Top=�6e   $��22��6}   $��68��6�   $��1��6�   �� 5   
   -   5        $��tbNameCarrier��5   "    �� 	MaxLength$	 100��6   $
��Left=�67   $��23��6R   $��2,31,0,0q�6^    �� TextWrapping$
 Wrap=�6p   $�� ��6�   $	��Top=�6�   $	��120��6�   $��2��6�   �� 5   
   -   5        $��Сохранить��5      $
��Left=�6%   $��0,10,0,0q�6@   $	��Top=�6R   $��25��6j   $	��105��6v   $��1��6�   $��1��6�   �� 5   
   -   5        $��Отмена��5      $
��Left=�6"   $��	17,10,0,0q�6=   $	��Top=�6P   $��25��6h   $	��105��6t   $��1��6�   $��2��6�   �� 5   
   $
��Left=�6   $��4,93,0,0q�6/   $
��Wrap=�6A   $#��Срок размещения��6U   $	��Top=�6l   $��1��6�   $��16��6�   $	��107��6�   �� 5   
   -   5        $��	cbDataSet��5      $
��Left=�6$   $��2,87,0,0q�6?   $	��Top=�6Q   $	��120��6i   $��2��6u   $��22��6�   5      5      