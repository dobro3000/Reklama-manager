   M S B A M L   `   `   `  ����M  IReklama monitoring, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Reklama_monitoringReklama_monitoring  5   	   '    !Reklama_monitoring.AddManagerData   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Reklama_monitoring     5   	     � Title$  Менеджер��5   	   $��514.473��6   $��292.105��6+    � WindowStartupLocation$ CenterScreen=�6;    � 
ResizeMode$ NoResize=�6`   .��5	      � .+�5
   
   �� -   5        $��tbFullNameManager��5
   "    �� 	MaxLength$	 100��6   $
��Left=�6;   $��23��6V   $��
153,18,0,0q�6b    �� TextWrapping$
 Wrap=�6v   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5   
   $
��Left=�6   $��	10,19,0,0q�6/   $
��Wrap=�6B   $��ФИО*��6V   $	��Top=�6b   �� 5   
   $
��Left=�6   $��	10,64,0,0q�6/   $
��Wrap=�6B   $)��#Дата начала работы*��6V   $	��Top=�6q   �� 5   
   $
��Left=�6   $��
10,110,0,0q�6/   $
��Wrap=�6C   $'��!Процент от продаж*��6W   $	��Top=�6q   �� 5   
   $
��Left=�6   $��
10,160,0,0q�6/   $
��Wrap=�6C   $"��Номер телефона*��6W   $	��Top=�6n   �� 5   
   $
��Left=�6   $��
10,209,0,0q�6/   $
��Wrap=�6C   $��Примечание��6W   $	��Top=�6i   �� 5   
   -   5        $��	tbPercent��5       $ 4��6   $
��Left=�61   $��23��6L   $��153,109,0,0q�6X   $
 Wrap=�6m   $�� ��6�   $	��Top=�6�   $	��120��6�   6�   �� 5   
   -   5        $��tbPhone��5   !   $ 11��6   $
��Left=�60   $��23��6K   $��153,153,0,0q�6W   $
 Wrap=�6l   $�� ��6�   $	��Top=�6�   $	��120��6�   6�   �� 5   
   -   5        $��tbNote��5   #   $
 1000��6   $
��Left=�61   $	��194��6L   $��
10,230,0,0q�6Y   $
 Wrap=�6m   $�� ��6�   $	��Top=�6�   $	��263��6�   �� 5   
   -   5        $��Сохранить��5      $
��Left=�6%   $��
10,448,0,0q�6@   $	��Top=�6T   $	��105��6l   $��25��6x   6�   �� 5   
   -   5        $��Отмена��5      $
��Left=�6"   $��169,448,0,0q�6=   $	��Top=�6R   $	��105��6k   $��25��6w   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpDate��5      $
��Left=�6#   $��
153,60,0,0q�6>   $	��Top=�6R   $	��121��6j   5      5      