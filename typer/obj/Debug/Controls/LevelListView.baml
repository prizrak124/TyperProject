   M S B A M L   `   `   `  ����@  <Typer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TyperTyper  5      clr-namespace:TyperTyper  5      "    Typer.Controls.LevelListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:Typer     5      $rootclr-namespace:Typer     5      $��28(�5	   7     � 	Resources  5
         Typer.FileNameConverter   NameConverter��%   &	          5   
   6!   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   ��5   
   �� 5       �� Color$ White��6    �� Opacity$	 0.6Q�6,   .+�5   
   �� $��0,40,0,0q�6    �� Orientation$ 
Horizontal=�6'   $��Center=�5      $��Center=�62   .+�5      �� $��/Resources/logo.png��6   $	��140��61   �� 5      $��Center=�6   $��
PRIZRAK124��6/   6F   5      �� 5   
   -   5         ��Name$ ListViewLevel��5$      $��0q�5       %� IsVirtualizing .  $��Disabled=�5       $��Center=�5!      $��Center=�5"      $��1��5#       %� 
ScrollUnit$ Pixel=�5%      
������ ��5'      �� 5(      .R�5)      ��  ��Name$ ButtonLevel��6   -   5        ��5*      �� 5+      $
��Left=�6(   	 �� TextAlignment$	 Center=�5,   (   $
��Wrap=�6@   ��5-   (   �� *Name+
 �� 	Converter#
 [  5/      50      ��54      �� 55       �� 
TargetType" ��6   .�57      ��  �� Property � �� �� Value$ Stretch=�6C   �� 58       � �� 59      �� 5:       �� 
TargetType" ��6.   .R�5<   "   ��  ��Name$ Bg��6)   #��z��65   #��z��5=   )    �� Padding# z��5>   )    J� SnapsToDevicePixels . ._�5@   &   �� #��z��67   # z 5A   7   #��z��5B   7   5C   #    �� Triggers 5E   "   P� 5G   &    P� Property �@J�IsMouseOver P� Value . . �5H   *   ��  �� 
TargetName$ Bg��6G    � ��
 ���� 6W   5I   '   P� 5J   &    �@��
IsSelected . . �5K   *   �� $ Bg��6G    � ��
 ���� 6W   5L   '   5O      5Q      5S      5U      �� 5V   
   -   5        $ 
ButtonBack��5V   =   $��2��6   $��Center=�6   $��
Назад��6Q   6a   5W      5X      