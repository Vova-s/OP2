   M S B A M L   `   `   `  ����R  NMedicalInfomationSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MedicalInfomationSystemMedicalInfomationSystem  5   	   (    "MedicalInfomationSystem.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:MedicalInfomationSystem     5   	     � Title$  
MainWindow��5   	   $	��900��6   $
��1280��6)    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � 	Resources 5         MyWaterMarkStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name	 ��Name

 � Tag �� Triggers ]� 
Conditions �� Property �� Value �� 
TargetName P� Property P� Value��%�  &	        �� 5   
   " ��6)   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� 
����������	#FF7D8683$��1q�6P   �� 5      $ PART_ContentHost��6+   $��5,0,0,0q�6E   $��Center=�6V   �� 5      $	 WaterMarkLabel��65   $��5,0,0,0q�6$   #��z
 6M   $��Center=�6m   $y�	Collapsed=�5       
�������$��Arial)�6I   5       5      ]� 5       5   "   �� 5   &    � ��$  ��6@   ./�5   "   �� $ WaterMarkLabel��6?    � y�$ Visible=�6[   5      P� 5       � {� .  . �5   "   ��  � ��
 �iii�6?   5      5!      5#      5$      5%      .��5&      � ���	#FF5880E2 � RowDefinitions 5'   
   �� 5(      $��60 �6   �� 5)       � ColumnDefinitions 5,   
   �� 5-      �� 5.      .+�52   
   � 
����iA�$��2��53       54      �� 55      $
��128* �6#   �� 56      $
��167* �6#   �� 57      $	��89* �6#   �� 58      $
��128* �6#   �� 59      $
��128* �6#   �� 5:      $
��128* �6#   �� 5;      $
��128* �6#   �� 5<      $
��128* �6#   �� 5=      $
��128* �6#   �� 5>      $
��128* �6#   .+�5@      �� $��1��5A      $��UMCIS��5B      $��Fonts/#Papernotes Bold)�5C      $��35(�5D      $
��Bold"�5E      $	��Top=�5F      $
��Left=�5G      $��	27,10,0,0q�6,   $��52��6?   $	��110��6K   A� 5I      -   5         A�Name$
 Logo��5I      $��Center=�5J      $	��120��5K      $��	0,0,0,-60q�5L       J� RenderTransformOrigin$ -1.55,-4&�5M      ��5N      �� 5O       �� ImageSource$� ~C:\Users\VOVAN\source\repos\Medical cooperative information system\Medical cooperative information system\Images\Logo\logo.png��6!   5Q      �� 5R      -   5        $��9��5R      $��	53,0,10,0q�6&   ��5S      �� 5T      " ��6&   .R�5U      � .+�5V      A� ��5W   "   �� 5X   &   $� �C:\Users\VOVAN\source\repos\Medical cooperative information system\Medical cooperative information system\Images\Icons\icons8-cancel-80.png��61   5Z      �� 5[      #��z��6/   $��Center=�6S   $��Center=�6p   5\      5]      5_      5`      �� 5b   
   $��2��6   $
��Left=�5c      $	��578��5d      $��	293,0,0,0q�5e      $��1��5f      $��Center=�5g      $	��694��5h      ���	#FF5E67AD5i      �� 5j   
   -   5         ��Name$ NameBox��5j      #��[  5k      $��374,344,592,0q�5l      $��1��5m      $��2��6   $
 	user name��5n      
���iii�$��20(�5p      $��Times New Roman)�5q      $	��Top=�5r      $��46��5s      #��� ��6   �� 5t   
   -   5        $ PasswordBox��5t      #��[  5u      $��374,438,592,0q�5v      $��1��5w      $��2��6   $
 password��5x      
���iii�$��20(�5z      $��Times New Roman)�5{      $	��Top=�5|      $��46��5}      #��� ��6   �� 5~   
   -   5        $��1��5      $��Login��5�      $��30(�5�      
�������$
��Bold"�5�      $��Fonts/Garet-Book)�5�      ���	#FF5F6271$
��Left=�5�      $��	104,0,0,0q�5�      $��1��5�      $��Center=�5�      $	��578��5�      $	��243��5�      6   �� 5�   
   $
��Left=�6   $��Authorization��5�      
�������$��40(�5�      $��Heavy"�5�      $1��+Fonts/#BackToSchoolPersonalUseRegular-w1xX2)�5�      $��88��5�      $��404,191,0,0q�5�      $��1��5�      $
��Wrap=�5�      $	��Top=�5�      $	��284��5�      $��2��6    5�      5�      