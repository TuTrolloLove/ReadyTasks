   M S B A M L   `   `   `  ���� E  AReadyTasks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ReadyTasks.ViewsReadyTasks.Views      ReadyTasks.Views.HelpView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:ReadyTasks.Views     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .��� -     �Name$
  grid��.+��� $	��620��$	��440��$��0,26,0,0q�$��Center=�$	��Top=�
������� �� RadiusX$ 10�� �� RadiusY$ 10��
���   � 
  Shadow#��[  �� -    ��Name$ 
tblockHelp��$��0,36,0,0q�$��Center=�$	��Top=�$��
Montserrat)�$��30(�$��Medium"�  HelpViewTextBlock#��[ $
��Wrap=��� -    ��Name$ tbHelp��$	��526��$	��254��$��	0,110,0,0q�$��Center=�$	��Top=� �� TextWrapping$
 Wrap=��� -    ��Name$ btSave��$	��210��$��50��$��	0,390,0,0q�$��Center=�$	��Top=�  HelpViewSendButton#��[ $��
Montserrat)�$��32(�$��Medium"�${�False������  �� 
TargetType" ��.R���  ��Name$ contentPresenter��$��Center=�$��Center=�#��z��	 �� Triggers	 P� 
 P� Property
 � {� P� Value$
 True��. ���  �� 
TargetName$ contentPresenter�� �� Property � �� �� Value
 � � �P� 
 � {�$ False��. ��� $ contentPresenter�� � ��
 �  ��