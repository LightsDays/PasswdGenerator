   M S B A M L   `   `   `  ����J  FPasswdGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PasswdGeneratorPasswdGenerator  5   	   O,clr-namespace:PasswdGenerator.MVVM.ViewModelPasswdGenerator.MVVM.ViewModel  5   	        PasswdGenerator.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:PasswdGenerator     5   	   B	viewModel,clr-namespace:PasswdGenerator.MVVM.ViewModel     5   	   $	��600��5	   	   $	��920��6     � 
ResizeMode$  NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   
������  � AllowsTransparency$
 True��5   	    � DataContext 5      2  ,PasswdGenerator.MVVM.ViewModel.MainViewModel  5   
   .��5      ��  �� CornerRadius$ 10��6   $��1q�6   ���	#FF272727��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF15171E��6   	 � Offset$	 0Q�61   � 5      $ 	#FF15171E��6   $	 1Q�61   5      ._�5   
   � -   5        $��MainGrid��5      
������ 
 � RowDefinitions
 5      �� 5      $��75 �6    �� 5      .+�5E      �� $��0��6    �� Orientation$ 
Horizontal=�6&   $��	20,0,30,0q�6?   .+�5F      	� $��ГЛАВНАЯ��6    d� 	IsChecked$
 TrueY�5G         MenuButtonBlackTheme#��[  5H      ��5I      �� *HomeViewCommand+	� 5K      $��ПРОВЕРКА��6   #��[  5L      ��5M      �� *CheckViewCommand+	� 5O      $��ГЕНЕРАТОР��6   #��[  5P      ��5Q      �� *GeneratorViewCommand+5R      �� 5S      $��0��6   $ 
Horizontal=�5T      $��Right=�5U      $	��Top=�5V      .+�5X      �� -   5        $��bClose��5X        CloseButtonBlackTheme#��[ 5Y      $��30��5Z      $��40��5[      6$   5\      �� 5]      $��1��6   $��30,10,30,10q�5^      ��5_      �� *CurrentView+5`      5a      5c      