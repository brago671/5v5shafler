   M S B A M L   `   `   `  ���� E  A5x5shafler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:_5x5shafler_5x5shafler      _5x5shafler.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:_5x5shafler       � Title$  suicide��$	��400��$	��800�� � 
ResizeMode$ NoResize=����	#FFFBF5F5 � 	Resources  �� 
TargetType �� 	Resources �� Color   Button.Static.Background  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border  Button.Disabled.Foreground��%�  '��       &	  �     &	 �     &	 �     &	 �     &	 �     &	      &	     &	 *    &	 ?    �� " �� ���� $ 	#00000000��(��       * SystemColors.HighlightBrushKey+)�� $ 	#00000000��(��       *SystemColors.ControlBrushKey+)�� $ 	#FFDDDDDD���� $ 	#FF707070���� $ 	#FFBEE6FD���� $ 	#FF3C7FB1���� $ 	#FFC4E5F6���� $ 	#FF2C628B���� $ 	#FFF4F4F4���� $ 	#FFADB2B5���� $ 	#FF838383��.���  � ShowGridLines$ False�� � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* � � RowDefinitions �� $��50 ��� $��50 ��� $��* ��� $��* �.+��� -   	 ��Name$	 Output��$��Please select the players��$
��Left=�$��0,18,0,0q�$	��Top=�$��4��$	��800��$��82��$��Oblique$�
 J� OpacityMask

 �   ����	#FFFBF5F5$��2���� -   $	 TextBox1��$��1��$��2��$��30(�$��Team A��$��Center=�$	��Top=��� -   $	 TextBox2��$��1��$��2��$��2��$��30(�$��Team B��$	��Top=�$��Center=��� -    ��Name$ ListBoxTeamA��$��2��$��2��$��2��$��5,5,5,5q�$��20(����� " ��.���  �� Property � |� �� Value$ False����  � ��
 ���� ��  � �� ��  �� 
TargetType" ��.R��� �� -   $ ListBoxTeamB��$��2��$��2��$��2��$��2��$��5,5,5,5q�$��20(����� " ��.���  � |�$ False����  � ��
 ���� ��  � �� �� " ��.R��� �� -    ��Name$ btnSelectPlayers�����#5A99EB
�������$��Players��$��Center=�$	��Top=�$��50��$��68��$��3��$��0,-2,0,0q��� -   $	 lblPleyersSelected��$
��0/10��$��3��$
��Left=�$��	139,6,0,0q�$	��Top=�$��79��$��20(��� -   $ btnGenerate�����#5EAE79
�������$��Teams by Skill��$
��Left=�$	��Top=�$��50��$	��154��$��1��$��
158,-2,0,0q�$��2���� $��Output:��$
��Left=�$	��Top=�$��25��$	��291��$��2�����	#FFFBF5F5�� -	   $	 	TeamARank��$�� ��$
��Left=�$��	75,20,0,0q�$��1��$	��Top=� J� RenderTransformOrigin$ 
0.342,0.31&��� -
   $	 	TeamBRank��$�� ��$
��Left=�$��
100,19,0,0q�$��1��$	��Top=�$ 
0.342,0.31&�$��3���� -   $ btnGenerateByOp�����#26694a
�������$��Teams By OP score��$
��Left=�$	��Top=�$��50��$	��154��$��2��$��
112,-2,0,0q�$��2���� -   $ 	btnRandom�����#AC384C
�������$��Random��$
��Left=�$	��Top=�$��50��$��67��$��1��$��	91,-2,0,0q�