   M S B A M L   `   `   `  ����  SoftwareEngineering"    SoftwareEngineering.QuizPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  Quiz Auswahl��5         BackgroundBrush N� 
Background# [  5      .��5      � $��20q�6    � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��	0,10,0,10q�6K   .+�5      �� $��Quiz auswählen: ��6   $��Center=�60   $��16(�6K   �� 5      -   5         ��Name$ QuizSelector��5      $	��200��6-   $��10,0,0,0q�69   5      5      �� 5   
   $ 
Horizontal=�6   $��Center=�6.   $��	0,10,0,10q�6K   $��1��6^   .+�5      �� $��Anzahl der Fragen: ��6   $��Center=�63   $��16(�6N   �� 5      -   5        $ QuestionCountSelector��5      $	��100��66   $��10,0,0,0q�6B   .@�5      �� $��5��6   �� 5      $��10��6   �� 5      $��15��6   5      5       �� 5#   
   -   5         ��Name$ StartQuizButton��5#      $��Quiz starten��6*   $��Center=�6A   $��Center=�6^   $��	0,10,0,10q�5$      $��2��6$   ${�False��6O   �� 5'   
   $��Highscore (Top 25)��6   $��3��6/   $��0,20,0,0q�6<   .��5(      &   System.Windows.Controls.DataGrid  -   5          Name$ HighscoreTable��5(         AutoGenerateColumns$ False��6/      
IsReadOnly$
 True��6K   	   HeadersVisibility$	 Column=�6]   
   Columns
 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header$ Spieler��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *
PlayerName+6Y     5+      $ Punkte��6)   $ * 6S    69   �� *Score+6S   5-      5.      5/      50      