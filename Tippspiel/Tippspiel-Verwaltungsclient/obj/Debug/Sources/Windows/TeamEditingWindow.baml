   M S B A M L   `   `   `  ����V  RTippspiel-Verwaltungsclient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:Tippspiel_Verwaltungsclient.Sources.Windows+Tippspiel_Verwaltungsclient.Sources.Windows  5   	   C    =Tippspiel_Verwaltungsclient.Sources.Windows.TeamEditingWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Mwindows9clr-namespace:Tippspiel_Verwaltungsclient.Sources.Windows     5   	     � Title$  Mannschaft bearbeiten��5	   	   $	��600��6'   $	��500��64   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $	��93* �6   �� 5      $��50 �6   .+�5   
   �� -   5        $��ButtonOk��5      $
��Left=�6!   $��1��6<   $��10,0,0,0q�6I   $��Center=�6[   $	��100��5      $��30��6   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $)��#../../Ressources/General/OkIcon.png��6   $��25��6E   �� 5      $��Center=�6   $��16(�67   Ok6I   5      5      �� 5   
   -   5        $��ButtonCancel��5      $
��Left=�6%   $��1��6@   $��	120,0,5,0q�6M   $��Center=�5      $	��120��6,   $��30��68   .��5      �� $ 
Horizontal=�6   .+�5      �� $-��'../../Ressources/General/CancelIcon.png��6   $��25��6I   �� 5      $��Center=�6   $��16(�67   	Abbrechen6P   5      5      � 5!   
   $��0��6    5"      �� 5#      $��1* �6#   �� 5$      $
��2.0* �6#    5&      �� 5'      $��60 �6    �� 5(      $��1* �6    �� 5)      $��60 �6    .+�5+      �� $��Center=�6   $��0��6/   $��0��6<   $��20(�6L   $
��Name��6Z   �� 5,      $��0��6   $��1��6#    �� TextWrapping$
 Wrap=�63   $��
10,10,10,5q�6b   $��15(�5-      ��5,   G   �� *	Team.Name+5-      �� 5.      $	��Top=�6   $��1��6,   $��0��69   $��20(�6I   $��Saisons��6W   �� 5/      $��Stretch=�6   $
��auto��64   $��Stretch=�6B   $��1��6g   $��1��50      $��	10,5,10,5q�6#   ��66   �� *SeasonsOfTeam+��51      �� 52      .R�53      �  54      �� 55   "   $��1* �63   �� 56   "   $��60 �63    58      �� 59   "   $��60 �60   .+�5;      �� $��Center=�6$   $
��Left=�6?   $��0��6Z   $��20(�6g   ��5<   $   ��  �� Path$
 Name��� 5=      $��ButtonDelete��6\   -   5        $��Right=�5=   %   $��Center=�6A   $��1��5>   %   $��40��65   $��40��6@   $��0,0,10,0q�5?   B   .��5@   "   �� $/��)../../Ressources/General/TrashCanIcon.png��6(   5A      5B      5C      5E      �� 5F      -   5        $��ButtonAddSeasonToTeam��5F      $��1��62   $
��Left=�6B   $��	10,0,0,20q�6]   $��2��5G      $��Center=�6"   $	��175��6=   $��30��6I   .��5I      �� $ 
Horizontal=�6   .+�5J      �� $+��%../../Ressources/General/PlusIcon.png��6   $��25��6K   �� 5K      $��Center=�6    $��16(�6;   Saison hinzufügen6\   5L      5M      5O      5P      5Q      