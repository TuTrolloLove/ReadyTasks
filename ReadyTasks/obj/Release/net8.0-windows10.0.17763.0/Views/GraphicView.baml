   M S B A M L   `   `   `  ���� E  AReadyTasks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ReadyTasks.ViewsReadyTasks.Views  U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf "    ReadyTasks.Views.GraphicView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:ReadyTasks.Views     Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .���� $
��Auto=�.��� -     �Name$  myGrid�� � ColumnDefinitions �� $��* ��� $��* �.+��� -    ��Name$ r1��$	��380��$	��372��$��Center=�$��Center=����#CCCCCC �� RadiusX$ 10�� �� RadiusY$ 10��
���   � 
  Shadow#��[    LiveCharts.Wpf.PieChart  -   $"��PieChartCompletedNoCompleted��$��0��$	��350��$	��350��&   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Bottom=�   Series   LiveCharts.Wpf.PieSeries   # GraphicViewPieChartSeries1Title  LiveCharts.Wpf.Series   Title# [    
FontFamily$ 
Montserrat)�   # GraphicViewPieChartSeries2Title# [ $ 
Montserrat)��� -   $ r2��$��1��$	��380��$	��372��$��Center=�$��Center=����#CCCCCC$ 10��$ 10��
���   �#��[    -   $��PieChartPriority��$��1��$	��350��$	��350��$ Bottom=�    $  GraphicViewPieChart2Series1Title# [ 	   Fill
	 �  ��$ 
Montserrat)�   $  GraphicViewPieChart2Series2Title# [ 
	 � ���$ 
Montserrat)�   $  GraphicViewPieChart2Series3Title# [ 
	 �����$ 
Montserrat)��� -   $ 
rDontNotes��$��2��$	��700��$	��372��$��61,0,0,0q�$
��Left=�$��Center=����#CCCCCC$ 10��$ 10��
���   �#��[  $y�	Collapsed=��� -   
 ��Name$
 tbDontNotes��$��2��$	��378��$��	222,0,0,0q�$
��Left=�$��Center=�$��32(�$
��Bold"� ) %GraphicViewPieChartTextBlockDontNotes#��[ $
��Wrap=�$y�	Collapsed=�