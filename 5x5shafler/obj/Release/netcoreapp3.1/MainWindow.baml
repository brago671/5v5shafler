   M S B A M L   `   `   `  ���� E  A5x5shafler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:_5x5shafler_5x5shafler      _5x5shafler.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:_5x5shafler       � Title$  suicide��$	��450��$	��800�� � 
ResizeMode$ NoResize=� � 	Resources    FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 RoundedButtonStyle �� 
TargetType	 �� 
TargetType
 ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 R     &	 g     &	 |     &	 �     &	 �     &	 �     &	 �     &	 �     &		 �     &	
     7   7  7  7  7  7  7  7  7  7 	 �� .���  � �� �� .R��� $��2q�$	 1 2R�$
 true��$��1��#��� ���� $ 	#FFDDDDDD���� $ 	#FF707070���� $ 	#FFBEE6FD���� $ 	#FF3C7FB1���� $ 	#FFC4E5F6���� $ 	#FF2C628B���� $ 	#FFF4F4F4���� $ 	#FFADB2B5���� $ 	#FF838383���� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� "	 ��.R��� $
 border��$ 20��#��z��#��z��#��z��$
 true��._��� $ contentPresenter��$|�False��#��z��#��z��$
��True��# z #��z�� P�  �@��IsDefaulted$
 true��. ��� $ border��# � �� � ��P�  �@J�IsMouseOver$
 true��. ��� $ border��8   � ���� $ border��8   � ��P�  � ��$
 true��. ��� $ border��8   � ���� $ border��8   � ��P�  � {�$ false��. ��� $ border��8   � ���� $ border��8   � ���� $ contentPresenter��8 	  � ��.���  � ShowGridLines$ False�� � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* � � RowDefinitions �� $��70 ��� $��50 ��� $��* ��� $��* �.+��� -   $��TextBox1��$��1��$��2��$��30(�$��Team A��$��Center=�$	��Top=��� -   $��TextBox2��$��1��$��2��$��2��$��30(�$��Team B��$	��Top=�$��Center=��� -   $��ListBoxTeamA��$��2��$��2��$��2��$��5,5,5,5q�$��20(��� -   $��ListBoxTeamB��$��2��$��2��$��2��$��2��$��5,5,5,5q�$��20(��� -   $��btnSelectPlayers��#��� 
 ���#5A99EB
�������$��Players��$
��Left=�$��Center=�$��50��$��0��$��67��$��3��$��24,0,0,0q��� -   $��lblPleyersSelected��$
��0/10��$��3��$
��Left=�$��	111,0,0,0q�$��Center=�$��79��$��20(��� -    ��Name$ 	btnRandom��#��� 
 ���#AC384C
�������$��Random��$��Center=�$	��Top=�$��37��$��54��$��1��$��2��$��0,12,0,0q��� -   $ btnGenerate��#��� 
 ���#5EAE79
�������$��
Make Teams��$��Center=�$	��Top=�$��50��$	��104��$��1��$��0,65,0,0q�$��2��$��2���� -	   $��Output��$��Please select the players��$
��Left=�$��	39,23,0,0q�$	��Top=�$��2��$	��291��$��30��$��Oblique$� J� OpacityMask
 �   ����	#FFFBF5F5�� $��Output:��$
��Left=�$��39,5,0,0q�$	��Top=�$��25��$	��291��$��2�����	#FFFBF5F5