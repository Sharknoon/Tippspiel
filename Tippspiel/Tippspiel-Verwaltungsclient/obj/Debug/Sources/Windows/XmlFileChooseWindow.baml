   M S B A M L   `   `   `  ����  Tippspiel-VerwaltungsclientE    ?Tippspiel_Verwaltungsclient.Sources.Windows.XmlFileChooseWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  XML-Datei auswählen��5   	   $��215.625��6%   $	��500��66   .��5      �  � ColumnDefinitions 5	   
   �� 5
      $��1* �6    � RowDefinitions 5   
   �� 5      $	��93* �6   �� 5      $��50 �6   .+�5   
   � $��0��6    5      �� 5      $	��270 �6#   �� 5      $��1* �6#    5      �� 5      $��2* �6    �� 5      $��1* �6    .+�5      �� $ ��Bitte XML-Datei auswählen��6   $��35��68   $��20(�6D   $��Bottom=�6R   $
��Left=�5      $��10q�6/   �� 5      -   5        $��ButtonChoose��5   .   $��0��6   $��10q�6"   $��1��6B   $��Bottom=�6R   $
��Left=�5      $��Durchsuchen��60   $��20(�6F   6T   �� 5       $��0��6   $��1��6$   $��2��61   $��40��6E   $	��470��6Q   $��20(�5!      $��Center=�6"   $
��Left=�6=   $��10q�6X   ��5    ]   �� *Text+5!   X   5#      �� 5$   
   -   5        $��ButtonOk��5$      $
��Left=�6!   $��1��6<   $��10,0,0,0q�6I   $��Center=�6[   $	��100��5%      $��30��6   .��5&      ��  �� Orientation$ 
Horizontal=�6   .+�5'      �� $)��#../../Ressources/General/OkIcon.png��6   $��25��6E   �� 5(      $��Center=�6   $��16(�67   Ok6I   5)      5*      �� 5+   
   -   5        $��ButtonCancel��5+      $
��Left=�6%   $��1��6@   $��	120,0,5,0q�6M   $��Center=�5,      $	��120��6,   $��30��68   .��5-      �� $ 
Horizontal=�6   .+�5.      �� $-��'../../Ressources/General/CancelIcon.png��6   $��25��6I   �� 5/      $��Center=�6   $��16(�67   	Abbrechen6P   50      51      52      53      