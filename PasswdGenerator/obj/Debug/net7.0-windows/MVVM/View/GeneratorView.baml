   M S B A M L   `   `   `  ����J  FPasswdGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PasswdGenerator.MVVM.ViewPasswdGenerator.MVVM.View  5      -    'PasswdGenerator.MVVM.View.GeneratorView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:PasswdGenerator.MVVM.View     5      -   5        .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��90 �6   �� 5      $��* �6   .+�5   
   �� $��3��6   $��5q�5      $��1q�5       �� CornerRadius$ 10��5      ���	#FF5F5F5F._�5   
   �� -   5        $��tbGeneratedPasswd��5       �� TextWrapping$
 Wrap=�5      $��0q�5      
������ $��30(�5      
�������$
��Bold"�5       �� TextAlignment$ Center=�5       �� 
CaretBrush
 �����5       5!      �� 5#   
   -   5        $��lbPasswords��5#      $��1��5$      $��0q�5%      ���	#FF0E86CA
������ $��Disabled=�5(      $��Disabled=�5)      5*   \   �� 5,   
   $��1��6   $��2��5-      $��10q�5.      .+�5/      �� -   5        $��sLength��5/      $
��Left=�50      $	��250��51       � Minimum$ 0Q�52       � Maximum$ 64Q�53       �� SelectionStart$ 0Q�54      	 �� AutoToolTipPlacement$	 TopLeft=�55      
 �� Interval$	
 100��56       �� Delay$
 1000��57       �� IsSelectionRangeEnabled$
 True��58      ���	#FF100237���	#FFC3222259   P   d� 5;      -   5        $��	tbNumbers��5;       d� 	IsChecked$ FalseY�5<      $��
Цифры��5=      $��1��5>         ToggleButtonBlackTheme#��[  5?      5@      d� 5B      -   5        $��tbSpecSymbols��5B      $ FalseY�5C      $��Спецсимволы��5D      $��1��5E      #��[  5F      6K   d� 5H      -   5        $��tbUpperLowerSymbols��5H      $��1��5I      $ FalseY�5J      $!��Нижний регистр��5K      #��[  5L       d� IsThreeState$
 True��5M      6/   d� 5O      -   5        $��tbUnique��5O      $ FalseY�5P      $!��Без повторений��5Q      $��1��5R      #��[  5S      6K   d� 5U      -	   5        $��tbRuSymbols��5U      $ FalseY�5V      $4��.Добавить русские символы��5W      $��1��5X      #��[  5Y      6K   5Z      �� 5]   
   $��1��6   $��1��5^      $��10q�5_      .+�5`      �� $��5q�6   $	��Top=�5a      $��50��5b        InteractionBorderBlackTheme#��[ 5c      ._�5d      �� -
   5        $��btnCopy��5d      $��Скопировать��5e      $��24(�5f        InteractionButtonBlackTheme#��[ 5g      6N   5h      �� 5j      $��5q�6   $	��Top=�5k      $��50��5l      #��[ 5m      ._�5n      �� -   5        $��
btnRefresh��5n      $��Обновить��5o      $��24(�5p      #��[ 5q      6N   5r      �� 5t      $��5q�6   $	��Top=�5u      $��50��5v      #��[ 5w      ._�5x      �� -   5        $��btnSave��5x      $��Сохранить��5y      $��24(�5z      #��[ 5{      6N   5|      5}      5~      5      