   M S B A M L   `   `   `  ���� E  AReadyTasks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ReadyTasks.ViewsReadyTasks.Views  _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a{Sclr-namespace:MaterialDesignThemes.Wpf.Converters;assembly=MaterialDesignThemes.Wpf#MaterialDesignThemes.Wpf.Converters !    ReadyTasks.Views.ExportView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:ReadyTasks.Views     FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  rmaterialDesignConvertersSclr-namespace:MaterialDesignThemes.Wpf.Converters;assembly=MaterialDesignThemes.Wpf  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  -   .��� .+��� -     ��Name$  	rectangle��$	��800��$	��600��$��Center=�$��Center=�
������� �� RadiusX$ 10�� �� RadiusY$ 10��
���   � 
  Shadow#��[  �� -    ��Name$ 
stackPanel��$��128,69,108,78q� �� Orientation$ Vertical=�.+��� -    ��Name$ tbChooseFormat��$	��502��$��90��$��0,80,0,0q�$��Center=�$��
Montserrat)�$��40(�$��Medium"�
���   �  ExportFormatViewTextBlock1#��[  �� TextAlignment$ Center=�$
��Wrap=��� -    ��Name$ cbFormat��$��68��$��0,40,0,0q� �� SelectedIndex$ 0��	 � 	Resources	 
 �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� 
StartPoint �� EndPoint � Offset � Color �� 	ClickMode d� 	IsChecked �� Mode �� RelativeSource �� Mode �� SelectionBoxItem �� SelectionBoxItemTemplate J� IsHitTestVisible ��Name �� 
IsReadOnly �Name � AllowsTransparency �� IsDropDownOpen  �Name! � ActualWidth" �� MaxDropDownHeight# J� SnapsToDevicePixels$ ��Name% K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation&   DirectionalNavigation��%2  '��       �� "
 ��.���  � �� �� " ��.R��� $��1q�$ 1������ $	 0,0&�$	 1,1&�.��� $	 0.0Q�$
 Pink��� $	 1.0Q�$ DarkCyan��._�� .+�d� $��2��$ Press=�$|�false�� �� *IsDropDownOpen+$ TwoWay=� �� $ TemplatedParent=��� #��z��$
��Left=�$��Center=�#��z #��z #��z��$ False���� $ PART_EditableTextBox��#��z��#��z��#��z��
������ $y�Hidden=� �� *
IsReadOnly+ �� $ TemplatedParent=�� $ 
PART_Popup��$
 True��$|�False��#��z $��Bottom=�$��Slide=�.��� $  DropDown��#��z! #��z" $
# True��.+��� $$ DropDownBorder��
�������$��1q�$ 10������ $	 0,0&�$	 1,1&�.��� $	 0.0Q�$
 Pink��� $	 1.0Q�$ DarkCyan���� $��4,6,4,6q�$
# True��.���� $
% True��$& 	Contained=�.@���  ! ExportFormatViewComboBoxItem1#��[ ��  ! ExportFormatViewComboBoxItem2#��[ �� -   ' ��Name$' 	btnExport��$	��384��$	��114��$��0,40,0,0q�
������ 
������    ExportFormatViewButtonExport#��[ $��
Montserrat)�$��50(�$��Medium"�
��� � ����� " ��.R��� #��z��._��� $��Center=�$��Center=�( �� Triggers( P� ) P� Property) �@J�IsMouseOver* P� Value$
* True��. ���  � ��
 ���� 