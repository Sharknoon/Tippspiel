   M S B A M L   `   `   `  ����V  RTippspiel-Verwaltungsclient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:Tippspiel_Verwaltungsclient.Sources.Windows+Tippspiel_Verwaltungsclient.Sources.Windows  5   	   R    LTippspiel_Verwaltungsclient.Sources.Windows.TeamEditingSeasonSelectionWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Mwindows9clr-namespace:Tippspiel_Verwaltungsclient.Sources.Windows     5   	     � Title$  Saisons auswählen��5	   	   $	��300��6#   $	��300��60   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $	��93* �6   �� 5      $��50 �6   .+�5   
   �� $��
10,10,10,0q�6   ��6&   �� *	ListItems+��5      �� 5      .R�5      �  5      �� 5      $��1* �6/   .+�5      �� $��15(�6A   ��6#   ��  �� Path$
 Text� d� 	IsChecked 6O   �� $ 	IsChecked�5      5      5      �� 5   
   -   5        $��ButtonOk��5      $
��Left=�6!   $��1��6<   $��10,0,0,0q�6I   $��Center=�6[   $	��100��5      $��30��6   .��5       ��  �� Orientation$ 
Horizontal=�6   .+�5!      �� $)��#../../Ressources/General/OkIcon.png��6   $��25��6E   �� 5"      $��Center=�6   $��16(�67   Ok6I   5#      5$      �� 5%   
   -   5        $��ButtonCancel��5%      $
��Left=�6%   $��1��6@   $��	120,0,5,0q�6M   $��Center=�5&      $	��120��6,   $��30��68   .��5'      �� $ 
Horizontal=�6   .+�5(      �� $-��'../../Ressources/General/CancelIcon.png��6   $��25��6I   �� 5)      $��Center=�6   $��16(�67   	Abbrechen6P   5*      5+      5-      5.      