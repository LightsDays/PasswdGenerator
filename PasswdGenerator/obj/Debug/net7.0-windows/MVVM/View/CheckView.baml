   M S B A M L   `   `   `  ����J  FPasswdGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PasswdGenerator.MVVM.ViewPasswdGenerator.MVVM.View  5      )    #PasswdGenerator.MVVM.View.CheckView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:PasswdGenerator.MVVM.View     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��90 �6   �� 5      $	��107 �6   �� 5      $	��145 �6   �� 5      $	��31* �6   �� 5      $	��23* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��2��6   $��5,5,5,5q�5      $��1q�5       �� CornerRadius$ 10��5      ���	#FF5F5F5F._�5      �� -   5        $��tbPasswd��5       �� TextWrapping$
 Wrap=�5      $��0q�5      
������ $��30(�5      
�������$
��Bold"�5!      $��Center=�5"       �� TextAlignment$ Center=�5#       �� 
CaretBrush
 �����5$      5%      �� 5&   
    J� IsHitTestVisible$ False��6   $��30(�5'      $9��3Введите пароль для проверки��5(       �� TextAlignment$ Center=�5)      $��Center=�5*      $��2��5+      ���	#FF535559$��40��5,   +   ��5-      �� 5.       �� 
TargetType" ��6   .�5/      �� 	 �� Property	 � y�
 �� Value$
 	Collapsed=�63    �� Triggers 50      �� 51       �� Binding 6&   �� *Text+ �� ElementName$ tbPasswd�� �� Value  6U   .a�52      �� 	 � y�$
 Visible=�6;   53      55      57      �� 59   
   $��2��6   $��5,5,5,5q�5:         InteractionBorderBlackTheme#��[  5;      ._�5<      �� -   5        $��btnCheck��5<      $��Проверить��5=      $��26(�5>        InteractionButtonBlackTheme#��[ 5?      6J   5@      �� 5B   
   -   5        $��bCheck��5B      $��3��5C      $��4��5D      $��1��5E      $��5,5,5,5q�5F      $y�Hidden=�5G      $��2q�5H      5I      �� 5L   
   -   5        $��tbCheckRareResult��5L      $��1��5M      $��3��5N      $
��Wrap=�5O      $��0,20,0,0q�5P      
������ $��30(�5R      $
��Bold"�5S      $��Center=�5T      $ Center=�5U      �� 5W   
   -   5        $��tbCheckResultText��5W      $��2��5X      $��3��5Y      $
��Wrap=�5Z      $��	10,0,10,0q�5[      
������ $��30(�5]      
�������$��Center=�5_      $ Center=�5`      5p      5q      