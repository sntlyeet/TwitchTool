   M S B A M L   `   `   `  ����S  OTwitch Tool by sntl_Yeet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Twitch_Tool_by_sntl_YeetTwitch_Tool_by_sntl_Yeet  5   	   )    #Twitch_Tool_by_sntl_Yeet.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Twitch_Tool_by_sntl_Yeet     5   	     � Title$  Twitch tool by sntl_Yeet��5	   	   $	��450��6*   $	��300��67    � Topmost .  � Icon$ 	/Icon.ico��5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      $��0* �6   .+�5   
   �� -   5        $��btnOpenFile��5   %   $y�Hidden=�6   $��10,10,151,357q�6S   $��
Open files��6j   6�   �� 5   
   -   5        $��startBot��5   %   $y�Hidden=�6   $��154,10,10,357q�6L   $��Start��6c   �� 5   
   -   5        $��lbFiles��5   &   $y�Hidden=�6   $��
10,80,0,55q�65   ���#36393E
������� �� SelectionMode$ Multiple=�6q   �� 5   
   -   5        $��removeSelected��5   %   $y�Hidden=�6   $��10,367,10,10q�6V   $��Remove selected��6l   �� 5   
   -   5        $��label1��5   $   $y�Hidden=�6   $��press ctrl + f1 to cancel��62   $
��Left=�6V   $��	5,0,0,330q�6q   $��Bottom=�6�   
�������$
��Left=�6�   $��14(�6�   $	��279��6�   $��29��6�   �� 5   
   -   5        $��LoadingBarLabel��5   %   $y�Visible=�6   $��LOADING��6<   $��96,170,98,202q�6N   $��Center=�6e   $��Center=�6�   $��Center=�6�   $��Center=�6�   $��49��6�   $	��100��6�   
�������$��20(�6  �� 5   
   -   5        $��LoadingBarImage��5   %   $y�Visible=�6   $
��Left=�6=   $	��450��6X   $	��Top=�6e   $	��300��6}   ��5      �� 5       �� DecodePixelWidth$	 300��6    �� 	UriSource$ /images/LoadingBar.png?�65   5      �� 5   
   -   5        $��LoadingBarRectangle��5   )   $y�Visible=�6   
�������$
��Left=�6Q   $��37��6l   $��31,212,0,172q�6x   $��Center=�6�   $��1��6�   ��5   
   �� 5       �� Color$ #36393E��6   60   5!      5"      