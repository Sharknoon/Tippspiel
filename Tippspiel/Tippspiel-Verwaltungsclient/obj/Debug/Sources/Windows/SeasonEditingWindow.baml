   M S B A M L   `   `   `  ����  Tippspiel-VerwaltungsclientE    ?Tippspiel_Verwaltungsclient.Sources.Windows.SeasonEditingWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Saison bearbeiten��5   	   $	��600��6#   $	��500��60   .��5      �  � ColumnDefinitions 5	   
   �� 5
      $��1* �6    � RowDefinitions 5   
   �� 5      $	��93* �6   �� 5      $��50 �6   .+�5   
   �� -   5        $��ButtonOk��5      $
��Left=�6!   $��1��6<   $��10,0,0,0q�6I   $��Center=�6[   $	��100��5      $��30��6   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $)��#../../Ressources/General/OkIcon.png��6   $��25��6E   �� 5      $��Center=�6   $��16(�67   Ok6I   5      5      �� 5   
   -   5        $��ButtonCancel��5      $
��Left=�6%   $��1��6@   $��	120,0,5,0q�6M   $��Center=�5      $	��120��6,   $��30��68   .��5      �� $ 
Horizontal=�6   .+�5      �� $-��'../../Ressources/General/CancelIcon.png��6   $��25��6I   �� 5      $��Center=�6   $��16(�67   	Abbrechen6P   5      5      � 5   
   $��0��6    5       �� 5!      $��1* �6#   �� 5"      $
��2.0* �6#    5$      �� 5%      $��60 �6    �� 5&      $��1* �6    �� 5'      $��60 �6    .+�5)      �� $��Center=�6   $��0��6/   $��0��6<   $��20(�6L   $
��Name��6Z   �� 5*      $��0��6   $��1��6#    �� TextWrapping$
 Wrap=�63   $��10,10,10,10q�6d   ��6G   �� *Season.Name+6d   �� 5+      $	��Top=�6   $��1��6,   $��0��69   $��20(�6I   $��Beschreibung��6W   �� 5,      $��1��6   $��1��6#   $
 Wrap=�63   $��10,10,10,10q�5-      ��5,   G   �� *Season.Description+5-      �� 5.      $��Center=�6   $��2��6/   $��0��6<   $��20(�6L   $��Reihenfolge��6Z   �� 5/      -   5        $��TextBoxSeasonSequence��5/      $��2��63   $��1��6@   $
 Wrap=�6P   $��10,10,10,10q�50   7   ��6   �� *Season.Sequence+51      52      53      54      