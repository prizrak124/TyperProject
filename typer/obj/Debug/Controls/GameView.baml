   M S B A M L   `   `   `  ����@  <Typer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TyperTyper  5          Typer.Controls.GameView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:Typer     5      U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5      $��28(�5	   7   .��5
      � ��5   
   �� 5        �� Color$  White��6    �� Opacity$	 0.6Q�6,    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��1��6   $��0��6%   $��	0,20,20,0q�62    �� Orientation$ 
Horizontal=�6E   $��Center=�5      .+�5      �� $��Uniform=�6   $��/Resources/logo.png��6'   $	��120��6D   �� 5      $��Center=�6   $��
PRIZRAK124��6/   6F   5      �� 5    
   $��0��6   $��
20,20,20,0q�6   ���#C4C4C4 �� CornerRadius$ 5��6G   ._�5!      �� $ 
Horizontal=�6   .+�5"      �� -   5         ��Name$ EaterImg��5#      "  WpfAnimatedGif.ImageBehavior   AnimatedSource$ /Resources/Eater.gif��5$         	AutoStart . $��0,0,0,20q�5'      $��60��6'   5)      �� 5*      -   5        	 ��Name$	 TextBlockCurrentLine��5-      $
��Left=�5*      $��Center=�5+      $��CharacterEllipsis=�5,      5-      5.      5/      �� 50   
   -   5        
 ��Name$
 TextBoxInputLine��50   ;   $��1��6   $��20,50q�6    $��4q�6/   .��6U   ��51      �� 52       �� 
TargetType" ��6   .�53      ��  �� Property � �� �� Value
 �   �64   �� 54       � ��$ 2q�68    �� 	Resources 55      ��%�   '��       �� 56      " ��6    .�57      ��  �@��CornerRadius$ 10��6=   �� 58       � �� 59   "   �� 5:   &   $  	#FFE6E2E2��66   $ 1Q�6H   5<      5=      5>      5?      .��5@      5A      �� 5C   
   $��
20,0,20,50q�6   $��1q�6%   $��2��69   
���   �$ 20��5D      ���#E3E3E3._�5E      �� $
��Auto=�6   $��Disabled=�6>   .��5F      �� -   5        $	 TextBlockAllText��5F      $��WrapWithOverflow=�66    �� TextAlignment$ Center=�6V   5G      5H      �� 5J   
   $��1��6   $��2��6"   $��Center=�63   $��1��6N   .+�5K      �� -   5        $	 TextBlockTopTime��5K      $��Center=�62   $ Center=�6O   �� 5L      -   5        $	 TextBlockTime��5L      $��Center=�6/   $ Center=�6L   �� 5M      -   5         ��Name$ ButtonPauseResume��5M      $��
Пауза��60   6@   �� 5N      -   5        $ ButtonSettings��5N      $��Настройки��6-   6A   �� 5O      -	   5        $ 
ButtonHelp��5O      $��Помощь��6B   �� 5P      -
   5        $ 
ButtonExit��5P      $��1��6)   $��1��69   $��
Выход��6F   6V   5Q      � 5R   
   -   5         �Name$ WinPanel��5R      
�������$��3��64   $��2��6E    5S      �� 5T      $
��Auto �6    �� 5U      .+�5W      �� $
��0,20q�6   .+�5X      �� $��Center=�6   $��Ввод окончен!��69   �� 5Y      -   5        $	 TextBlockWinTime��5Y   9   $��Center=�6   69   �� 5Z      -   5        $ ButtonResumeGame��5Z      $��Повторить��63   6G   �� 5[      -   5        $��
Выйти��5[   2   5\      �� 5^      $��
20,0,20,50q�6   $��1q�6)   $��2��6=   
���   �$ 20��5_      ���#E3E3E3._�5`      �� $
��Auto=�6   $��Disabled=�6B   .��5a      �� -   5        $	 TextBlockWinAllText��5b   !   $��WrapWithOverflow=�5c   !   $ Center=�5d   !   5e      5f      5h      5i      5j      