   M S B A M L   `   `   `  ����K  Gпрактика, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:практикапрактика  5   	   !    практика.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:практика     5   	   -   5          � Title$.  (авторизация в системе��5   	   $	��600��6'   $
��1000��64   .��5
      � 
�������.+�5   
   �� $	��100��5      �� 5   
   $	��800��5      $	��189��5      $��50,103,50,192q�6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�5      .+�5      �� $��60��5      $��60��5      $:��4C:\Users\student\Desktop\практика\cel\bb.png��5      �� 5      -   5        $��Login��5      $��
0,20,20,20q�5      $	��300��5      $��50��5      $��30(�5      $
��Left=�5      �� 5"       J� IsHitTestVisible$ False��5#      $��Login��5$      $��Center=�5%      $
��Left=�5&      $��
-310,0,0,0q�5'      $��30(�5(      
���������5*      �� 5+       �� 
TargetType" ��6    .�5,      ��  �� Property � y� �� Value$ 	Collapsed=�6<    �� Triggers 5-      �� 5.   "    �� Binding 5/   %   �� *Text+ �� ElementName$ Login��	 �� Value	  50   %   .a�51   &   ��  � y�$ Visible=�53   )   54   #   56      58      59      �� 5=      $ 
Horizontal=�6   $��Center=�5>      .+�5?      �� $��45,0,2,0q�5@      $��50��5A      $��50��5B      $:��4C:\Users\student\Desktop\практика\cel\gg.png��5C      G� 5D      -   5        $��Password_Box��5E      $��
3,20,10,20q�5F      $	��300��5G      $��50��5H      $��30(�5I      �� 5L      $ False��5M      $��Password��5N      $��Center=�5O      $
��Left=�5P      $��
-300,0,0,0q�5Q      $��30(�5R      
���������5T      �� 5U      " ��6    .�5V      ��  � y�$ 	Collapsed=�6<    5W      �� 5X   "    5Y   %   �� *Text+$ Login��	  5Z   %   .a�5[   &   ��  � y�$ Visible=�5]   )   5^   #   5`      5b      �� 5d      -   5        $��PasswordActeveBox��5k      $y�	Collapsed=�5e      $��30(�5f      $��50��5g      $	��300��5h      $��Center=�5i      $��Center=�5j      5k      �� 5n      -   5        
 ��Name$
 EyeBtn��5o      
�������$��0q�5q      .��5s      �� $��50��5t      $��50��5u      $:��4C:\Users\student\Desktop\практика\cel\rr.png��5v      5w      5x      5y      �� 5z   
   -   5         ��Name$ Error��5{      $��30��5|      $��20(�5}      $��277,292,-277,162q�6   
���  ��$��Black"�5      �� 5�   
   -   5        $
 ToRegBtn��5�      $	��Top=�5�      $��30��5�      $O��IНе зарегистрированы? Зарегистрируйтесь��5�      $��Black"�5�      $��15(�5�      
�������$��0q�5�      $��	0,409,0,0q�5�       J� RenderTransformOrigin$ 0.505,2.165&�6    �� 5�   
   -   5        $
 AuthBtn��5�      $	��150��5�      $��50��5�      
������$��
Войти��5�      $��20(�5�      $��Black"�5�      $��425,470,425,64q�5�      5�      5�      5�      