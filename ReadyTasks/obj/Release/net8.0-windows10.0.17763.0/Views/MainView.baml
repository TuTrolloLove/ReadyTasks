   M S B A M L   `   `   `  ���� E  AReadyTasks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ReadyTasks.ViewsReadyTasks.Views  =#clr-namespace:ReadyTasks.ViewModelsReadyTasks.ViewModels      ReadyTasks.Views.MainView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  *localclr-namespace:ReadyTasks.Views  _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  3	viewModel#clr-namespace:ReadyTasks.ViewModels    � Title$  MainView��$
��1280��$	��720�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � DataContext )   #ReadyTasks.ViewModels.MainViewModel   � 	Resources  �� DataType)   #ReadyTasks.ViewModels.HomeViewModel   ReadyTasks.Views.HomeView+   %ReadyTasks.ViewModels.ExportViewModel!   ReadyTasks.Views.ExportView,   &ReadyTasks.ViewModels.GraphicViewModel"   ReadyTasks.Views.GraphicView-   'ReadyTasks.ViewModels.SettingsViewModel#	   ReadyTasks.Views.SettingsView)
   #ReadyTasks.ViewModels.HelpViewModel   ReadyTasks.Views.HelpView*   $ReadyTasks.ViewModels.AdminViewModel    ReadyTasks.Views.AdminView��%�   (��       *, +)(��      *, +)(�� $     *, +)(�� 6     *, +)(�� H     *,
 +)(�� Z     *, +)�� "  .R�  �� "  .R�  �� "  .R�  �� "  .R�	  �� " 
 .R�  �� "  .R�  .���� ���#5c6e91$��1q� J� Opacity$	 0.9Q�._��  � ColumnDefinitions �� $	��250 ��� $��* �.+��� $��0�� �� CornerRadius$ 	10,0,0,10������    primaryBackgroundColor1	 �� Color#	 [  �� .+��� $��35��$��
15,25,0,40q�
 �� Orientation$
 
Horizontal=�.+��� $��../Images/Login/logo.png���� $��10,0,0,0q�$��Center=�$��
Montserrat)�$��20(�$��Medium"�  primaryTextColor1#��[   MainViewReadyTasksTextBlock#��[ 	�  d� 	IsChecked$
 TrueY�  
menuButton#��[  
 color1
 � Tag# [ ���� *ShowHomeViewCommand+.���� $
 
Horizontal=�.+�!  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$
 Home=�  menuButtonIcon#��[ �� -    ��Name$ tbNotesNavBar��  menuButtonText#��[   MainViewDashboard#��[ 	� #��[ # [ ���� *ShowGraphicViewCommand+.���� $
 
Horizontal=�.+�  $ PieChart=�#��[ �� -   $ tbGraphicNavBar��#��[   MainViewDoGraphic#��[ 	� #��[ # [ ���� *ShowExportViewCommand+.���� $
 
Horizontal=�.+�  $ ArrowUpFromBracket=�#��[ �� -   $ tbExportNotesNavBar��#��[  	 MainViewExportAllNotes#��[	 	� #��[ # [ ���� *ShowSettingsViewCommand+.���� $
 
Horizontal=�.+�  $ Tools=�#��[ �� -   $ tbSettingsNavBar��#��[  
 MainViewSettings#��[
 	� #��[ # [ ���� *ShowHelpViewCommand+.���� $
 
Horizontal=�.+�  $ Question=�#��[ �� -   $ tbHelpNavBar��#��[   MainViewHelp#��[ 	� -   $��rbAdmin��#��[ # [ $y�Hidden=����� *ShowAdminViewCommand+.���� $
 
Horizontal=�.+�  $ UserTie=�#��[ �� #��[ $��Admin���� $��1��$ 	0,10,10,0������   primaryBackgroundColor2#	 [ ._��  � RowDefinitions �� $��25 ��� $��35 ��� $��* �.+��� -    ��Name$ pnlControlBar��$��0��$��0,0,5,0q�
������ $��RightToLeft=�$
 
Horizontal=�.+��� -    ��Name$ btnClose��  controlButton#��[  
 color4# [ .��  $ XMark=�  controlButtonIcon#��[ �� -	   $ btnMaximize��#��[  
 color6# [ .��  $ Square=�#��[ �� -
   $ btnMinimize��#��[ # [ .��  $��12��$ WindowMinimize=�#��[ � $��1�� �� �� .+��� $��0��$��Center=�$
 
Horizontal=�.+�  $��20��$��20��$��	35,0,10,0q�  plainTextColor3   
Foreground# [  �� *Icon+�� -   $ tbSecondaryViewOpened��$	��183��$��Center=�$��
Montserrat)�$��16(�$��Medium"�#��[ ���� *	Caption+�� $��2��$��25q����� *CurrentChildView+