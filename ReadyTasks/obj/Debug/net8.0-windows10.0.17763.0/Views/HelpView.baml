   M S B A M L   `   `   `  ����E  AReadyTasks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ReadyTasks.ViewsReadyTasks.Views  5          ReadyTasks.Views.HelpView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:ReadyTasks.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .��5      � -   5          �Name$
  grid��5      .+�5   
   �� $	��620��5      $	��440��5      $��0,26,0,0q�5      $��Center=�5      $	��Top=�5      
������� �� RadiusX$ 10��5       �� RadiusY$ 10��5      
���   � 
  Shadow#��[  5      �� 5   
   -   5         ��Name$ 
tblockHelp��5      $��0,36,0,0q�5      $��Center=�5      $	��Top=�5      $��
Montserrat)�5      $��30(�5      $��Medium"�5        HelpViewTextBlock#��[ 5      $
��Wrap=�5       �� 5!   
   -   5         ��Name$ tbHelp��5"      $	��526��5#      $	��254��5$      $��	0,110,0,0q�5%      $��Center=�5&      $	��Top=�5'       �� TextWrapping$
 Wrap=�5(      �� 5)   
   -   5         ��Name$ btSave��5*      $	��210��5+      $��50��5,      $��	0,390,0,0q�5-      $��Center=�5.      $	��Top=�5/        HelpViewSendButton#��[ 51      $��
Montserrat)�52      $��32(�53      $��Medium"�54      ${�False��55      ��56      �� 57       �� 
TargetType" ��6"   .R�58      ��  ��Name$ contentPresenter��59      $��Center=�5:      $��Center=�5;      #��z��5<      	 �� Triggers	 5=      P� 5>      
 P� Property
 � {� P� Value$
 True��67   . �5?      ��  �� 
TargetName$ contentPresenter��6%    �� Property � �� �� Value
 � � �6e   5@      P� 5A      
 � {�$ False��67   . �5B      �� $ contentPresenter��6%    � ��
 �  ��6e   5C      5E      5G      5H      5I      