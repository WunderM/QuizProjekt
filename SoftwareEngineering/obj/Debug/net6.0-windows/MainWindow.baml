   M S B A M L   `   `   `  ����  SoftwareEngineering$    SoftwareEngineering.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	      BackgroundBrush#��[  5   	    � WindowState$ 	Maximized=�5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � $��0��6     PrimaryBrush#��[ 6   $��60��6G    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6)   $��Center=�6B   $
��Left=�6]   $
��10,0q�6x   .+�5      �� -   5        $
��Home��5        NavigationButtonStyle#��[ 5      5      �� 5      -   5        $��About��5      #��[ 5      5       5!      �� 5$      $��1��6     	LogoImage#��[ 6$   $��40��5%      $��40��6   $��Center=�5&      $��Center=�5'      �� 5)      $��2��6   $ 
Horizontal=�6)   $��Center=�6B   $��Right=�6]   $
��10,0q�6y   .+�5*      �� -   5        $��Logout��5*      #��[ 5+      y�5-      �� *LogoutButtonVisibility+ �� UpdateSourceTrigger$ PropertyChanged=��� 5.      -   5        $��Login��5.      #��[ 5/      y�51      �� *LoginButtonVisibility+$ PropertyChanged=��� 52      -   5        $��X��52        CloseButtonStyle#��[ 53      54      55      58      � 59   
   $��1��6   #��[ 6   .+�5:       �   � NavigationUIVisibility$ Hidden=�6   ��64   �� *CurrentPage+	 �� Mode$	 TwoWay=�5;      5<      5=      