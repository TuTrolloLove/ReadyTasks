   M S B A M L   `   `   `  ���� E  AReadyTasks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ReadyTasks.CustomControlsReadyTasks.CustomControls  3clr-namespace:ReadyTasks.ViewsReadyTasks.Views  =#clr-namespace:ReadyTasks.ViewModelsReadyTasks.ViewModels       ReadyTasks.Views.LoginView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Bcustomcontrols'clr-namespace:ReadyTasks.CustomControls     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:ReadyTasks.Views     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9	viewModel#clr-namespace:ReadyTasks.ViewModels     -     � Title$  Ready Tasks��$
��1280��$	��720�� � AllowsTransparency$
 True��
������  � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � DataContext *   $ReadyTasks.ViewModels.LoginViewModel   � 	Resources    BooleanToVisibility��%   &	        �� y���  �� 	Converter# [   �� Mode$ TwoWay=�	 �� Path$	 IsViewVisible�.���� 
 �� CornerRadius$
 50������  �� ImageSource$( "/Images/Login/background-login.jpg�� j� Stretch$
 None=�._��� ���#c0c0c0���#5c6e91$��10q�$
 47�� J� Opacity$	 0.9Q�._��  � RowDefinitions �� $��30 ��� $
��auto �.+�� $��1��$��
0,39,0,536q� � ColumnDefinitions �� �� $
��21.5 ��� $	��3.5 ��� $��25 ��� $��15 �.+��� -    ��Name$ btnMinimize��$��1��$��3��$��5,-456,19,456q�$��0q�$��-�� � Cursor$
 Hand��$��20(�����  �� 
TargetType" ��.���  �� Property � �� �� Value �#ffbd44 �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  � �� �#ff9966����  �� 
TargetType" ��.R��� $��18��$��18��#��z��$
 9��._��� $��0,-6,0,0q�$��Center=�$��Center=��� -   $ btnClose��$��3��$��0,-456,0,456q�$��0q�$��X��$
 Hand��$��16(� J� RenderTransformOrigin$ 
0.06,0.335&����� " ��.���  � �� �#ff5f57 P�  �@J�IsMouseOver$
 True��. ���  � �� �#ff3d3a���� " ��.R��� $��18��$��18��#��z��$
 9��._��� $��0,-2,0,0q�$��Center=�$��Center=��� $��1��$	��300��$��265,18,265,17q� �� Orientation$ Vertical=�.+��� -    ��Name$ imgLogo��$	��250��$	��213��$��/Images/Login/logo.png���� $��Center=�$��24(�$
��Bold"�
���   �  LoginViewReadyTaskTextBlock#��[ �� $��0,30,0,0q�$��Center=�$��16(�$
��Bold"�
���   �  LoginViewEmailTextBlock#��[ �� -    ��Name$ txtUser��$��30��$��0,5,0,0q�$��30,0,0,0q�$��Center=����#5c6e91$��0,0,0,5q� �� 
CaretBrush �#5c6e91$��16(�$
��Bold"�
���   ����� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�.������  j� 
AlignmentX$
 Left=�$ /Images/Login/user.png��$ Uniform=�.���� -     ��Name$  
tbPassword��$��0,30,0,0q�$��Center=�$��16(�$
��Bold"�
���   �  LoginViewPasswordTextBlock#��[ 3   -ReadyTasks.CustomControls.BindablePasswordBox  -   !  Name$! txtPassword��$��30��$��0,5,0,0q�"   Password" �� *
Password+$ TwoWay=�$ PropertyChanged=��� $��	0,10,0,10q�$��Center=�$��12(�$
��Bold"����#D7596D���� *ErrorMessage+�� -   $ btnLogin��$��0q�  LoginViewLoginButtonContent#��[ $
 Hand��$
��Bold"�
���   ����� *LoginCommand+���� " ��.���  � �� �#28AEED P�  �@J�IsMouseOver$
 True��. ���  � �� �#278BEF���� " ��.R��� $	��150��$��30��#��z��$
 15��._��� $��Center=�$��Center=��� -	   $ btnLogin_Register��$	��150��$��5,5,5,5q�$��0q� " LoginViewRegisterButtonContent#��[ $
 Hand��$
��Bold"�
���   ����� *RegisterCommand+���� " ��.���  � �� �#28AEED P�  �@J�IsMouseOver$
 True��. ���  � �� �#278BEF���� " ��.R��� $	��150��$��30��#��z��$
 15��._��� $��Center=�$��Center=��� -
   $��70��$��74��$"��/Images/Login/googleIcon.png���� -   $ txtShowPassword��$��1��$��30��$��505,405,505,0q�$��30,0,0,0q�$	��Top=�
������ ���#5c6e91$��0,0,0,5q� �#5c6e91$��16(�$
��Bold"�
���   �$y�Hidden=��� $��1��$��480,408,755,985q�$ ��/Images/Login/password.png��