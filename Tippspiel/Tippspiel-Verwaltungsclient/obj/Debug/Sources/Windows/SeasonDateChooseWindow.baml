   M S B A M L   `   `   `  ����  Tippspiel-VerwaltungsclientH    BTippspiel_Verwaltungsclient.Sources.Windows.SeasonDateChooseWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$!  Datum der Saison auswählen��5   	   $	��200��6,   $	��500��69   .��5      �  � ColumnDefinitions 5	   
   �� 5
      $��1* �6    � RowDefinitions 5   
   �� 5      $	��93* �6   �� 5      $��50 �6   .+�5   
   � $��0��6    5      �� 5      $	��270 �6#   �� 5      $��1* �6#    5      �� 5      $��1* �6    .+�5      �� $%��Bitte Start der Saison
wählen��6   $��59��6E   $��20(�6Q   $��Center=�5      $
��Left=�6/   $��	10,0,0,10q�6J   (  "System.Windows.Controls.DatePicker  5      $��1��6   $��0��6)   $��10q�66   $��Center=�6B      SelectedDate 5      �� *Date+5       �� 5!   
   -   5        $��ButtonOk��5!      $
��Left=�6!   $��1��6<   $��10,0,0,0q�6I   $��Center=�6[   $	��100��5"      $��30��6   .��5#      ��  �� Orientation$ 
Horizontal=�6   .+�5$      �� $)��#../../Ressources/General/OkIcon.png��6   $��25��6E   �� 5%      $��Center=�6   $��16(�67   Ok6I   5&      5'      �� 5(   
   -   5        $��ButtonCancel��5(      $
��Left=�6%   $��1��6@   $��	120,0,5,0q�6M   $��Center=�5)      $	��120��6,   $��30��68   .��5*      �� $ 
Horizontal=�6   .+�5+      �� $-��'../../Ressources/General/CancelIcon.png��6   $��25��6I   �� 5,      $��Center=�6   $��16(�67   	Abbrechen6P   5-      5.      5/      50      