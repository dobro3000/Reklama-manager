   M S B A M L   `   `   `  ����M  IReklama monitoring, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Reklama_monitoringReklama_monitoring  5   	   '    !Reklama_monitoring.AccountConnect   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Reklama_monitoring     5   	     � Title$/  )Переключение аккаунта��5   	   $��189.448��6'   $��320.338��68    � WindowStartupLocation$ CenterScreen=�6H    � 
ResizeMode$ NoResize=�6m   .��5	      �  � RowDefinitions 5
   
   �� 5      $��6* �6   �� 5      $
��105* �6   �� 5      $	��47* �6   .+�5   
   �� $
��Left=�6   $��	31,13,0,0q�6/   $
��Wrap=�6B   $��
Логин��6V   $	��Top=�6c   $��1��6{   $��16��6�   $��34��6�   �� 5   
   $
��Left=�6   $��	31,66,0,0q�6/   $
��Wrap=�6B   $��Пароль��6V   $	��Top=�6d   $��1��6|   $��16��6�   $��47��6�   �� 5   
   -   5        $��tbLogin��5      $
��Left=�6!   $��23��6<   $��
169,13,0,0q�6H    �� TextWrapping$
 Wrap=�6\   $�� ��6p   $	��Top=�6x   $	��120��6�   $��1��6�   G� 5   
   -   5        $��
tbPassword��5      $
��Left=�6(   $��23��6C   $��
169,66,0,0q�6O   $	��Top=�6c   $	��120��6{   $��1��6�   �� 5   
   -   5        $��btnSave��5      $��Сохранить��6    $
��Left=�64   $��	31,16,0,0q�6O   $	��Top=�6b   $	��105��6z   $��2��6�   $��20��6�   �� 5   
   -   5        $��	btnCancel��5      $��Отмена��6"   $
��Left=�63   $��
184,16,0,0q�6N   $	��Top=�6b   $	��105��6z   $��2��6�   $��20��6�   5      5      