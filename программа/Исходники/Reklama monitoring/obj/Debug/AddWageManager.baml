   M S B A M L   `   `   `  ����M  IReklama monitoring, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Reklama_monitoringReklama_monitoring  5   	   '    !Reklama_monitoring.AddWageManager   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Reklama_monitoring     5   	     � Title$   З/п менеджеров��5      $��356.579��6"   $��282.895��63    � WindowStartupLocation$ CenterScreen=�6C    � 
ResizeMode$ NoResize=�6i   .��5	      � .+�5
   
   �� $
��Left=�6   $��	10,27,0,0q�6/   $
��Wrap=�6B   $��Менеджер*��6V   $	��Top=�6g   $��22��6   $��79��6�   �� 5   
   -   5        $��	cbManager��5   f   $
��Left=�6   $��
143,27,0,0q�6.   $	��Top=�6B   $	��120��6Z    �� DisplayMemberPath$ FullName��6�   ��6w   �� 6�   �� 5   
   -   5        $��tbSumOrders��5      $
��Left=�6%   $��23��6@   $��
143,77,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��120��6�   �� 5   
   $
��Left=�6   $��	10,77,0,0q�6/   $
��Wrap=�6B   $��Число заказов��6V   $	��Top=�6k   �� 5   
   -   5        $��tbCurrentSum��5      $
��Left=�6&   $��23��6A   $��143,129,0,0q�6M   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��120��6�   �� 5   
   -   5        $��tbPaid��5   .   $
��Left=�6<   $��23��6W   $��143,178,0,0q�6c   $
 Wrap=�6x   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5   
   $
��Left=�6   $��
10,129,0,0q�6/   $
��Wrap=�6C   $)��#Заработанная сумма��6W   $	��Top=�6q   �� 5   
   -   5        $��tbRest��5      $
��Left=�6    $��23��6;   $��143,222,0,0q�6G   $
 Wrap=�6\   $�� ��6p   $	��Top=�6x   $	��120��6�   �� 5   
   $
��Left=�6   $��
10,178,0,0q�6/   $
��Wrap=�6C   $��Выплачено*��6W   $	��Top=�6i   �� 5   
   $
��Left=�6   $��
10,223,0,0q�6/   $
��Wrap=�6C   $��Долг��6W   $	��Top=�6c   �� 5   
   -   5        $��Сохранить��5      $
��Left=�6%   $��
10,283,0,0q�6@   $	��Top=�6T   $	��105��6l   $��25��6x   6�   �� 5   
   -   5        $��Отмена��5      $
��Left=�6"   $��158,283,0,0q�6=   $	��Top=�6R   $	��105��6j   $��25��6v   6�   5      5      