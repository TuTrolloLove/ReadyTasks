   M S B A M L   `   `   `  ����E  AReadyTasks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ReadyTasks.ViewsReadyTasks.Views  5      =#clr-namespace:ReadyTasks.ViewModelsReadyTasks.ViewModels  5
          ReadyTasks.Views.MainView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      *localclr-namespace:ReadyTasks.Views  5      _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      3	viewModel#clr-namespace:ReadyTasks.ViewModels  5
        � Title$  MainView��5      $
��1280��5      $	��720��5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5       � DataContext 5      )   #ReadyTasks.ViewModels.MainViewModel  5   
    � 	Resources 5       �� DataType)   #ReadyTasks.ViewModels.HomeViewModel   ReadyTasks.Views.HomeView+   %ReadyTasks.ViewModels.ExportViewModel!   ReadyTasks.Views.ExportView,   &ReadyTasks.ViewModels.GraphicViewModel"   ReadyTasks.Views.GraphicView-   'ReadyTasks.ViewModels.SettingsViewModel#	   ReadyTasks.Views.SettingsView)
   #ReadyTasks.ViewModels.HelpViewModel   ReadyTasks.Views.HelpView*   $ReadyTasks.ViewModels.AdminViewModel    ReadyTasks.Views.AdminView��%�  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5       *, +)(�� �     5$      *,
 +)(�� �     5'      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5    
   "  6   .R�5!      	  5"      �� 5$   
   " 
 6   .R�5%        5&      �� 5'   
   "  6   .R�5(        5)      5+      .��5-      �� ���#5c6e91$��1q�5/   	    J� Opacity$	 0.9Q�50   	   ._�51   
   �  � ColumnDefinitions 52      �� 54      $	��250 �6#   �� 56      $��* �6#   .+�5:      �� $��0��6    �� CornerRadius$ 	10,0,0,10��6%   ��5;      �� 5<         primaryBackgroundColor1	 �� Color#	 [  6&   5>      �� 5@      .+�5B      �� $��35��5C      $��
15,25,0,40q�5D      
 �� Orientation$
 
Horizontal=�5E      .+�5F      �� $��../Images/Login/logo.png��6   �� 5G      $��10,0,0,0q�5H      $��Center=�5I      $��
Montserrat)�5J      $��20(�5K      $��Medium"�5L        primaryTextColor1#��[ 5M        MainViewReadyTasksTextBlock#��[ 5N      5O      	� 5R       d� 	IsChecked$
 TrueY�5T        
menuButton#��[ 5U       
 color1
 � Tag# [ 5V      ��5S      �� *ShowHomeViewCommand+.��5W      �� $
 
Horizontal=�6!   .+�5X      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$
 Home=�6'     menuButtonIcon#��[ 63   �� 5Y      -   5         ��Name$ tbNotesNavBar��5Z        menuButtonText#��[ 5[        MainViewDashboard#��[ 5\      5]      5^      	� 5_      #��[ 5a      # [ 5b      ��5`      �� *ShowGraphicViewCommand+.��5c      �� $
 
Horizontal=�6!   .+�5d        $ PieChart=�6'   #��[ 67   �� 5e      -   5        $ tbGraphicNavBar��5f      #��[ 5g        MainViewDoGraphic#��[ 5h      5i      5j      	� 5k      #��[ 5m      # [ 5n      ��5l      �� *ShowExportViewCommand+.��5o      �� $
 
Horizontal=�6!   .+�5p        $ ArrowUpFromBracket=�6'   #��[ 6A   �� 5q      -   5        $ tbExportNotesNavBar��5r      #��[ 5s       	 MainViewExportAllNotes#��[	 5t      5u      5v      	� 5w      #��[ 5y      # [ 5z      ��5x      �� *ShowSettingsViewCommand+.��5{      �� $
 
Horizontal=�6!   .+�5|        $ Tools=�6'   #��[ 64   �� 5}      -   5        $ tbSettingsNavBar��5~      #��[ 5       
 MainViewSettings#��[
 5�      5�      5�      	� 5�      #��[ 5�      # [ 5�      ��5�      �� *ShowHelpViewCommand+.��5�      �� $
 
Horizontal=�6!   .+�5�        $ Question=�6'   #��[ 67   �� 5�      -   5        $ tbHelpNavBar��5�      #��[ 5�        MainViewHelp#��[ 5�      5�      5�      	� 5�      -   5        $��rbAdmin��5�      #��[ 5�      # [ 5�      $y�Hidden=�5�      ��5�      �� *ShowAdminViewCommand+.��5�      �� $
 
Horizontal=�6!   .+�5�        $ UserTie=�6'   #��[ 66   �� 5�      #��[ 6$   $��Admin��6L   5�      5�      5�      �� 5�      $��1��6   $ 	0,10,10,0��6%   ��5�      �� 5�        primaryBackgroundColor2#	 [ 6&   ._�5�      �  � RowDefinitions 5�      �� 5�      $��25 �6(   �� 5�      $��35 �6(   �� 5�      $��* �6(   .+�5�      �� -   5         ��Name$ pnlControlBar��5�      $��0��5�      $��0,0,5,0q�5�      
������ $��RightToLeft=�5�      $
 
Horizontal=�5�      .+�5�      �� -   5         ��Name$ btnClose��5�        controlButton#��[ 5�       
 color4# [ 5�      .��5�        $ XMark=�6+     controlButtonIcon#��[ 68   5�      �� 5�      -	   5        $ btnMaximize��5�      #��[ 5�       
 color6# [ 5�      .��5�        $ Square=�6+   #��[ 69   5�      �� 5�      -
   5        $ btnMinimize��5�      #��[ 5�      # [ 5�      .��5�        $��12��5�   !   $ WindowMinimize=�5�   !   #��[ 5�   !   5�      5�      � 5�      $��1��6    5�      �� 5�      �� 5�      .+�5�      �� $��0��5�      $��Center=�5�      $
 
Horizontal=�5�      .+�5�        $��20��5�   !   $��20��5�   !   $��	35,0,10,0q�5�   !     plainTextColor3   
Foreground# [ 5�   !    5�   !   �� *Icon+�� 5�      -   5        $ tbSecondaryViewOpened��5�   !   $	��183��5�   !   $��Center=�5�   !   $��
Montserrat)�5�   !   $��16(�5�   !   $��Medium"�5�   !   #��[ 5�   !   ��5�   !   �� *	Caption+5�      5�      �� 5�      $��2��5�      $��25q�5�      ��5�      �� *CurrentChildView+5�      5�      5�      5�      5      