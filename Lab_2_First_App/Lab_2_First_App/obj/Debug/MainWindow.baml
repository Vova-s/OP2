   M S B A M L   `   `   `  ����J  FLab_2_First_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Lab_2_First_AppLab_2_First_App  5   	        Lab_2_First_App.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Lab_2_First_App     5   	   -   5          �Name$  MainWin��5   	    � Title$R LПошук найкоротшого шляху. Симчич, КП-13, 2022.��5   	   $	��450��6@   $	��800��6M    � 
ResizeMode$ NoResize=�6Y   $��Georgia)�6o   $��16(�6�   .��5	      � -   5         �Name$ MyGrid��5	       � ShowGridLines .  � ColumnDefinitions 5
   
   �� 5      $
��101* �6   �� 5      $	��40* �6   .+�5   
   �� -   5         ��Name$ MyCanvas��5   .   $��0��6   $��0��6   $
��Left=�6@   $��	10,10,0,0q�6[   $	��Top=�6n   $��0��6�   $��0��6�   � 5   
   $��0��6   $��2��6    � RowDefinitions 5      �� 5      $	��40* �6    6/   �� 5      $	��40* �6    6/   �� 5      $	��40* �6    6/   �� 5      $	��40* �6    6/   �� 5      $	��40* �6    6/   �� 5      $	��40* �6    6/   �� 5      $	��40* �6    6/   �� 5      $	��40* �6    6/   .+�5      �� $'��!Кількість пунктів��6   $��0��60   $��1q�6=   
���   �$��Book Antiqua)�6e   $��16(�6   �� 5      -   5         ��Name$ 	NumElemCB��5      	 �� SelectedIndex$	 0��6*   $��Book Antiqua)�6j   $��16(�6�   $��	0,54,0,54q�6�   $��3��6�   .@�5      �� $��5��6   �� 5       $��10��6   �� 5!      $��20��6   �� 5"      $��50��6   �� 5#      $	��100��6   �� 5$      $	��200��6   �� 5%      $	��500��6   5&      �� 5'      $!��Швидкість, у мс��6   $��2��6.   $��1q�6;   
���   �$��Book Antiqua)�6c   $��16(�6}   $��0,0,0,54q�6�   $��2��6�   6�   �� 5(      -   5        $ VelCB��5(      $��3��6&   $	 0��63   $��Book Antiqua)�6o   $��16(�6�   .@�5)      �� $
��1000��6   �� 5*      $	��500��6   �� 5+      $	��200��6   �� 5,      $	��100��6   �� 5-      $��50��6   �� 5.      $��10��6   �� 5/      $��5��6   �� 50      $��1��6   51      �� 52      -   5        
 ��Name$
 	StopStart��52      $+��%Запустити / Зупинити��6(   $��7��6G   $��Book Antiqua)�6l   $��16(�6�   $��-227,12,227,0q�6�   �� 53      $+��%Ймовірність мутації��6   $��6��62   $��1q�6?   
���   �$��Book Antiqua)�6g   $��16(�6�   $��0,0,0,54q�6�   $��2��6�   �� 54      $/��)Розмірність популяції��6   $��3��64   $��1q�6A   
���   �$��Book Antiqua)�6i   $��16(�6�   $��0,54,0,0q�6�   $��2��6�   �� 55      -   5         ��Name$	 TB1��55       �� TextWrapping$
 Wrap=�6#   $��	0,42,0,51q�68   $��3��6K   $��4��6\   �� 56      -   5        $	 tb2��56      $
 Wrap=�6#   $��7��67   �� 57      -	   5        $
 
Greedy_alg��57      $��Greedy��6)   $��7��6:   $��Book Antiqua)�6H   $��16(�6b   $��-398,12,454,0q�6p   6�   �� 58      -
   5        $
 Genetic_alg��58      $��Genetic��6*   $��7��6<   $��Book Antiqua)�6J   $��16(�6d   $��-573,12,625,0q�6r   6�   59      5;      5<      