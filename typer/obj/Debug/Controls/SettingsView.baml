   M S B A M L   `   `   `  ����@  <Typer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Typer.ControlsTyper.Controls  5      clr-namespace:TyperTyper  5      !    Typer.Controls.SettingsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Typer.Controls     5      $rootclr-namespace:Typer     5      $��28(�5	   7     � 	Resources  5
         Typer.FileNameConverter   NameConverter��%   &	          5   
   6!   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   ��5   
   �� 5       �� Color$ White��6    �� Opacity$	 0.6Q�6,   .+�5   
   �� $��0,40,0,0q�6    �� Orientation$ 
Horizontal=�6'   $��Center=�5      $��Center=�62   .+�5      �� $��/Resources/logo.png��6   $	��140��61   �� 5      $��Center=�6   $��
PRIZRAK124��6/   5      �� 5    
   $��100,20q�6   $��1��6&   .+�5"      �� -   5         ��Name$ LabelVolume��5"      $��Громкость��6)   �� 5#      -   5         ��Name$ SliderVolume��5#       � Minimum$ 0Q�5$       � Maximum$ 1Q�6!   	 � SmallChange$		 0.1Q�6-   
 � LargeChange$	
 0.1Q�6?   5(      �� 5*      -   5        $��0,50,0,0q�5+      $��Center=�5,      $%��Выключить музыку��5-      5.      5/      �� 51   
   -   5         ��Name$ ListViewAudios��56   .   $��2��51      $��0q�52       %� IsVirtualizing .  $��Disabled=�54      $��Center=�55      $��Center=�56       %� 
ScrollUnit$ Pixel=�6F   
������ ��59      �� 5:       �� 
TargetType" ��6   .�5<      ��  �� Property � �� �� Value$ Stretch=�6C   �� 5=       � �� 5>      �� 5?       �� 
TargetType" ��6.   .R�5A   "   ��  ��Name$ Bg��6)   #��z��65   #��z��5B   )    �� Padding# z��5C   )    J� SnapsToDevicePixels . ._�5E   &   �� #��z��67   # z 5F   7   #��z��5G   7   5H   #    �� Triggers 5J   "   P� 5L   &    P� Property �@J�IsMouseOver P� Value . . �5M   *   ��  �� 
TargetName$ Bg��6G    � ��
 ���� 6W   5N   '   P� 5O   &    �@��
IsSelected . . �5P   *   �� $ Bg��6G    � ��
 ���� 6W   5Q   '   5T      5V      5X      ��5[      �� 5\      .R�5]      ��  ��Name$ ButtonAudioSelect��6   -   5        ��5^      �� 5_      $
��Left=�6(    �� TextAlignment$ Center=�5`   (   $
��Wrap=�5a   (   ��5b   (   �� *Name+ �� 	Converter# [  5d      5e      5h      �� 5i   
   -   5        $ 
ButtonBack��5i   =   $��3��6   $��Center=�6   $��
Назад��6Q   6a   5j      5k      