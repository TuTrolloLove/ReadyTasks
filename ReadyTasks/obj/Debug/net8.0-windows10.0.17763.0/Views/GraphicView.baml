   M S B A M L   `   `   `  ����E  AReadyTasks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ReadyTasks.ViewsReadyTasks.Views  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      "    ReadyTasks.Views.GraphicView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:ReadyTasks.Views     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .��5      �� $
��Auto=�6   .��5   
   � -   5          �Name$  myGrid��5       � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� -   5         ��Name$ r1��5      $	��380��5      $	��372��5      $��Center=�5      $��Center=�5      ���#CCCCCC �� RadiusX$ 10��5       �� RadiusY$ 10��5      
���   � 
  Shadow#��[  5        LiveCharts.Wpf.PieChart  5      -   5        $"��PieChartCompletedNoCompleted��5      $��0��5      $	��350��5       $	��350��5!      &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Bottom=�5"         Series 5$        LiveCharts.Wpf.PieSeries   # GraphicViewPieChartSeries1Title  LiveCharts.Wpf.Series   Title# [ 6$      
FontFamily$ 
Montserrat)�6]     5%       # GraphicViewPieChartSeries2Title# [ 6$   $ 
Montserrat)�6]   5'      �� 5(      -   5        $ r2��5)      $��1��5*      $	��380��5+      $	��372��5,      $��Center=�5-      $��Center=�5.      ���#CCCCCC$ 10��50      $ 10��51      
���   �#��[  53        54      -   5        $��PieChartPriority��55      $��1��56      $	��350��57      $	��350��58      $ Bottom=�59       5;         $  GraphicViewPieChart2Series1Title# [ 5<      	   Fill
	 �  ��$ 
Montserrat)�5>        5?       $  GraphicViewPieChart2Series2Title# [ 5@      
	 � ���$ 
Montserrat)�5B        5C       $  GraphicViewPieChart2Series3Title# [ 5D      
	 �����$ 
Montserrat)�5F      5H      �� 5J      -   5        $ 
rDontNotes��5K      $��2��5L      $	��700��5M      $	��372��5N      $��61,0,0,0q�5O      $
��Left=�5P      $��Center=�5Q      ���#CCCCCC$ 10��5S      $ 10��5T      
���   �#��[  5V      $y�	Collapsed=�5W      �� 5X      -   5        
 ��Name$
 tbDontNotes��5Y      $��2��5Z      $	��378��5[      $��	222,0,0,0q�5\      $
��Left=�5]      $��Center=�5^      $��32(�5_      $
��Bold"�5`       ) %GraphicViewPieChartTextBlockDontNotes#��[ 5a      $
��Wrap=�5b      $y�	Collapsed=�5c      5e      5f      5g      