   M S B A M L   `   `   `  ����E  AReadyTasks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ReadyTasks.ViewsReadyTasks.Views  5      _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a{Sclr-namespace:MaterialDesignThemes.Wpf.Converters;assembly=MaterialDesignThemes.Wpf#MaterialDesignThemes.Wpf.Converters 5      !    ReadyTasks.Views.ExportView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:ReadyTasks.Views     5      FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      rmaterialDesignConvertersSclr-namespace:MaterialDesignThemes.Wpf.Converters;assembly=MaterialDesignThemes.Wpf  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      -   5        .��5      � .+�5   
   �� -   5          ��Name$  	rectangle��5      $	��800��5      $	��600��5      $��Center=�5      $��Center=�5      
������� �� RadiusX$ 10��5       �� RadiusY$ 10��5      
���   � 
  Shadow#��[  5      �� 5   
   -   5         ��Name$ 
stackPanel��5      $��128,69,108,78q�5       �� Orientation$ Vertical=�5      .+�5      �� -   5         ��Name$ tbChooseFormat��5      $	��502��5       $��90��5!      $��0,80,0,0q�5"      $��Center=�5#      $��
Montserrat)�5$      $��40(�5%      $��Medium"�5&      
���   �  ExportFormatViewTextBlock1#��[ 5(       �� TextAlignment$ Center=�5)      $
��Wrap=�5*      �� 5+      -   5         ��Name$ cbFormat��5,      $��68��5-      $��0,40,0,0q�5.       �� SelectedIndex$ 0��5/      	 � 	Resources	 50      
 �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� 
StartPoint �� EndPoint � Offset � Color �� 	ClickMode d� 	IsChecked �� Mode �� RelativeSource �� Mode �� SelectionBoxItem �� SelectionBoxItemTemplate J� IsHitTestVisible ��Name �� 
IsReadOnly �Name � AllowsTransparency �� IsDropDownOpen  �Name! � ActualWidth" �� MaxDropDownHeight# J� SnapsToDevicePixels$ ��Name% K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation&   DirectionalNavigation��%�  '��       �� 51      "
 ��6   .�52      ��  � �� 53      �� 54   "   " ��62   .R�55   &   �� $��1q�6-   $ 1��6A   ��56   *   �� 57   .   $	 0,0&�6B   $	 1,1&�6S   .��58   2   � $	 0.0Q�6?   $
 Pink��6L   � 59   2   $	 1.0Q�6?   $ DarkCyan��6L   5:   /   ._�5<   *   � .+�5=   .   d� $��2��5>   1   $ Press=�5?   1   $|�false��5@   1    5A   1   �� *IsDropDownOpen+$ TwoWay=� �� $ TemplatedParent=��� 5B   .   #��z��5C   1   $
��Left=�5D   1   $��Center=�5E   1   #��z 5F   1   #��z 5G   1   #��z��5H   1   $ False��5I   1   �� 5J   .   $ PART_EditableTextBox��5K   1   #��z��5L   1   #��z��5M   1   #��z��5N   1   
������ $y�Hidden=�5Q   1    5P   1   �� *
IsReadOnly+ �� $ TemplatedParent=�5Q   1   � 5R   .   $ 
PART_Popup��5S   1   $
 True��5T   1   $|�False��5U   1   #��z 5V   1   $��Bottom=�5W   1   $��Slide=�5X   1   .��5Y   2   � $  DropDown��5Z   5   #��z! 5[   5   #��z" 5\   5   $
# True��5]   5   .+�5^   6   �� $$ DropDownBorder��5_   9   
�������$��1q�5a   9   $ 10��5b   9   ��5c   :   �� 5d   >   $	 0,0&�6R   $	 1,1&�6c   .��5e   B   � $	 0.0Q�6O   $
 Pink��6\   � 5f   B   $	 1.0Q�6O   $ DarkCyan��6\   5g   ?   5i   7   �� 5j   6   $��4,6,4,6q�6C   $
# True��6T   .��5k   :   �� $
% True��6E   $& 	Contained=�6X   5l   7   5m   3   5n   /   5o   +   5p   '   5q   #   5s      5t      5u      .@�5v      ��  ! ExportFormatViewComboBoxItem1#��[ 6   �� 5w       ! ExportFormatViewComboBoxItem2#��[ 6   5x      �� 5y      -   5        ' ��Name$' 	btnExport��5z      $	��384��5{      $	��114��5|      $��0,40,0,0q�5}      
������ 
������    ExportFormatViewButtonExport#��[ 5�      $��
Montserrat)�5�      $��50(�5�      $��Medium"�5�      
��� � ���5�      �� 5�      " ��6&   .R�5�      �� #��z��6!   ._�5�      �� $��Center=�6/   $��Center=�6L   5�      ( �� Triggers( 5�      P� 5�      ) P� Property) �@J�IsMouseOver* P� Value$
* True��6=   . �5�   "   ��  � ��
 ���� 6?   5�      5�      5�      5�      5�      5�      