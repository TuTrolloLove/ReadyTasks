   M S B A M L   `   `   `  ����E  AReadyTasks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ReadyTasks.ViewsReadyTasks.Views  5      )    #ReadyTasks.Views.ExportFormatWindow   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:ReadyTasks.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          �Name$  exportFormatWindowTitle��5         ExportFormatWindowTitle � Title# [  5	      $	��300��5
      $	��150��5       � WindowStartupLocation$ CenterScreen=�5      .��5      �� $��Center=�6   $��Center=�6.   .+�5   
   �� -   5         ��Name$ tbFormatQuestion��5      $��10q�5        ExportFormatWindowTextBlock#��[ 5      �� 5   
   -   5        $��BtnCsv��5      $	��184��5      $��10q�5      
������ 
������ ��5      �� 5       �� 
TargetType" ��6"   .R�5      �� #��z��6   ._�5      �� $��Center=�6+   $��Center=�6H   5       �� Triggers 5      P� 5        P� Property �@J�IsMouseOver P� Value$
 True��69   . �5!      ��  �� Property � ��	 �� Value
	 ���� 6;   5"      5$      .��5&      �� 
 �� Orientation$
 
Horizontal=�6   .+�5'      �� $��20��5(      $��20��5)      $,��&/Images/ExportFormatWindow/csvLogo.png��5*      �� 5+      $
��Bold"�6   $�� C S V��6.   5,      5-      �� 5.   
   -   5        $��BtnTxt��5/      $	��184��50      $��10q�51      
������ 
������ ��55      �� 56      " ��6"   .R�57      �� #��z��6   ._�58      �� $��Center=�6+   $��Center=�6H   59       5:      P� 5;       �@J�IsMouseOver$
 True��69   . �5<      ��  � ��
	 ���� 6;   5=      5?      .��5A      �� $
 
Horizontal=�6   .+�5B      �� $��20��5C      $��20��5D      $,��&/Images/ExportFormatWindow/txtLogo.png��5E      �� 5F      $
��Bold"�6   $�� T X T��6.   5G      5H      5I      5J      