   M S B A M L   `   `   `  ����V  RTippspiel-Verwaltungsclient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:Tippspiel_Verwaltungsclient.Sources.Windows+Tippspiel_Verwaltungsclient.Sources.Windows  5   	   ?    9Tippspiel_Verwaltungsclient.Sources.Windows.MatchesWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Mwindows9clr-namespace:Tippspiel_Verwaltungsclient.Sources.Windows     5   	     � Title$  Spiele��5	   	   $	��700��6   $	��700��6%   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��55 �6   �� 5      $��45 �6   �� 5      $	��93* �6   �� 5      $��50 �6   .+�5   
   �� $��Saison��6   $��20(�6!   $��Center=�6/   $
��Left=�6J   $��10q�6e   $��40��5      �� 5   
   -   5        $��ComboBoxSeasons��5   7   $��115,10,10,10q�6   $��20(�6)   $��0��6N   ��5      �� *	Seasons+ �� SelectedValue 63   �� *CurrentSeason+��5      �� 5      .R�5      �� ��6    �� *Name+5      5      �� 5    
   $��20(�6   $��40��6   $��Center=�6*   $
��Left=�6E   $��10q�6`   $��1��6l   .��5!      �� �� 5"      
Spieltag6'    �� 5#      ��6   ��  �� ElementName$ Slider�� �� Path$ Value�5$      5%      �� 5&   
   -   5        $��Slider��5&      $��Stretch=�6   $��115,10,10,10q�6=   $��Center=�6S   $��1��5'       � Minimum$ 1Q�5(       � Maximum$ 34Q�6    �� IsSnapToTickEnabled . 	 �� TickFrequency$	 1Q�6g   
 � Value
 6*   �� *CurrentMatchDay+5*      �� 5,   
   $��Stretch=�6   $��2��67   $��	10,0,10,0q�6D   ��6W   �� *	ListItems+��5-      �� 5.      .R�5/      �  50      �� 51      $��1* �6/   �� 52      $��60 �6/   �� 53      $��60 �6/    55      �� 56      $	��100 �6,   .+�58      �  59      �� 5:   "   $��1* �63    5<      �� 5=   "   $��2* �60   �� 5>   "   $
��1.5* �60   �� 5?   "   $
��1.5* �60   .+�5A      �� $��Center=�6$   $��0��6?   $��20(�6L   ��5B   $   �� $ 	AagainstB��� 5C      $��Center=�6$   $��1��6?   $��15(�6L   ��5D   $   �� $ DateTime��� 5E      $��Center=�6$   $��2��6?   $��15(�6L   ��5F   $   �� $ Season�5G      �� 5H      $��ButtonDelete��6!   -   5        $��1��5H   5   $��40��6E   $��40��6P   .��5I      �� $/��)../../Ressources/General/TrashCanIcon.png��6$   5J      �� 5K      $��
ButtonEdit��6!   -   5        $��2��5K   3   $��40��6C   $��40��6N   .��5L      �� $-��'../../Ressources/General/PencilIcon.png��6$   5M      5N      5O      5Q      �� 5S   
   -   5        $��	ButtonAdd��5S      $��Right=�6"   $��3��6>   $��0,0,10,0q�6K   $��Center=�5T      $	��120��6,   $��30��68   .��5U      ��  �� Orientation$ 
Horizontal=�6   .+�5V      �� $+��%../../Ressources/General/PlusIcon.png��6   $��25��6G   �� 5W      $��Center=�6   $��16(�67   Hinzufügen6Q   5X      5Y      �� 5Z   
   -   5        $��ButtonImport��5Z      $��Right=�6%   $��3��6A   $��	0,0,140,0q�6N   $��Center=�5[      $	��120��6,   $��30��68   .��5\      �� $ 
Horizontal=�6   .+�5]      �� $-��'../../Ressources/General/ImportIcon.png��6   $��25��6I   $��25��6U   �� 5^      $��Center=�6   $��16(�67   Importieren6R   5_      5`      �� 5a   
   -   5        $��ButtonGenerate��5a      $��Right=�6'   $��3��6C   $��	0,0,270,0q�6P   $��Center=�5b      $	��120��5c      $��30��6   .��5d      �� $ 
Horizontal=�6   .+�5e      �� $/��)../../Ressources/General/GenerateIcon.png��6   $��25��6K   $��25��6W   �� 5f      $��Center=�6   $��16(�67   
Generieren6Q   5g      5h      5i      5j      