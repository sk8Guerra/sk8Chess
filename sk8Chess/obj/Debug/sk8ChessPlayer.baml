   M S B A M L   `   `   `  ����C  ?sk8Chess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:sk8Chesssk8Chess  5   	       sk8Chess.sk8ChessPlayer   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:sk8Chess     5   	   U QMaterialDesignThemes.Wpf, Version=2.2.0.725, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  sk8ChessPlayer��5   	   $	��520��6    $	��300��6-    � 
ResizeMode$ NoResize=�69    � Icon$  Resources\sk8ChessIcon.png��5
   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   .��5      � -   5        $��Reproductor��5       � ColumnDefinitions 5   
   �� 5      $
��223* �6    � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ Accent=�6#   $��10q�61   $��2��6>   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      d�  ' #MaterialDesignHamburgerToggleButton#���  6   �� 5       $��Center=�6   $��16 0 0 0q�67   Music player6W   5!      5"      #  MaterialDesignThemes.Wpf.Card  5$   
   $��8,8,8,0q�6   $	��390��6/   $��1��6<   $��2��6I   +  %MaterialDesignThemes.Wpf.ShadowAssist	   ShadowDepth$	 Depth4=�6]   .��5%      �  5&      �� 5'      $	��180 �6$   �� 5(      .+�5+      �� $(��"Resources/reproductorwallpaper.jpg��6   $��UniformToFill=�6D   �� 5-      -   5        $��	StarMusic��5-      
 � ToolTip$
 Start music��6+   $��0��5.       0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6&   $��Right=�5/      $��Bottom=�65   $��
0 0 16 -20q�50      .��51      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.2.0.725, Culture=neutral, PublicKeyToken=null]]   Kind$
 Play=�6.   52      �� 54      $��1��6   $��25q�6*   .+�55      �� $
��Bold"�6    $��20(�62   $��30��6@   enter your route:6_   �� 57      -   5        $��
RouteMusic��59      $��1��57       �� TextWrapping$
 Wrap=�6,   $��Stretch=�6@   $	��210��58       �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�5;      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ route��5<      $��52��5=      6    � 5?      $��70��6    5@      �� 5A      �� 5B      .+�5E      �� $��Center=�6%   $��Right=�6@   $ 
Horizontal=�6\   $��	23,30,8,8q�6u   .+�5F      ��   MaterialDesignToolButton#��[ 6%   $��30��6W   $��2 0 2 0q�6b   +  %MaterialDesignThemes.Wpf.RippleAssist   
IsCentered . .��5H   "     $ ShareVariant=�6:   5I      �� 5K      #��[ 6%   $��30��6W   $��2 0 2 0q�6b    . .��5M   "     $ Heart=�6:   5N      5O      �� 5Q      -   5        $��CancelMusic��5Q   1   $��1��6!   $��90��6D   $��36��6O     MaterialDesignFlatButton#��[ 5R      $
 Cancel��5S      $
��Left=�6.   $��CANCEL��6J   $��0,27,0,7q�6[   5U      5V      5X      5Y      5\      5]      