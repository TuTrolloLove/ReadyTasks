   M S B A M L   `   `   `  ���� E  AReadyTasks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ReadyTasks.ViewsReadyTasks.Views  #    ReadyTasks.Views.EditNoteView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:ReadyTasks.Views     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     �Name$  editNoteViewWindow�� � Title$  ��$
��1280��$	��720�� � WindowStartupLocation$ CenterScreen=�.��� ����    primaryBackgroundColor2 �� Color# [  .+��� -    ��Name$ 
stackPanel��$��342,88,382,17q� �� Orientation$ Vertical=�.+��� -    ��Name$ TBTitle��$	��251��$��	90,20,0,0q�$��
Montserrat)�$��42(�$��Medium"�  plainTextColor3#��[ $�� ��$
��Wrap=��� -    ��Name$ tbTitle��$	��304��$��22��$��0,20,0,0q�$��2q�$
��Bold"�
���   �.������  �� 
TargetType" ��.R��� $��1q�	 �� CornerRadius$	 10������ 
 �� 
StartPoint$	
 0,0&� �� EndPoint$	 1,1&�.���  � Offset$	 0.0Q� � Color# [  � $
 0.01Q�  plainTextColor3.1# [ ���� $	
 0,0&�$	 1,1&�.��� $	 0.0Q�$ White��� $	 2.0Q�$ White��._���  ��Name$ PART_ContentHost��.���� -   $ 	TBContent��$	��284��$��	70,20,0,0q�$��
Montserrat)�$��42(�$��Medium"�#��[ $�� ��$
��Wrap=��� -   $ tbContenido��$	��419��$	��133��$��0,20,0,0q�$��2q� �� AcceptsReturn$
 True��.������ " ��.R��� $��1q�$	 10������ $	
 0,0&�$	 1,1&�.��� $	 0.0Q�# [  � $
 0.01Q�# [ ���� $	
 0,0&�$	 1,1&�.��� $	 0.0Q�$ White��� $	 2.0Q�$ White��._��� $ PART_ContentHost��.���� -   $ 
TBPriority��$	��295��$��	70,20,0,0q�$��
Montserrat)�$��42(�$��Medium"�#��[ $�� ��$
��Wrap=��� -    ��Name$ cbPrioridad��$	��150��$��0,20,0,0q� � 	Resources  �� 
TargetType �� Property �� Value �� 	ClickMode d� 	IsChecked �� Path �� Mode �� RelativeSource �� SelectionBoxItem �� SelectionBoxItemTemplate J� IsHitTestVisible �� 
IsReadOnly � AllowsTransparency �� IsDropDownOpen  �Name! � ActualWidth" �� MaxDropDownHeight# J� SnapsToDevicePixels$ ��Name% K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation&   DirectionalNavigation��%$  '��       7   7  7   7  �� " ��.���  � �� �� " ��.R��� $��1q�$	 1������ $	
 0,0&�$	 1,1&�.��� $	 0.0Q�8   � $
 0.01Q�8  ._�� .+�d� $��2��$ Press=�$|�false�� �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+�� #��z��$
��Left=�$��Center=�#��z #��z #��z��$ False���� $ PART_EditableTextBox��#��z��#��z��#��z��
������ $y�Hidden=� �� $ 
IsReadOnly� �� *TemplatedParent+� $��
PART_Popup��$
 True��$|�False��#��z $��Bottom=�$��Slide=�.��� $  DropDown��#��z! #��z" $
# True��.+��� $$ DropDownBorder��
�������$��1q�$	 10������ $	
 0,0&�$	 1,1&�.��� $	 0.0Q�8  � $
 0.01Q�8  �� $��4,6,4,6q�$
# True��.���� $
% True��$& 	Contained=�.@��� -	   ' ��Name$' CBILow��  EditNoteComboBoxItemLow#��[ �� -
   $' 	CBIMedium��  EditNoteComboBoxItemMedium#��[ �� -   $' CBIHigh��  EditNoteComboBoxItemHigh#��[ �� -   ( ��Name$( btSave��$	��214��$��47��$��0,20,0,0q�
������ 
������ $�� ��$��32(�$
��Bold"�${�False������ " ��.R��� ) ��Name$) contentPresenter��$��Center=�$��Center=�#��z��* J� Effect* 3  -System.Windows.Media.Effects.DropShadowEffect  +   
BlurRadius$+ 1Q�,   	Direction$	, 315Q�-   ShadowDepth$- 1Q�.   Color$. 	DarkGreen��/ �� Triggers/ P� 0 P� Property0 � {�1 P� Value$
1 True��. ��� 2 �� 
TargetName$2 contentPresenter�� � ��
 � � �P� 0 � {�$1 False��. ��� $2 contentPresenter�� � ��
 �  ���� $��627,291,0,0q�$
��Left=�$	��Top=�$�� ��$
��Wrap=�